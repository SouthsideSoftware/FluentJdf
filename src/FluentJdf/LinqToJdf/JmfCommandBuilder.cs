using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using FluentJdf.Utility;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf
{
    /// <summary>
    /// Used to build JMF commands 
    /// </summary>
    public class JmfCommandBuilder : JmfNodeBuilderBase {
        string commandType;

        internal  JmfCommandBuilder(JmfNodeBuilder parent, string commandType) : base(parent) {
            ParameterCheck.StringRequiredAndNotWhitespace(commandType, "commandType");

            this.commandType = commandType;
            
            Element = new XElement(Command.SubmitQueueEntry);
            Element.SetAttributeValue("ID", Globals.CreateUniqueId("C_"));
            Element.SetAttributeValue("Type", commandType);
            Element.SetXsiType(Command.XsiTypeOfCommand(commandType));
            parent.Element.Add(Element);
        }
    }
}
