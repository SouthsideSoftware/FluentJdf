using System;
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf
{
    /// <summary>
    /// Used to build JMF commands 
    /// </summary>
    public class CommandBuilder : JmfBuilderBase, IJmfNodeBuilder {
        string commandType;

        internal  CommandBuilder(JmfNodeBuilder parent, string commandType, string idPrefix = "C") : base(parent) {
            ParameterCheck.StringRequiredAndNotWhitespace(commandType, "commandType");
            ParameterCheck.StringRequiredAndNotWhitespace(idPrefix, "idPrefix");

            this.commandType = commandType;
            
            Element = new XElement(LinqToJdf.Element.Command);
            Element.SetUniqueId(idPrefix);
            Element.SetMessageType(commandType);
            Element.SetXsiType(Command.XsiType(commandType));
            parent.Element.Add(Element);
        }
    }
}
