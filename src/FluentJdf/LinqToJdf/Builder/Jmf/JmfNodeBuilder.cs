using System.Xml.Linq;
using FluentJdf.Configuration;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
    /// <summary>
    /// Factory for creating intent nodes.
    /// </summary>
    public class JmfNodeBuilder : JmfBuilderBase, IJmfNodeBuilder {
        internal JmfNodeBuilder(Message message) {
            Initialize(message);
        }

        void Initialize(Message message) {
            ParameterCheck.ParameterRequired(message, "message");
            if (message.Root != null) {
                message.Root.ThrowExceptionIfNotJmfElement();
            }

            if (message.Root == null) {
                Element = new XElement(LinqToJdf.Element.JMF);
                Element.SetAttributeValue(XNamespace.Xmlns.GetName("xsi"), Globals.XsiNamespace.NamespaceName);
                Element.SetVersion();
                if (Configuration.FluentJdfLibrary.Settings.JdfAuthoringSettings.HasDefaultSenderId) {
                    Element.SetSenderId();
                }
                Element.SetTimeStampToUtcNow();
                message.Add(Element);
            }
            else {
                Element = message.Root;
            }
            ParentJmfNode = this;
        }

        internal JmfNodeBuilder(XElement element) {
            ParameterCheck.ParameterRequired(element, "element");
            element.ThrowExceptionIfNotInMessage();

            Initialize(element.Document as Message);
        }

        /// <summary>
        /// Gets the attribute builder for this JMF node.
        /// </summary>
        /// <returns></returns>
        public JmfNodeAttributeBuilder With() {
            return new JmfNodeAttributeBuilder(this);
        }


    }
}