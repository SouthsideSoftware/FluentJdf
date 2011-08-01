using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.Core.CodeContracts;
using System.IO;

namespace FluentJdf.Utility {

    /// <summary>
    /// Extension Methods for a Uri
    /// </summary>
    public static class UriExtensionMethods {

        /// <summary>
        /// Ensure a file:/// based uri ends in /
        /// </summary>
        /// <param name="uri">The uri to process</param>
        /// <returns></returns>
        public static Uri EnsureTrailingSlash(this Uri uri) {
            ParameterCheck.ParameterRequired(uri, "uri");

            if (!uri.IsFile) {
                return uri;
            }

            if (!uri.LocalPath.EndsWith(Path.DirectorySeparatorChar.ToString())) {
                return new Uri(uri.ToString() + Path.DirectorySeparatorChar);
            }

            return uri;
        }

        /// <summary>
        /// Get the local path for a file based uri
        /// </summary>
        /// <param name="uri">The uri to process</param>
        /// <returns></returns>
        public static string GetLocalPath(this Uri uri) {
            ParameterCheck.ParameterRequired(uri, "uri");

            var retVal = Path.GetDirectoryName(uri.LocalPath);
            //itemPath will be null if the Url points at the root of a drive.  Use the Uri local path in that case.
            if (retVal == null) {
                retVal = uri.LocalPath;
            }

            if (!retVal.EndsWith(Path.DirectorySeparatorChar.ToString()) && !retVal.EndsWith(Path.AltDirectorySeparatorChar.ToString())) {
                retVal += Path.DirectorySeparatorChar;
            }

            return retVal;
        }
    }
}
