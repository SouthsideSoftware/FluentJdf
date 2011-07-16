using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Infrastructure.Core.Logging;
using Infrastructure.Core.Resources;
using Infrastructure.Core.CodeContracts;

namespace Infrastructure.Core.Helpers {

    /// <summary>
    /// Helper methods for Directories and Files.
    /// </summary>
    public static class DirectoryAndFileHelper {

        static ILog _logger = LogManager.GetLogger(typeof(DirectoryAndFileHelper));

        /// <summary>
        /// Ensure a Directory exists and if it does not, create it.
        /// </summary>
        /// <param name="fileInfo">The directory to ensure</param>
        /// <param name="logger">An optional logger to use to log any exceptions</param>
        public static void EnsureFolderExists(FileInfo fileInfo, ILog logger = null) {
            ParameterCheck.ParameterRequired(fileInfo, "fileInfo");
            EnsureFolderExists(fileInfo.Directory, logger);
        }

        /// <summary>
        /// Ensure a Directory exists and if it does not, create it.
        /// </summary>
        /// <param name="directory">The directory to ensure</param>
        /// <param name="logger">An optional logger to use to log any exceptions</param>
        public static void EnsureFolderExists(DirectoryInfo directory, ILog logger = null) {
            ParameterCheck.ParameterRequired(directory, "directory");
            if (!directory.Exists) {
                try {
                    directory.Create();
                }
                catch (Exception ex) {
                    var log = logger ?? _logger;
                    log.Error(string.Format(Messages.DirectoryAndFileHelper_ErrorCreatingDirectory, directory.FullName), ex);
                    throw;
                }
            }
        }
    }

}
