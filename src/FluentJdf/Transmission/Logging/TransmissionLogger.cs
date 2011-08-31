using System;
using System.IO;
using System.Text;
using FluentJdf.LinqToJdf;
using FluentJdf.Resources;
using Infrastructure.Core.CodeContracts;
using Infrastructure.Core.Helpers;
using Infrastructure.Core.Logging;

namespace FluentJdf.Transmission.Logging {
    /// <summary>
    /// Logs transmissions.
    /// </summary>
    public class TransmissionLogger : ITransmissionLogger {
        ILog logger = LogManager.GetLogger(typeof(TransmissionLogger));

        readonly int InlineStreamLimit;
        readonly string StreamLogsFolder;

        /// <summary>
        /// ctor
        /// </summary>
        public TransmissionLogger() {
            this.InlineStreamLimit = Configuration.FluentJdfLibrary.Settings.TransmitterSettings.InlineStreamLimit;
            this.StreamLogsFolder = Configuration.FluentJdfLibrary.Settings.TransmitterSettings.StreamLogsFolder;
        }

        /// <summary>
        /// Log the given data.
        /// </summary>
        /// <param name="transmissionData"></param>
        /// <remarks>Logs the stream inline if it does not exceed
        /// the configured inline stream limit.  If the limit is exceeded,
        /// it is logged in an external file and referenced inline.</remarks>
        public void Log(TransmissionData transmissionData) {
            ParameterCheck.ParameterRequired(transmissionData, "transmissionData");

            try {
                logger.Debug(BuildLogMessage(transmissionData));
            }
            catch (Exception err) {
                logger.Error(Messages.TransmissionLogger_Log_FailedToLog, err);
            }
        }

        string BuildLogMessage(TransmissionData transmissionData) {
            var sb = new StringBuilder(transmissionData.ToLogString());
            if (transmissionData.Stream.Length <= InlineStreamLimit) {
                sb.AppendFormat("Data:\n");
                byte[] bytes = new byte[transmissionData.Stream.Length];
                transmissionData.Stream.Read(bytes, 0, bytes.Length);
                try {
                    sb.AppendLine(new UTF8Encoding(true).GetString(bytes));
                }
                finally {
                    transmissionData.Stream.Seek(0, SeekOrigin.Begin);
                }
            }
            else {
                var fullyQualifiedLogPath = StreamLogsFolder;
                if (!Path.IsPathRooted(fullyQualifiedLogPath)) {
                    fullyQualifiedLogPath = Path.Combine(ApplicationInformation.Directory, fullyQualifiedLogPath);
                }
                var streamFileName = Path.Combine(fullyQualifiedLogPath, Globals.CreateUniqueId("Stream_") + ".dat");
                using (var outStream = File.Open(streamFileName, FileMode.CreateNew, FileAccess.Write)) {
                    transmissionData.Stream.CopyTo(outStream);
                    transmissionData.Stream.Seek(0, SeekOrigin.Begin);
                }
                sb.AppendLine(string.Format("Data: See: {0}", streamFileName));
            }
            sb.AppendLine("*******************************");
            return sb.ToString();
        }
    }
}
