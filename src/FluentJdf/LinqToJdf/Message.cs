using System;
using System.Xml.Linq;
using FluentJdf.Encoding;
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
        static ILog logger = LogManager.GetLogger(typeof (Message));
        readonly ITransmitterFactory transmitterFactory;

        /// <summary>
        /// Create a message.
        /// </summary>
        /// <returns></returns>
        public static JmfNodeBuilder Create() {
            var message = new Message(Infrastructure.Core.Configuration.Settings.ServiceLocator.Resolve<ITransmitterFactory>());
            return new JmfNodeBuilder(message);
        }

        private Message(ITransmitterFactory transmitterFactory) {
            ParameterCheck.ParameterRequired(transmitterFactory, "transmitterFactory");

            this.transmitterFactory = transmitterFactory;
        }

        /// <summary>
        /// Gets the builder for the root.
        /// </summary>
        /// <returns></returns>
        public JmfNodeBuilder ModifyJmfNode() {
            if (Root == null || Root.Name != LinqToJdf.Element.JMF) {
                throw new Exception(Messages.Message_ModifyJmfNode_RootMustExistAndMustbeJmf);
            }

            return new JmfNodeBuilder(Root);
        }

        /// <summary>
        /// Validate the document.
        /// </summary>
        /// <param name="addSchemaInfo"></param>
        public Message ValidateJmf(bool addSchemaInfo = true)
        {
            validator.Validate(addSchemaInfo);
            return this;
        }

        //todo: add packaging options

        /// <summary>
        /// Transmit this ticket to the given url (string).
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public IJmfResult Transmit(string url)
        {
            ParameterCheck.StringRequiredAndNotWhitespace(url, "url");

            return Transmit(new Uri(url));
        }

        /// <summary>
        /// Transmit this ticket to the given url.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public IJmfResult Transmit(Uri url)
        {
            try
            {
                string name = null;
                if (Root.IsJmfElement())
                {
                    name = string.Format("JMF{0}", MimeTypeHelper.JmfExtension);
                }
                else if (Root.IsJdfElement())
                {
                    name = string.Format("{0}{1}", Root.GetJobId() ?? "JDF", MimeTypeHelper.JdfExtension);
                }
                else
                {
                    name = "XML.xml";
                }
                using (var transmissionPartColllection = new TransmissionPartCollection())
                {
                    transmissionPartColllection.Add(new XmlTransmissionPart(this, name));
                    return transmitterFactory.GetTransmitterForUrl(url).Transmit(url, transmissionPartColllection);
                }
            }
            catch (Exception err)
            {
                logger.Error(string.Format(Messages.Ticket_Transmit_Failed, url), err);
                throw;
            }
        }
    }
}