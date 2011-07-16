using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentJdf.Messaging;
using FluentJdf.Encoding;
using Infrastructure.Core.Logging;
using FluentJdf.Transmission.Logging;
using Infrastructure.Core.CodeContracts;
using FluentJdf.Resources;
using Infrastructure.Core;
using System.IO;
using Infrastructure.Core.Helpers;

namespace FluentJdf.Transmission {

    /// <summary>
    /// Transmit JDF over File and collect a response.
    /// </summary>
    public class FileTransmitter : ITransmitter {

        static ILog logger = LogManager.GetLogger(typeof(FileTransmitter));
        readonly ITransmissionLogger transmissionLogger;

        readonly IEncodingFactory encodingfactory;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="encodingfactory"></param>
        /// <param name="transmissionLogger"></param>
        public FileTransmitter(IEncodingFactory encodingfactory, ITransmissionLogger transmissionLogger) {
            ParameterCheck.ParameterRequired(encodingfactory, "encodingfactory");
            ParameterCheck.ParameterRequired(transmissionLogger, "transmissionLogger");

            this.encodingfactory = encodingfactory;
            this.transmissionLogger = transmissionLogger;
        }

        /// <summary>
        /// Transmit data to the given URI.
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="partsToSend"></param>
        /// <returns>A result that includes parsed JMF results if available.</returns>
        public IJmfResult Transmit(Uri uri, ITransmissionPartCollection partsToSend) {
            ParameterCheck.ParameterRequired(uri, "uri");
            ParameterCheck.ParameterRequired(partsToSend, "partsToSend");
            if (partsToSend.Count == 0) {
                throw new PreconditionException(Messages.FileTransmitter_Transmit_AtLeastOneTransmissionPartIsRequired);
            }
            if (!uri.IsFile && !uri.IsUnc) {
                throw new PreconditionException(Messages.FileTransmitter_Transmit_RequiresHttpUrl);
            }
            var fileInfo = new FileInfo(uri.LocalPath);

            DirectoryAndFileHelper.EnsureFolderExists(fileInfo.Directory, logger);

            try {
                var encodingResult = encodingfactory.GetEncodingForTransmissionParts(partsToSend).Encode(partsToSend);
                transmissionLogger.Log(new TransmissionData(encodingResult.Stream, encodingResult.ContentType, "Request"));

                DirectoryAndFileHelper.SaveStreamToFile(encodingResult.Stream, fileInfo, false, logger);

                return new JmfResult(new TransmissionPartCollection());
            }
            catch (Exception err) {
                logger.Error(string.Format(Messages.HttpTransmitter_Transmit_HttpTransmitter_UnexpectedException, uri), err);
                throw;
            }
        }

        /// <summary>
        /// Transmit data to the given uri (string).
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="partsToSend"></param>
        /// <returns>A result that includes parsed JMF results if available.</returns>
        public IJmfResult Transmit(string uri, ITransmissionPartCollection partsToSend) {
            ParameterCheck.StringRequiredAndNotWhitespace(uri, "uri");
            return Transmit(new Uri(uri), partsToSend);
        }
    }
}
