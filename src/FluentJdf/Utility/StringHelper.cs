using System;
using System.Diagnostics.Contracts;
using Onpoint.Commons.Core.CodeContracts;

namespace FluentJdf.Utility
{
    /// <summary>
    /// Extensions to the string class.
    /// </summary>
    public static class StringHelper
    {
        /// <summary>
        /// Contains implementation that lets you specify a
        /// case-insensitive compare
        /// </summary>
        /// <param name="source">The string being checked.</param>
        /// <param name="stringToCheck">The text looked for in source.</param>
        /// <param name="comparison">Rules for comparison</param>
        /// <returns>True if source contains <paramref name="stringToCheck"/> given the comparison rules.  Otherwise, <see langword="false"/>.</returns>
        public static bool Contains(this string source, string stringToCheck, StringComparison comparison)
        {
            Contract.Requires(source != null);
            Contract.Requires(!string.IsNullOrEmpty(stringToCheck));

            return source.IndexOf(stringToCheck, comparison) != -1;
        }
        /// <summary>
        /// Truncates the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="length">The length.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string Truncate(this string source, int length)
        {
            Contract.Requires(source != null);

            if (source.Length > length)
            {
                source = source.Substring(0, length);
            }
            return source;
        }

        /// <summary>
        /// Count the number of characters in a string.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static int CountChar(this string s, char c)
        {
            ParameterCheck.ParameterRequired(s, "s");
            int pos = 0, count = 0;

            while ((pos = s.IndexOf(c, pos)) != -1)
            {
                count++;
                pos++;
            }

            return count;
        }
    }
}
