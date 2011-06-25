using System;
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
    /// <summary>
    /// Used to build JMF commands 
    /// </summary>
    public class QueryBuilder : JmfBuilderBase, IJmfNodeBuilder {
        string queryType;

        internal  QueryBuilder(JmfNodeBuilder parent, string queryType, string idPrefix = "Q") : base(parent) {
            ParameterCheck.StringRequiredAndNotWhitespace(queryType, "queryType");
            ParameterCheck.StringRequiredAndNotWhitespace(idPrefix, "idPrefix");

            this.queryType = queryType;
            
            Element = new XElement(LinqToJdf.Element.Query);
            Element.SetUniqueId(idPrefix);
            Element.SetMessageType(queryType);
            Element.SetXsiType(Query.XsiType(queryType));
            parent.Element.Add(Element);
        }
    }
}