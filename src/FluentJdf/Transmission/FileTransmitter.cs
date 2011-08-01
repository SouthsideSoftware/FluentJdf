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
using FluentJdf.Utility;
using Infrastructure.Core;
using System.IO;
using Infrastructure.Core.Helpers;

namespace FluentJdf.Transmission {

    /// <summary>
    /// Transmit JDF over File and collect a response.
    /// </summary>
    public class FileTransmitter : ITransmitter {

        static ILog logger = LogManager.GetLogger(typeof(FileTransmitter));
        readonly ITransmissionPartFactory transmissionPartFactory;
        readonly ITransmissionLogger transmissionLogger;
        readonly IEncodingFactory encodingfactory;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="encodingfactory"></param>
        /// <param name="transmissionLogger"></param>
        /// <param name="transmissionPartFactory"></param>
        public FileTransmitter(IEncodingFactory encodingfactory, ITransmissionLogger transmissionLogger, ITransmissionPartFactory transmissionPartFactory) {
            ParameterCheck.ParameterRequired(encodingfactory, "encodingfactory");
            ParameterCheck.ParameterRequired(transmissionLogger, "transmissionLogger");
            ParameterCheck.ParameterRequired(transmissionPartFactory, "transmissionPartFactory");

            this.encodingfactory = encodingfactory;
            this.transmissionLogger = transmissionLogger;
            this.transmissionPartFactory = transmissionPartFactory;
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

            var transmissionEncoder = GetFileTransmitterEncoder(uri);

            if (transmissionEncoder != null) {

                FileTransmitterEncoder actualEncoder;

                if (transmissionEncoder.FolderInfo.Count == 0) {
                    actualEncoder = FileTransmitterEncoder.BuildDefaultFolderInfoCollection(transmissionEncoder);
                }
                else {
                    actualEncoder = transmissionEncoder;
                }

                List<FileTransmissionItem> results = null;
                try {
                    results = actualEncoder.PrepareTransmission(partsToSend, transmissionPartFactory, encodingfactory, transmissionLogger);

                    foreach (var item in results.OrderBy(item => item.Order)) {
                        if (item.Stream.CanSeek) {
                            item.Stream.Seek(0, SeekOrigin.Begin);
                        }
                        var fileInfo = new FileInfo(item.DestinationUri.LocalPath);
                        DirectoryAndFileHelper.EnsureFolderExists(fileInfo.Directory, logger);
                        DirectoryAndFileHelper.SaveStreamToFile(item.Stream, fileInfo, false, logger);
                    }
                }
                catch (Exception err) {
                    logger.Error(string.Format(Messages.HttpTransmitter_Transmit_HttpTransmitter_UnexpectedException, uri), err);
                    throw;
                }
                finally {
                    if (results != null) {
                        try {
                            foreach (var item in results) {
                                item.Dispose();
                            }
                        }
                        finally {
                            //do nothing
                        }
                    }
                }

                return new FileTransmissionJmfResult();
            }
            else {
                //This code is no longer valid
                //TODO delete this code since mime is no longer the default.
                var fileInfo = new FileInfo(uri.LocalPath);
                DirectoryAndFileHelper.EnsureFolderExists(fileInfo.Directory, logger);
                try {
                    var encodingResult = encodingfactory.GetEncodingForTransmissionParts(partsToSend).Encode(partsToSend);
                    transmissionLogger.Log(new TransmissionData(encodingResult.Stream, encodingResult.ContentType, "Request"));

                    if (encodingResult.Stream.CanSeek) {
                        encodingResult.Stream.Seek(0, SeekOrigin.Begin);
                    }

                    DirectoryAndFileHelper.SaveStreamToFile(encodingResult.Stream, fileInfo, false, logger);

                    return new FileTransmissionJmfResult();
                }
                catch (Exception err) {
                    logger.Error(string.Format(Messages.HttpTransmitter_Transmit_HttpTransmitter_UnexpectedException, uri), err);
                    throw;
                }
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

        /// <summary>
        /// Gets the encoder associated with a URI in a given transmitter configuration.
        /// </summary>
        /// <param name="uri">The destination URI.</param>
        /// <returns>The FileTransmitterEncoder for the URI or null if there is no FileTransmitterEncoder for the URI</returns>
        private static FileTransmitterEncoder GetFileTransmitterEncoder(Uri uri) {

            FileTransmitterEncoder retVal = null;

            var testPath = uri.GetLocalPath();

            retVal = FluentJdf.Configuration.FluentJdfLibrary.Settings.EncodingSettings.FileTransmitterEncoders
                .FirstOrDefault(item => item.Value.LocalPath.Equals(testPath, StringComparison.OrdinalIgnoreCase)).Value;
            return retVal;
        }
    }
}
