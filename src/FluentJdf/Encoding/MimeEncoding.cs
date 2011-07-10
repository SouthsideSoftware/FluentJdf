using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.Core;
using Infrastructure.Core.CodeContracts;
using System.IO;
using Infrastructure.Core.Mime;
using Infrastructure.Core.Helpers;
using FluentJdf.LinqToJdf;
using Infrastructure.Core.Logging;

namespace FluentJdf.Encoding {

    /// <summary>
    /// Mime Encoder class used for multi part encoding.
    /// </summary>
    public class MimeEncoding : IEncoding {

        static ILog logger = LogManager.GetLogger(typeof(MimeEncoding));
        ITransmissionPartFactory transmissionPartFactory;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="transmissionPartFactory"></param>
        public MimeEncoding(ITransmissionPartFactory transmissionPartFactory) {
            ParameterCheck.ParameterRequired(transmissionPartFactory, "transmissionPartFactory");

            this.transmissionPartFactory = transmissionPartFactory;
        }

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
            return Encode(new TransmissionPartCollection() { transmissionPart });
        }

        /// <summary>
        /// Decode the given stream into a collection of parts.
        /// </summary>
        /// <returns></returns>
        public ITransmissionPartCollection Decode(string name, System.IO.Stream stream, string mimeType, string id = null) {
            ParameterCheck.ParameterRequired(stream, "stream");
            ParameterCheck.StringRequiredAndNotWhitespace(mimeType, "mimeType");

            var transmissionPartCollection = new TransmissionPartCollection();

            try {
                int nextContentId = 1;


                Mime mime = new Mime(stream);
                Console.WriteLine("Parts " + mime.NumParts);
                logger.DebugFormat("Parts {0}", mime.NumParts);

                for (int partIndex = 0; partIndex < mime.NumParts; partIndex++) {
                    Mime mimePart = mime.GetPart(partIndex);
                    string contentId = mimePart.GetHeaderField("Content-id");
                    if (contentId.Trim().Length == 0) {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("OAIPART_"); //TODO determine better name for mime part than OAIPART_
                        sb.Append(DateTime.Now.Ticks.ToString());
                        sb.Append("_");
                        sb.Append(nextContentId.ToString());
                        contentId = sb.ToString();
                        nextContentId++;
                    }

                    var contentType = mimePart.ContentType;

                    //content type may contain ;char-encoding.  Strip it off if found.
                    if (contentType != null) {
                        contentType = contentType.ToLower();
                        string[] parts = contentType.Split(';');
                        if (parts.Length > 1) {
                            contentType = parts[0];
                        }
                    }

                    //TODO We need better way to get a BodyStream from a MimePart.
                    transmissionPartCollection.Add(transmissionPartFactory.CreateTransmissionPart(name,
                        new MemoryStream(mimePart.GetBodyBinary()), contentType, contentId));
                }
            }
            catch (Exception err) {
                throw new JdfException("Error occured attempting to decode multipart\related transmission.  The error is " + err.Message, err);
            }

            if (transmissionPartCollection.Count == 0) {
                throw new JdfException("Error occured attempting to parse through message, there are no parts to the transmission!");
            }

            return transmissionPartCollection;

        }

        /// <summary>
        /// Encode a set of transmission parts into a stream suitable for 
        /// transmission.
        /// </summary>
        /// <param name="parts">The parts to encode.</param>
        /// <param name="contentType">The MIME Type of the TransmissionPartCollection contents.</param>
        /// <returns>The stream.</returns>
        EncodingResult OptimalEncode(ITransmissionPartCollection parts, out string contentType)
        {
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
        EncodingResult OptimalEncode(ITransmissionPartCollection parts, out string contentType, bool withBinaryEncodingAttachment)
        {

            using (Mime mime = new Mime())
            {

                mime.NewMultipartRelated();

                foreach (var part in parts)
                {
                    Mime mimePart = new Mime();

                    //var encoder = factory.GetEncodingForMimeType(part.MimeType);
                    //encoder.Encode(part);

                    mimePart.SetHeaderField("Content-ID", part.Id);

                    //if this is not an attachment part or the mime type is text/ something then treat as text
                    if (part.MimeType.StartsWith("text/"))
                    {
                        string data = null;
                        using (var sr = new StreamReader(part.CopyOfStream()))
                        {
                            data = sr.ReadToEnd();
                        }
                        if (part.MimeType.IndexOf("xml") > -1)
                        {
                            mimePart.SetBodyFromXml(data);
                        }
                        else
                        {
                            mimePart.SetBodyFromPlainText(data);
                        }
                    }
                    else
                    {
                        //TODO optimize call to get the bytes from the stream
                        byte[] data = null;
                        using (var sr = new BinaryReader(part.CopyOfStream()))
                        {
                            data = sr.ReadBytes((int)part.CopyOfStream().Length);
                        }
                        mimePart.SetBodyFromBinary(data);

                        if (withBinaryEncodingAttachment)
                        {
                            mimePart.EncodingType = Mime.MimeEncoding.Binary;
                        }
                        else
                        {
                            mimePart.EncodingType = Mime.MimeEncoding.Base64;
                        }
                    }

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
