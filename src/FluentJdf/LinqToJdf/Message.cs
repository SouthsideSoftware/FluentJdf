using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
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
        static readonly ILog logger = LogManager.GetLogger(typeof(Message));
        readonly ITransmissionPartCollection additionalParts = new TransmissionPartCollection();
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

        internal Message() {
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="document"></param>
        public Message(XDocument document)
            : base(document) {
            document.Root.ThrowExceptionIfNotJmfElement();
        }

        internal ITransmissionPartCollection AdditionalParts {
            get {
                return additionalParts;
            }
        }

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
            get {
                return MessageElements.FirstOrDefault();
            }
        }

        /// <summary>
        /// Create a message from a template in a file.
        /// </summary>
        /// <param name="templateFileName"></param>
        /// <returns></returns>
        public static GeneratedMessageTemplateSelectionBuilder CreateFromTemplate(string templateFileName) {
            return new GeneratedMessageTemplateSelectionBuilder(templateFileName);
        }

        /// <summary>
        /// Create a message from a template in a stream.
        /// </summary>
        /// <param name="templateStream"></param>
        /// <returns></returns>
        public static GeneratedMessageTemplateSelectionBuilder CreateFromTemplate(Stream templateStream) {
            return new GeneratedMessageTemplateSelectionBuilder(templateStream);
        }

        /// <summary>
        /// Add a related transmission part.
        /// </summary>
        /// <param name="transmissionPart"></param>
        public void AddRelatedPart(ITransmissionPart transmissionPart) {
            ParameterCheck.ParameterRequired(transmissionPart, "transmissionPart");

            additionalParts.Add(transmissionPart);
        }

        /// <summary>
        /// Create a message.
        /// </summary>
        /// <returns></returns>
        public static JmfNodeBuilder Create() {
            var message = new Message();
            return new JmfNodeBuilder(message);
        }

        /// <summary>
        /// Loads the message from a stream.
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public new static Message Load(Stream stream) {
            return XDocument.Load(stream).ToMessage();
        }

        /// <summary>
        /// Loads the message from a stream.
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public new static Message Load(Stream stream, LoadOptions options) {
            return XDocument.Load(stream, options).ToMessage();
        }

        /// <summary>
        /// Load a message from a TextReader
        /// </summary>
        /// <param name="textReader"></param>
        /// <returns></returns>
        public new static Message Load(TextReader textReader) {
            return XDocument.Load(textReader).ToMessage();
        }

        /// <summary>
        /// Load a message from a TextReader
        /// </summary>
        /// <param name="textReader"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public new static Message Load(TextReader textReader, LoadOptions options) {
            return XDocument.Load(textReader, options).ToMessage();
        }

        /// <summary>
        /// Load a message from a XmlReader
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public new static Message Load(XmlReader reader) {
            return XDocument.Load(reader).ToMessage();
        }

        /// <summary>
        /// Load a message from a XmlReader
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public new static Message Load(XmlReader reader, LoadOptions options) {
            return XDocument.Load(reader, options).ToMessage();
        }

        /// <summary>
        /// Loads the message from a file.
        /// </summary>
        /// <returns></returns>
        public new static Message Load(string uri) {
            return new Message(XDocument.Load(uri));
        }

        /// <summary>
        /// Loads the message from a file.
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public new static Message Load(string uri, LoadOptions options) {
            return new Message(XDocument.Load(uri, options));
        }

        /// <summary>
        /// Parses xml into a message.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public new static Message Parse(string text) {
            return XDocument.Parse(text).ToMessage();
        }

        /// <summary>
        /// Parses xml into a message.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public new static Message Parse(string text, LoadOptions options) {
            return XDocument.Parse(text, options).ToMessage();
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
                //todo: add packaging options

                string name = string.Format("JMF{0}", MimeTypeHelper.JmfExtension);
                using (var transmissionPartCollection = new TransmissionPartCollection()) {
                    transmissionPartCollection.Add(new MessageTransmissionPart(this, name));
                    transmissionPartCollection.AddRange(additionalParts);
                    return transmitterFactory.GetTransmitterForUrl(url).Transmit(url, transmissionPartCollection);
                }
            }
            catch (Exception err) {
                logger.Error(string.Format(Messages.Ticket_Transmit_Failed, url), err);
                throw;
            }
        }
    }
}