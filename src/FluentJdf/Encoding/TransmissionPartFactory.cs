using System;
using System.IO;
using System.Xml.Linq;
using FluentJdf.Configuration;
using FluentJdf.LinqToJdf;
using FluentJdf.Resources;
using Infrastructure.Core;
using Infrastructure.Core.CodeContracts;
using Infrastructure.Core.Helpers;
using Infrastructure.Core.Logging;

namespace FluentJdf.Encoding {
    /// <summary>
    /// Implementation of transmission part factory.
    /// </summary>
    public class TransmissionPartFactory : ITransmissionPartFactory {
        static ILog logger = LogManager.GetLogger(typeof (TransmissionPartFactory));
        #region ITransmissionPartFactory Members

        /// <summary>
        /// Create a transmission part.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="data"></param>
        /// <param name="mimeType"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public ITransmissionPart CreateTransmissionPart(string name, Stream data, string mimeType, string id = null) {
            ParameterCheck.StringRequiredAndNotWhitespace(name, "name");
            ParameterCheck.ParameterRequired(data, "data");
            ParameterCheck.StringRequiredAndNotWhitespace(mimeType, "mimeType");

            if (mimeType == MimeTypeHelper.XmlMimeType) {
                XDocument doc = null;
                try {
                    if (data.CanSeek) {
                        data.Seek(0, SeekOrigin.Begin);
                    }
                    doc = XDocument.Load(data);
                    var xmlType = doc.XmlType();
                    switch (xmlType) {
                        case XmlType.Jdf:
                            return CreateTransmissionPart(name, doc.ToTicket(), id);
                        case XmlType.Jmf:
                            return CreateTransmissionPart(name, doc.ToMessage(), id);
                        default:
                            return CreateTransmissionPart(name, doc, id);
                    }
                }
                catch (Exception err) {
                    string mess = string.Format(Messages.FailedToLoadXDocumentFromStream);
                    logger.Error(mess, err);
                    throw;
                }
            }

            var transmissionPart = ConstructConfiguredTransmissionPart(mimeType);
            transmissionPart.Initialize(name, data, mimeType, id);

            return transmissionPart;
        }

        ITransmissionPart ConstructConfiguredTransmissionPart(string mimeType) {
            ITransmissionPart transmissionPart;
            if (FluentJdfLibrary.Settings.TransmissionPartSettings.TransmissionPartsByMimeType.ContainsKey(mimeType)) {
                transmissionPart =
                    Infrastructure.Core.Configuration.Settings.ServiceLocator.Resolve<ITransmissionPart>(
                        FluentJdfLibrary.Settings.TransmissionPartSettings.TransmissionPartsByMimeType[mimeType].FullName);
            }
            else {
                transmissionPart =
                    Infrastructure.Core.Configuration.Settings.ServiceLocator.Resolve<ITransmissionPart>(
                        FluentJdfLibrary.Settings.TransmissionPartSettings.DefaultTransmissionPart.FullName);
            }
            return transmissionPart;
        }

        /// <summary>
        /// Creates a transmission part based on an <see cref="XDocument"/>.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="doc"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <remarks>If the root is JDF, the part type registered for the JDF mime type is used.
        /// If the root is JMF, the part type registered for the JMF mime type is used.
        /// Otherwise, the part type registered for the generic xml mime type is used.</remarks>
        public ITransmissionPart CreateTransmissionPart(string name, XDocument doc, string id = null) {
            string mimeType = MimeTypeHelper.XmlMimeType;
            var xmlType = doc.XmlType();
            switch (xmlType)
            {
                case XmlType.Jdf:
                    mimeType = MimeTypeHelper.JdfMimeType;
                    break;
                case XmlType.Jmf:
                    mimeType = MimeTypeHelper.JmfMimeType;
                    break;
            }
            var transmissionPart = ConstructConfiguredTransmissionPart(mimeType);
            if (transmissionPart is IXmlTransmissionPart) {
                ((IXmlTransmissionPart)transmissionPart).InitalizeProperties(doc, name, id);
            } else {
                var tempStream = new TempFileStream();
                doc.Save(tempStream);
                transmissionPart.Initialize(name, tempStream, MimeTypeHelper.XmlMimeType, id);
            }

            return transmissionPart;
        }

        /// <summary>
        /// Creates a transmission part based on a Ticket.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="ticket"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public ITransmissionPart CreateTransmissionPart(string name, Ticket ticket, string id = null)
        {
            var transmissionPart = ConstructConfiguredTransmissionPart(MimeTypeHelper.JdfMimeType);
            if (transmissionPart is ITicketTransmissionPart)
            {
                ((ITicketTransmissionPart)transmissionPart).InitalizeProperties(ticket, name, id);
            }
            else
            {
                var tempStream = new TempFileStream();
                ticket.Save(tempStream);
                transmissionPart.Initialize(name, tempStream, MimeTypeHelper.JdfMimeType, id);
            }

            return transmissionPart;
        }

        /// <summary>
        /// Creates a transmission part based on a Message.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="message"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public ITransmissionPart CreateTransmissionPart(string name, Message message, string id = null)
        {
            var transmissionPart = ConstructConfiguredTransmissionPart(MimeTypeHelper.JmfMimeType);
            if (transmissionPart is IMessageTransmissionPart)
            {
                ((IMessageTransmissionPart)transmissionPart).InitalizeProperties(message, name, id);
            }
            else
            {
                var tempStream = new TempFileStream();
                message.Save(tempStream);
                transmissionPart.Initialize(name, tempStream, MimeTypeHelper.JmfMimeType, id);
            }

            return transmissionPart;
        }

        #endregion
    }
}