using System;
using Infrastructure.Core.CodeContracts;
using System.IO;

namespace FluentJdf.Utility {
    /// <summary>
    /// Extensions to the string class.
    /// </summary>
    public static class StringHelper {
        /// <summary>
        /// Contains implementation that lets you specify a
        /// case-insensitive compare
        /// </summary>
        /// <param name="source">The string being checked.</param>
        /// <param name="stringToCheck">The text looked for in source.</param>
        /// <param name="comparison">Rules for comparison</param>
        /// <returns>True if source contains <paramref name="stringToCheck"/> given the comparison rules.  Otherwise, <see langword="false"/>.</returns>
        public static bool Contains(this string source, string stringToCheck, StringComparison comparison) {
            ParameterCheck.ParameterRequired(source, "source");
            ParameterCheck.StringRequiredAndNotWhitespace(stringToCheck, "stringToCheck");

            return source.IndexOf(stringToCheck, comparison) != -1;
        }

        /// <summary>
        /// Truncates the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="length">The length.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string Truncate(this string source, int length) {
            ParameterCheck.ParameterRequired(source, "source");

            if (source.Length > length) {
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
        public static int CountChar(this string s, char c) {
            ParameterCheck.ParameterRequired(s, "s");
            int pos = 0, count = 0;

            while ((pos = s.IndexOf(c, pos)) != -1) {
                count++;
                pos++;
            }

            return count;
        }

        /// <summary>
        /// Ensure a directory name stored as a string ends in / or \
        /// </summary>
        /// <param name="path">The uri to process</param>
        /// <param name="useAltDirectoryChar">Insert a / instead of a \</param>
        /// <returns></returns>
        public static string EnsureTrailingSlash(this string path, bool useAltDirectoryChar = true) {
            ParameterCheck.ParameterRequired(path, "path");

            if (!path.EndsWith(Path.DirectorySeparatorChar.ToString()) && !path.EndsWith(Path.AltDirectorySeparatorChar.ToString())) {
                if (useAltDirectoryChar) {
                    path += Path.AltDirectorySeparatorChar;
                }
                else {
                    path += Path.DirectorySeparatorChar;
                }
            }

            return path;
        }

        /// <summary>
        /// Given a content type, returns a content type all in 
        /// lower case with any qualifiers (bits after ";")
        /// removed.
        /// </summary>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public static string NormalizeContentType(this string contentType) {
            contentType = contentType.ToLower();
            string[] parts = contentType.Split(';');
            if (parts.Length > 1) {
                contentType = parts[0];
            }

            return contentType;
        }
    }
}