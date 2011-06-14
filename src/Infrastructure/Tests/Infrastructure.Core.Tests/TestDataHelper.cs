using System;
using System.Diagnostics;
using System.IO;
using Infrastructure.Core.CodeContracts;
using Infrastructure.Core.Helpers;
using Infrastructure.Core.Logging;

namespace Infrastructure.Core.Tests {
    public class TestDataHelper {
        static string testDir = "TestData";
        static TestDataHelper instance = new TestDataHelper();
        const string resourcePrefix = "Infrastructure.Core.Tests.TestData.";

        TestDataHelper() {
            if (Directory.Exists(testDir)) {
                Directory.Delete(testDir, true);
            }
         
            Directory.CreateDirectory(testDir);
            ExtractTestFiles();
        }

        void ExtractTestFiles() {
            foreach (string manifestResourceName in GetType().Assembly.GetManifestResourceNames()) {
                if (manifestResourceName.StartsWith(resourcePrefix)) {
                    var testFileName = manifestResourceName.Replace(resourcePrefix, "");
                    ExtractFile(testFileName, manifestResourceName);
                }
            }
        }

        public static TestDataHelper Instance {
            get { return instance; }
        }

        /// <summary>
        /// Gets the full path of the desired test file.
        /// </summary>
        /// <param name="testFileName"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">If the file does not exist in the test data folder extracted
        /// from the embedded resources.</exception>
        public string PathToTestFile(string testFileName) {
            ParameterCheck.StringRequiredAndNotWhitespace(testFileName, "testFileName");

            string testFilePath = Path.Combine(testDir, testFileName);

            if (!File.Exists(testFilePath)) {
                throw new ArgumentException("File {0} was not extracted from TestData resources", testFilePath);
            }

            return testFilePath;
        }

        void ExtractFile(string testFileName, string manifestResourceName) {
            string testFilePath = Path.Combine(testDir, testFileName);
            using (var stream = GetType().Assembly.GetManifestResourceStream(manifestResourceName)) {
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

            return File.OpenRead(PathToTestFile(testFileName));
        }
    }
}