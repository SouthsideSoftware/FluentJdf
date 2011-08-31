using System.IO;
using Infrastructure.Core.Logging;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.Logging {
    [Subject("Logging Infrastructure")]
    public class when_using_a_static_logger_initialized_before_logging_configuration {
        static readonly ILog logger = LogManager.GetLogger("StaticLoggerTest");
        static string loggedText;
        const string LogFile = @"\logs\FluentJdf.Tests\General.log";

        Because of = () => logger.Debug("***StaticLoggerText***");

        static void ReadTextFromLogIfNeeded() {
            if (loggedText == null) {
                using (
                    var reader = new StreamReader(File.Open(LogFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))) {
                    loggedText = reader.ReadToEnd();
                }
            }
        }

        It should_have_existing_log_file = () => File.Exists(LogFile);

        It should_have_logged_message_text_in_log_file = () => {
            ReadTextFromLogIfNeeded();
            loggedText.ShouldContain("***StaticLoggerText***");
        };

        It should_have_the_correct_logger_name_in_log_file = () => {
            ReadTextFromLogIfNeeded();
            loggedText.ShouldContain("DEBUG StaticLoggerTest");
        };
    }
}