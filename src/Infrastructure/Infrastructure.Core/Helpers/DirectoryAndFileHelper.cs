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

        static readonly ILog logger = LogManager.GetLogger(typeof(DirectoryAndFileHelper));

        static readonly DirectoryInfo tempPath = new DirectoryInfo(Path.GetTempPath());

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
                    var log = logger ?? DirectoryAndFileHelper.logger;
                    log.Error(string.Format(Messages.DirectoryAndFileHelper_ErrorCreatingDirectory, directory.FullName), ex);
                    throw;
                }
            }
        }

        /// <summary>
        /// Save a stream of information to a File
        /// </summary>
        /// <remarks>
        /// Because a FileSystemWatcher fires when a file is created and not finished, we want to
        /// save to a temporary file and then move the file when we are complete.
        /// </remarks>
        /// <param name="stream">The Stream to Save</param>
        /// <param name="path">The File Path to save the file</param>
        /// <param name="overrideFile">OverRide if the file exists?</param>
        /// <param name="logger">An optional logger to use to log any exceptions</param>
        public static void SaveStreamToFile(Stream stream, string path, bool overrideFile, ILog logger = null) {
            ParameterCheck.ParameterRequired(path, "path");
            SaveStreamToFile(stream, new FileInfo(path), overrideFile, logger);
        }

        /// <summary>
        /// Save a stream of information to a File
        /// </summary>
        /// <remarks>
        /// Because a FileSystemWatcher fires when a file is created and not finished, we want to
        /// save to a temporary file and then move the file when we are complete.
        /// If the directory is on the same drive as the Systems Temp folder, the file will be created there.
        /// </remarks>
        /// <param name="stream">The Stream to Save</param>
        /// <param name="fileInfo">The File  to save the stream</param>
        /// <param name="overrideFile">OverRide if the file exists?</param>
        /// <param name="logger">An optional logger to use to log any exceptions</param>
        public static void SaveStreamToFile(Stream stream, FileInfo fileInfo, bool overrideFile, ILog logger = null) {
            ParameterCheck.ParameterRequired(stream, "stream");
            ParameterCheck.ParameterRequired(fileInfo, "fileInfo");

            EnsureFolderExists(fileInfo);

            if (fileInfo.Exists && !overrideFile) {
                var log = logger ?? DirectoryAndFileHelper.logger;
                log.Error(string.Format(Messages.DirectoryAndFileHelper_SaveStreamToFile_DestinationFileExists, fileInfo.FullName));
                throw new ApplicationException(string.Format(Messages.DirectoryAndFileHelper_SaveStreamToFile_DestinationFileExists, fileInfo.FullName));
            }

            string tempFileName = null;

            if (tempPath.Root.Name.Equals(fileInfo.Directory.Root.Name)) {
                tempFileName = Path.GetTempFileName();
            }
            else {
                tempFileName = Path.Combine(fileInfo.Directory.FullName, Guid.NewGuid() + ".tmp");
            }

            if (fileInfo.Exists) {
                try {
                    fileInfo.Delete();
                }
                catch (Exception ex) {
                    var log = logger ?? DirectoryAndFileHelper.logger;
                    log.Error(string.Format(Messages.DirectoryAndFileHelper_SaveStreamToFile_CouldNotDeleteExistingFile, tempFileName), ex);
                    throw;
                }
            }

            try {
                using (var outStream = File.Open(tempFileName, FileMode.Create, FileAccess.Write, FileShare.None)) {
                    stream.CopyTo(outStream);
                }
            }
            catch (Exception ex) {
                AttemptDeleteOfFailedTempFile(tempFileName);
                var log = logger ?? DirectoryAndFileHelper.logger;
                log.Error(string.Format(Messages.DirectoryAndFileHelper_SaveStreamToFile_ErrorCreatingTempFile, tempFileName), ex);
                throw;
            }

            try {
                File.Move(tempFileName, fileInfo.FullName);
            }
            catch (Exception ex) {
                AttemptDeleteOfFailedTempFile(tempFileName);
                var log = logger ?? DirectoryAndFileHelper.logger;
                log.Error(string.Format(Messages.DirectoryAndFileHelper_SaveStreamToFile_ErrorRenamingFileFromTempFile, tempFileName, fileInfo.FullName), ex);
                throw;
            }

        }

        private static void AttemptDeleteOfFailedTempFile(string path) {
            try {
                if (File.Exists(path)) {
                    File.Delete(path);
                }
            }
            finally {

            }
        }

    }

}
