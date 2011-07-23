using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FluentJdf.Transmission {

    /// <summary>
    /// Stuff used for the file transmission config
    /// </summary>
    public static class FileTransmissionConfig {

        /// <summary>
        /// Full path of the configuration file.
        /// </summary>
        public static string ConfigurationFile {
            get {
                return AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
            }
        }

        /// <summary>
        /// Path where the executable is located without the name of the executable. (same as InstallationRoot)
        /// </summary>
        public static string ExecutablePath {
            get {
                return Path.GetDirectoryName(ConfigurationFile);
            }
        }

        /// <summary>
        /// Path where the executable is located without the name of the executable. (same as ExecutablePath)
        /// </summary>
        public static string InstallationRoot {
            get {
                return Path.GetDirectoryName(ConfigurationFile);
            }
        }

        /// <summary>
        /// The Log Folder
        /// </summary>
        public static string LogFolder {
            get {
                //TODO how do we determine the log folder path?
                return null;
            }
        }

        /// <summary>
        /// The Temp folder
        /// </summary>
        public static string TempFolder {
            get {
                return Path.GetTempPath();
            }
        }

        /// <summary>
        /// Fixup a path in a configuration string replacing ${InstallationRoot}, ${ConfigurationFolder},
        /// ${TempFolder} and ${FileStorageRoot} etc. with corresponding values from the configuration file.
        /// </summary>
        /// <param name="pathString">The path to fixup.</param>
        /// <returns>The path with all variables replaced.</returns>
        public static string FixupConfigItemPath(string pathString) {
            try {
                string oldString = null;
                do {
                    oldString = pathString;

                    if (pathString.IndexOf("${InstallationRoot}") > -1) {
                        pathString = ReplaceVar(pathString, "InstallationRoot", InstallationRoot);
                    }
                    if (pathString.IndexOf("${ConfigurationFolder}") > -1) {
                        pathString = ReplaceVar(pathString, "ConfigurationFolder", ExecutablePath);
                    }
                    if (pathString.IndexOf("${TempFolder}") > -1) {
                        pathString = ReplaceVar(pathString, "TempFolder", TempFolder);
                    }
                    if (pathString.IndexOf("${RuntimeExecutableFolder}") > -1) {
                        pathString = ReplaceVar(pathString, "RuntimeExecutableFolder", ExecutablePath);
                    }
                } while (oldString != pathString);
            }
            catch {
                //Ignoring errors because the logging comes in here as it starts so there may be no place to log anything!
            }
            return pathString;
        }

        /// <summary>
        /// Replace a variable like ${name} with given information assuming
        /// that the result is supposed to be a legal file path.  Used internally by ConfigBase.
        /// </summary>
        /// <param name="pathString">The string that contains the replacement variable and other text.</param>
        /// <param name="varName">The name of the replacement variable without the opening "${" or the closing
        /// "}".</param>
        /// <param name="varValue">The value that should replace all occurences of the variable.</param>
        /// <returns>The string with replacements made.</returns>
        public static string ReplaceVar(string pathString, string varName, string varValue) {
            if (varValue != null) {
                string fullVarName = "${" + varName + "}";
                int index = pathString.IndexOf(fullVarName);
                //only proceed if replacement var found
                if (index > -1) {
                    //if at the start of the string
                    if (index == 0) {
                        //combine replace value with everything that comes after the end of the replacement var
                        //not including any leading slash in the static part of the string
                        string endPath = pathString.Substring(fullVarName.Length);
                        while (endPath.StartsWith(@"\")) {
                            endPath = endPath.Substring(1);
                        }
                        pathString = Path.Combine(varValue, endPath);
                    }
                    //if it it as the end
                    else if (index == pathString.Length - fullVarName.Length) {
                        //combine everything that comes before the start of the replacement var with the replacement value
                        pathString = Path.Combine(pathString.Substring(0, pathString.Length - fullVarName.Length), varValue);
                    }
                    //otherwise, it is somewhere in the middle
                    else {
                        //combine the front literal with the replacement value with leading slashes removed
                        //and then add on the remaining static portion without leading slashes
                        string endPath = pathString.Substring(index + fullVarName.Length);
                        while (endPath.StartsWith(@"\")) {
                            endPath = endPath.Substring(1);
                        }
                        while (varValue.StartsWith(@"\")) {
                            varValue = varValue.Substring(1);
                        }
                        string path1 = pathString.Substring(0, index);
                        pathString = Path.Combine(Path.Combine(path1, varValue), endPath);
                    }
                }
            }

            return pathString;
        }

    }
}
