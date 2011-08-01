using System;
using System.IO;
using System.Reflection;
using Infrastructure.Core.CodeContracts;
using Infrastructure.Core.Helpers;

namespace Infrastructure.Testing {
    /// <summary>
    /// Helps get test data from resources
    /// </summary>
    public class TestDataHelper {
        static string testDir = "TestData";
        static TestDataHelper instance = new TestDataHelper();

        bool filesExtracted = false;

        TestDataHelper() {
            if (!Path.IsPathRooted(testDir)) {
                testDir = Path.Combine(ApplicationInformation.Directory, testDir);
            }
            if (Directory.Exists(testDir)) {
                Directory.Delete(testDir, true);
            }
         
            Directory.CreateDirectory(testDir);
        }

        void ExtractTestFilesIfNeeded(Assembly callingAssembly) {
            if (!filesExtracted) {
                var resourcePrefix = string.Format("{0}.TestData.", callingAssembly.GetName().Name);
                foreach (string manifestResourceName in callingAssembly.GetManifestResourceNames()) {
                    if (manifestResourceName.StartsWith(resourcePrefix)) {
                        var testFileName = manifestResourceName.Replace(resourcePrefix, "");
                        ExtractFile(testFileName, manifestResourceName, callingAssembly);
                    }
                }
                filesExtracted = true;
            }
        }

        /// <summary>
        /// Gets the singleton instance of the test data helper.
        /// </summary>
        public static TestDataHelper Instance {
            get { return instance; }
        }

        /// <summary>
        /// Gets the test data directory.
        /// </summary>
        public string TestDataDirectory { get { return testDir; } }

        /// <summary>
        /// Gets the full path of the desired test file.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException">If the file does not exist in the test data folder extracted
        /// from the embedded resources.</exception>
        public string PathToTestFile(string testFileName, Assembly resourceAssembly = null) {
            ParameterCheck.StringRequiredAndNotWhitespace(testFileName, "testFileName");

            if (resourceAssembly == null) {
                resourceAssembly = Assembly.GetCallingAssembly();
            }
            ExtractTestFilesIfNeeded(resourceAssembly);
            string testFilePath = Path.Combine(testDir, testFileName);

            if (!File.Exists(testFilePath)) {
                throw new ArgumentException(string.Format("File {0} was not extracted from TestData resources", testFilePath));
            }

            return testFilePath;
        }

        void ExtractFile(string testFileName, string manifestResourceName, Assembly resourceAssembly) {
            string testFilePath = Path.Combine(testDir, testFileName);
            using (var stream = resourceAssembly.GetManifestResourceStream(manifestResourceName)) {
                using (var file = File.OpenWrite(testFilePath)) {
                    if (stream == null) {
                        throw new Exception(string.Format("Manifest resource stream for {0} was not found", testFileName));
                    }
                    stream.CopyTo(file);
                }
            }
        }

        /// <summary>
        /// Gets the readable stream for the given file name located in the TestData folder
        /// </summary>
        /// <param name="testFileName"></param>
        /// <returns></returns>
        public Stream GetTestStream(string testFileName) {
            ParameterCheck.StringRequiredAndNotWhitespace(testFileName, "testFileName");

            return File.OpenRead(PathToTestFile(testFileName, Assembly.GetCallingAssembly()));
        }
    }
}