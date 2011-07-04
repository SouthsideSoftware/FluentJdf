using System;
using System.IO;
using System.Xml.Linq;
using FluentJdf.LinqToJdf;
using FluentJdf.Resources;
using FluentJdf.Utility;
using Infrastructure.Core;
using Infrastructure.Core.CodeContracts;
using Infrastructure.Core.Logging;

namespace FluentJdf.Encoding {
    /// <summary>
    /// A transmission part that holds a JDF ticket.
    /// </summary>
    public class TicketTransmissionPart : ITicketTransmissionPart {
        static readonly ILog logger = LogManager.GetLogger(typeof (TicketTransmissionPart));

        /// <summary>
        /// This constructor for use by factories.  Should not
        /// be called from user code.
        /// </summary>
        public TicketTransmissionPart() {
            
        }

        /// <summary>
        /// Construct a part from a ticket
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="name"></param>
        /// <param name="id"></param>
        public TicketTransmissionPart(XDocument doc, string name, string id = null) : this(doc.ToTicket(), name, id)
        {
        }

        /// <summary>
        /// Construct a part from a ticket
        /// </summary>
        /// <param name="ticket"></param>
        /// <param name="name"></param>
        /// <param name="id"></param>
        public TicketTransmissionPart(Ticket ticket, string name, string id = null) {
            ParameterCheck.ParameterRequired(ticket, "ticket");
            ParameterCheck.StringRequiredAndNotWhitespace(name, "name");

            InitalizeProperties(ticket, name, id);
        }

        /// <summary>
        /// Creates a transmission part from the given file name.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="id"></param>
        /// <exception cref="ArgumentException">If the named file does not exist.</exception>
        public TicketTransmissionPart(string fileName, string id = null) {
            ParameterCheck.StringRequiredAndNotWhitespace(fileName, "fileName");

            if (!File.Exists(fileName)) {
                throw new ArgumentException(string.Format(Messages.TransmissionPart_CannotCreatePartAsFileDoesNotExist, fileName));
            }

            Ticket ticket = null;
            try {
                ticket = Ticket.Load(fileName);
            }
            catch (Exception err) {
                string mess = string.Format(Messages.XmlTransmissionPart_FailedToLoadXDocumentFromFile, fileName);
                logger.Error(mess, err);
                throw;
            }
            InitalizeProperties(ticket, ticket.MimeType(), id);
        }

        /// <summary>
        /// Creates a transmission part from the given stream. The source
        /// stream is disposed by the constructor.
        /// </summary>
        /// <remarks>mimeType is ignored.  It is taken from the parsed xml root node.</remarks>
        public TicketTransmissionPart(Stream sourceStream, string name, string mimeType = null, string id = null) {
            ParameterCheck.ParameterRequired(sourceStream, "sourceStream");
            ParameterCheck.StringRequiredAndNotWhitespace(name, "name");

            if (sourceStream.CanSeek) {
                sourceStream.Seek(0, SeekOrigin.Begin);
            }
            Ticket ticket = null;
            try {
                ticket = Ticket.Load(sourceStream);
            }
            catch (Exception err) {
                string mess = string.Format(Messages.XmlTransmissionPart_FailedToLoadXDocumentFromStream);
                logger.Error(mess, err);
                throw;
            }
            InitalizeProperties(ticket, ticket.MimeType(), id);
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
            Ticket.Save(tempStream);
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

            InitalizeProperties(Ticket.Load(stream), name, id);
        }

        /// <summary>
        /// Gets the ticket for the transmission part.
        /// </summary>
        public Ticket Ticket { get; private set; }

        #endregion

        void InitalizeProperties(Ticket ticket, string name, string id) {
            if (string.IsNullOrWhiteSpace(id)) {
                id = string.Format("P_{0}", UniqueGenerator.MakeUnique());
            }

            Name = name;
            MimeType = ticket.MimeType();
            Id = id;
            Ticket = ticket;
        }

        /// <summary>
        /// Override this to change disposal behavior.
        /// </summary>
        /// <param name="isDisposing"></param>
        protected virtual void Dispose(bool isDisposing) {}
    }
}