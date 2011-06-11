using System.Collections.Generic;
using System.Text;

namespace FluentJdf.LinqToJdf
{
    /// <summary>
    /// Decorates an XPath string
    /// </summary>
    public class XPathDecorator
    {
        private readonly string _xPath;

        /// <summary>
        /// Create a decorator for a path
        /// </summary>
        /// <param name="xPath"></param>
        public XPathDecorator(string xPath)
        {
            _xPath = xPath;
        }

        /// <summary>
        /// Prefixes all unprefixed names with a namespace prefix
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public string PrefixNames(string prefix)
        {
            var result = new StringBuilder();
            var tokens = new List<string>(GetTokens());
            for (var i = 0; i < tokens.Count; i++)
            {
                if (IsNameToken(tokens, i))
                {
                    result.Append(prefix + ":");
                }
                result.Append(tokens[i]);
            }
            return result.ToString();
        }

        private static bool IsNameToken(IList<string> tokens, int i)
        {
            var previous = i == 0 ? string.Empty : tokens[i - 1]; 
            var token = tokens[i];
            var next = i == tokens.Count - 1 ? string.Empty : tokens[i + 1]; 

            if (!char.IsLetter(token[0])) return false;
            if (token == "and" || token == "or" || token == "div" || token == "mod") return false;
            if (previous == ":" || next == ":") return false;
            if (previous.EndsWith("@")) return false;
            if (next.StartsWith("(")) return false;

            return true;
        }

        private IEnumerable<string> GetTokens()
        {
            var token = new StringBuilder();
            var lastCharacter = '\0';
            foreach (var character in _xPath)
            {
                if (IsQuote(lastCharacter))
                {
                    token.Append(character);
                    if (character == lastCharacter)
                    {
                        yield return token.ToString();
                        token.Clear();
                        lastCharacter = '\0';
                    }
                    continue;
                }
                
                if (IsQuote(character) || IsName(character) != IsName(lastCharacter))
                {
                    if (token.Length > 0) yield return TrimToken(token);
                    token.Clear();
                }
                token.Append(character);
                lastCharacter = character;
            }
            if (token.Length > 0) yield return TrimToken(token);
        }

        private static string TrimToken(StringBuilder token)
        {
            var result = token.ToString().Trim();
            return result.Length == 0 ? " " : result;
        }

        private static bool IsQuote(char character) { return character == '"' || character == '\''; }

        private static bool IsName(char character)
        {
            return char.IsLetterOrDigit(character) || character == '-' || character == '_' || character == '.';
        }
    }
}
