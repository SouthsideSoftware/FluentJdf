using System;
using System.IO;
using System.Text;
using FluentJdf.LinqToJdf;
using FluentJdf.Resources;
using FluentJdf.Utility;
using Infrastructure.Core.CodeContracts;
using Infrastructure.Core.Logging;
using Infrastructure.Core.Mime;
using Infrastructure.Core.Helpers;

namespace FluentJdf.Encoding {
    /// <summary>
    /// Mime Encoder class used for multi part encoding.
    /// </summary>
    public class MimeEncoding : IEncoding {
        static readonly ILog logger = LogManager.GetLogger(typeof(MimeEncoding));
        readonly ITransmissionPartFactory transmissionPartFactory;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="transmissionPartFactory"></param>
        public MimeEncoding(ITransmissionPartFactory transmissionPartFactory) {
            ParameterCheck.ParameterRequired(transmissionPartFactory, "transmissionPartFactory");

            this.transmissionPartFactory = transmissionPartFactory;
        }

        #region IEncoding Members

        /// <summary>
        /// Encode a collection of parts.
        /// </summary>
        /// <param name="transmissionParts"></param>
        /// <returns></returns>
        public EncodingResult Encode(ITransmissionPartCollection transmissionParts) {
            ParameterCheck.ParameterRequired(transmissionParts, "transmissionParts");
            string contentType = null;
            return OptimalEncode(transmissionParts, out contentType);
        }

        /// <summary>
        /// Encode a part.
        /// </summary>
        /// <param name="transmissionPart"></param>
        /// <returns></returns>
        public EncodingResult Encode(ITransmissionPart transmissionPart) {
            ParameterCheck.ParameterRequired(transmissionPart, "transmissionPart");
            return Encode(new TransmissionPartCollection { transmissionPart });
        }

        /// <summary>
        /// Decode the given stream into a collection of parts.
        /// </summary>
        /// <returns></returns>
        public ITransmissionPartCollection Decode(string name, Stream stream, string mimeType, string id = null) {
            ParameterCheck.ParameterRequired(stream, "stream");
            ParameterCheck.StringRequiredAndNotWhitespace(mimeType, "mimeType");

            var transmissionPartCollection = new TransmissionPartCollection();

            try {
                int nextContentId = 1;

                var mime = new Mime(stream);
                Console.WriteLine("Parts " + mime.NumParts);
                logger.DebugFormat("Parts {0}", mime.NumParts);

                for (int partIndex = 0; partIndex < mime.NumParts; partIndex++) {
                    Mime mimePart = mime.GetPart(partIndex);
                    string contentId = mimePart.GetHeaderField("Content-id");
                    if (contentId.Trim().Length == 0) {
                        var sb = new StringBuilder();
                        sb.Append("OAIPART_"); //TODO determine better name for mime part than OAIPART_
                        sb.Append(DateTime.Now.Ticks.ToString());
                        sb.Append("_");
                        sb.Append(nextContentId.ToString());
                        contentId = sb.ToString();
                        nextContentId++;
                    }

                    string contentType = mimePart.ContentType;

                    //content type may contain ;char-encoding.  Strip it off if found.
                    if (contentType != null) {
                        contentType = contentType.NormalizeContentType();
                    }

                    //TODO We need better way to get a BodyStream from a MimePart.
                    transmissionPartCollection.Add(transmissionPartFactory.CreateTransmissionPart(name,
                                                                                                  new MemoryStream(mimePart.GetBodyBinary()),
                                                                                                  contentType, contentId));
                }
            }
            catch (Exception err) {
                logger.Error(Messages.MimeEncoding_Decode_GeneralDecodingError, err);
                throw new JdfException(Messages.MimeEncoding_Decode_GeneralDecodingError, err);
            }

            if (transmissionPartCollection.Count == 0) {
                logger.Error(Messages.MimeEncoding_Decode_NoMessagePartsToDecode);
                throw new JdfException(Messages.MimeEncoding_Decode_NoMessagePartsToDecode);
            }

            return transmissionPartCollection;
        }

        #endregion

        /// <summary>
        /// Encode a set of transmission parts into a stream suitable for 
        /// transmission.
        /// </summary>
        /// <param name="parts">The parts to encode.</param>
        /// <param name="contentType">The MIME Type of the TransmissionPartCollection contents.</param>
        /// <returns>The stream.</returns>
        EncodingResult OptimalEncode(ITransmissionPartCollection parts, out string contentType) {
            return OptimalEncode(parts, out contentType, false);
        }

        /// <summary>
        /// Encode a set of transmission parts into a stream suitable for 
        /// transmission with or without Binary-Encoding Attachment.
        /// </summary>
        /// <param name="parts">The parts to encode.</param>
        /// <param name="contentType">The MIME Type of the TransmissionPartCollection contents.</param>
        /// <param name="withBinaryEncodingAttachment">if true, save all Attachments with binary-encoding type. </param>
        /// <returns>An OptimalEncodingResult with the stream and the name of the backing file store if there is one.</returns>
        EncodingResult OptimalEncode(ITransmissionPartCollection parts, out string contentType, bool withBinaryEncodingAttachment) {
            using (var mime = new Mime()) {
                mime.NewMultipartRelated();

                foreach (ITransmissionPart part in parts) {
                    var mimePart = new Mime();

                    mimePart.SetHeaderField("Content-ID", part.Id);

                    //TODO optimize call to get the bytes from the stream
                    byte[] data = null;
                    using (var partStream = part.CopyOfStream()) {
                        using (var sr = new BinaryReader(partStream)) {
                            data = sr.ReadBytes((int)partStream.Length);
                        }
                    }
                    //TODO determine if this is how we should handle it.
                    if (!part.MimeType.Equals(MimeTypeHelper.JdfMimeType)
                            && !part.MimeType.Equals(MimeTypeHelper.JmfMimeType)
                            && !part.MimeType.StartsWith("text/")) {
                        //for text and jdf/jmf documents, do not base64 encode them.
                        mimePart.EncodingType = Mime.MimeEncoding.Base64;
                    }
                    else {
                        mimePart.EncodingType = Mime.MimeEncoding.Binary;
                    }
                    mimePart.SetBodyFromBinary(data);

                    mimePart.ContentType = part.MimeType;
                    mime.AppendPart(mimePart);
                }

                contentType = mime.ContentType;

                mime.CreateDefaultType();

                //TODO see if there is a more optimal way to get the stream from the mime.
                return new EncodingResult(mime.GetMimeStream(), contentType);
            }
        }
    }
}