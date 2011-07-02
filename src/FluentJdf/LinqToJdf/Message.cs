using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using FluentJdf.Encoding;
using FluentJdf.LinqToJdf.Builder.Jmf;
using FluentJdf.Messaging;
using FluentJdf.Resources;
using FluentJdf.Transmission;
using Infrastructure.Core.CodeContracts;
using Infrastructure.Core.Helpers;
using Infrastructure.Core.Logging;

namespace FluentJdf.LinqToJdf {
    /// <summary>
    /// A JMF message.
    /// </summary>
    public class Message : FluentJdfDocumentBase {
        static readonly ILog logger = LogManager.GetLogger(typeof (Message));
        readonly ITransmitterFactory transmitterFactory = Infrastructure.Core.Configuration.Settings.ServiceLocator.Resolve<ITransmitterFactory>();

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="source"></param>
        public Message(Message source) {
            ParameterCheck.ParameterRequired(source, "source");

            if (source.Root != null) {
                Add(new XElement(source.Root));
            }
        }

        internal Message() {}

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="document"></param>
        public Message(XDocument document) : base(document) {
            document.Root.ThrowExceptionIfNotJmfElement();
        }

        /// <summary>
        /// Gets the JDF ticket (if any) associated with this message.
        /// </summary>
        public Ticket AssociatedTicket { get; internal set; }

        /// <summary>
        /// Gets a list of the message names (i.e. command, query etc.) contained in this message tree.
        /// </summary>
        public IEnumerable<XName> MessageNames {
            get {
                if (Root == null) {
                    return new List<XName>();
                }

                return Root.GetMessageNames();
            }
        }

        /// <summary>
        /// Gets a list of the message elements (i.e. command, query etc.) contained
        /// in this message tree.
        /// </summary>
        public IEnumerable<XElement> MessageElements {
            get {
                if (Root == null) {
                    return new List<XElement>();
                }

                return Root.GetMessageElements();
            }
        }

        /// <summary>
        /// Gets the first message element (or <see langword="null"/> if there are none).
        /// </summary>
        public XElement MessageElement {
            get { return MessageElements.FirstOrDefault(); }
        }

        /// <summary>
        /// Create a message.
        /// </summary>
        /// <returns></returns>
        public static JmfNodeBuilder Create() {
            var message = new Message();
            return new JmfNodeBuilder(message);
        }

        //todo: implement remainder of load and parse here and in Ticket class (issue #33)
        /// <summary>
        /// Loads the message from a stream.
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public new static Message Load(Stream stream) {
            return XDocument.Load(stream).ToMessage();
        }

        /// <summary>
        /// Parses xml into a message.
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public new static Message Parse(string xml) {
            return XDocument.Parse(xml).ToMessage();
        }

        /// <summary>
        /// Gets the builder for the root.
        /// </summary>
        /// <returns></returns>
        public JmfNodeBuilder ModifyJmfNode() {
            if (Root == null || !Root.IsJmfElement()) {
                throw new Exception(Messages.Message_ModifyJmfNode_RootMustExistAndMustbeJmf);
            }

            return new JmfNodeBuilder(Root);
        }

        /// <summary>
        /// Validate the document.
        /// </summary>
        /// <param name="addSchemaInfo"></param>
        public Message ValidateJmf(bool addSchemaInfo = true) {
            validator.Validate(addSchemaInfo);
            return this;
        }

        //todo: add packaging options

        /// <summary>
        /// Transmit this ticket to the given url (string).
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public IJmfResult Transmit(string url) {
            ParameterCheck.StringRequiredAndNotWhitespace(url, "url");

            return Transmit(new Uri(url));
        }

        /// <summary>
        /// Transmit this ticket to the given url.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public IJmfResult Transmit(Uri url) {
            try {
                string name = null;
                if (Root.IsJmfElement()) {
                    name = string.Format("JMF{0}", MimeTypeHelper.JmfExtension);
                }
                else if (Root.IsJdfElement()) {
                    name = string.Format("{0}{1}", Root.GetJobId() ?? "JDF", MimeTypeHelper.JdfExtension);
                }
                else {
                    name = "XML.xml";
                }
                using (var transmissionPartColllection = new TransmissionPartCollection()) {
                    transmissionPartColllection.Add(new XmlTransmissionPart(this, name));
                    return transmitterFactory.GetTransmitterForUrl(url).Transmit(url, transmissionPartColllection);
                }
            }
            catch (Exception err) {
                logger.Error(string.Format(Messages.Ticket_Transmit_Failed, url), err);
                throw;
            }
        }
    }
}