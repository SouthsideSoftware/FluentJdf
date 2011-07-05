using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using FluentJdf.LinqToJdf;
using FluentJdf.Resources;
using FluentJdf.Utility;
using Infrastructure.Core;
using Infrastructure.Core.CodeContracts;
using Infrastructure.Core.Logging;

namespace FluentJdf.Encoding {
    /// <summary>
    /// A transmission part that holds a JMF message.
    /// </summary>
    public class MessageTransmissionPart : IMessageTransmissionPart {
        static readonly ILog logger = LogManager.GetLogger(typeof (MessageTransmissionPart));

        /// <summary>
        /// This constructor for use by factories.  Should not
        /// be called from user code.
        /// </summary>
        public MessageTransmissionPart() {
            
        }

        /// <summary>
        /// Construct a part from a message
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="name"></param>
        /// <param name="id"></param>
        public MessageTransmissionPart(XDocument doc, string name, string id = null) : this(doc.ToMessage(), name, id)
        {
        }

        /// <summary>
        /// Construct a part from a message
        /// </summary>
        /// <param name="message"></param>
        /// <param name="name"></param>
        /// <param name="id"></param>
        public MessageTransmissionPart(Message message, string name, string id = null) {
            ParameterCheck.ParameterRequired(message, "message");
            ParameterCheck.StringRequiredAndNotWhitespace(name, "name");

            InitalizeProperties(message, name, id);
        }

        /// <summary>
        /// Creates a transmission part from the given file name.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="id"></param>
        /// <exception cref="ArgumentException">If the named file does not exist.</exception>
        public MessageTransmissionPart(string fileName, string id = null) {
            ParameterCheck.StringRequiredAndNotWhitespace(fileName, "fileName");

            if (!File.Exists(fileName)) {
                throw new ArgumentException(string.Format(Messages.TransmissionPart_CannotCreatePartAsFileDoesNotExist, fileName));
            }

            Message message = null;
            try {
                message = Message.Load(fileName);
            }
            catch (Exception err) {
                string mess = string.Format(Messages.XmlTransmissionPart_FailedToLoadXDocumentFromFile, fileName);
                logger.Error(mess, err);
                throw;
            }
            InitalizeProperties(message, message.MimeType(), id);
        }

        /// <summary>
        /// Creates a transmission part from the given stream. The source
        /// stream is disposed by the constructor.
        /// </summary>
        /// <remarks>mimeType is ignored.  It is taken from the parsed xml root node.</remarks>
        public MessageTransmissionPart(Stream sourceStream, string name, string mimeType = null, string id = null) {
            ParameterCheck.ParameterRequired(sourceStream, "sourceStream");
            ParameterCheck.StringRequiredAndNotWhitespace(name, "name");

            if (sourceStream.CanSeek) {
                sourceStream.Seek(0, SeekOrigin.Begin);
            }
            Message message = null;
            try {
                message = Message.Load(sourceStream);
            }
            catch (Exception err) {
                string mess = string.Format(Messages.FailedToLoadXDocumentFromStream);
                logger.Error(mess, err);
                throw;
            }
            InitalizeProperties(message, message.MimeType(), id);
        }

        #region IXmlTransmissionPart Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Gets the stream associated with the part.
        /// </summary>
        public Stream CopyOfStream() {
            var tempStream = new TempFileStream();
            Message.SaveHttpReady(tempStream);
            tempStream.Seek(0, SeekOrigin.Begin);
 
            return tempStream;
        }

        /// <summary>
        /// Gets the name of the part.  May not be unique.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the id of the part.  Must be unique
        /// within the context of all parts in a single
        /// collection.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets the mime type of the part.
        /// </summary>
        public string MimeType { get; private set; }

        /// <summary>
        /// Initialize an instance from the factory.
        /// </summary>
        /// <remarks>This ignores mime type because it is determined by xml content.</remarks>
        public void Initialize(string name, Stream stream, string mimeType, string id) {
            ParameterCheck.StringRequiredAndNotWhitespace(name, "name");
            ParameterCheck.ParameterRequired(stream, "stream");
            ParameterCheck.StringRequiredAndNotWhitespace(mimeType, "mimeType");

            if (stream.CanSeek)
            {
                stream.Seek(0, SeekOrigin.Begin);
            }

            InitalizeProperties(Message.Load(stream), name, id);
        }

        /// <summary>
        /// Gets the message for the transmission part.
        /// </summary>
        public Message Message { get; private set; }

        #endregion

        /// <summary>
        /// Initialize the properties.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="name"></param>
        /// <param name="id"></param>
        public void InitalizeProperties(Message message, string name, string id) {
            if (string.IsNullOrWhiteSpace(id)) {
                id = string.Format("P_{0}", UniqueGenerator.MakeUnique());
            }

            Name = name;
            MimeType = message.MimeType();
            Id = id;
            Message = message;
        }

        /// <summary>
        /// Override this to change disposal behavior.
        /// </summary>
        /// <param name="isDisposing"></param>
        protected virtual void Dispose(bool isDisposing) {}
    }
}