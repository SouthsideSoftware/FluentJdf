using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf {
    /// <summary>
    /// Extensions for working with xpath.
    /// </summary>
    public static class XPathExtensions {

        /// <summary>
        /// Evaluate an xpath against JDF with optional foreign namespaces.
        /// </summary>
        /// <param name="document">The document to operate upon.</param>
        /// <param name="xpath">The xpath query.</param>
        /// <param name="namespaceManager">Optional namespace manager containing foreign namespace definitions.</param>
        /// <returns>An <see cref="XElement"/>.</returns>
        public static XElement JdfXPathSelectElement(this XNode document, string xpath,
                                                     XmlNamespaceManager namespaceManager = null) {
            return JdfXPathSelectElements(document, xpath, namespaceManager).FirstOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="xPathExpression"></param>
        /// <param name="namespaceManager"></param>
        /// <returns></returns>
        public static XObject JdfXPathSelectObject(this XNode element, string xPathExpression, XmlNamespaceManager namespaceManager = null) {
            var xPath = new XPathDecorator(xPathExpression).PrefixNames("jdf");
            return ((IEnumerable)element.XPathEvaluate(xPath, MakeNamespaceResolver(namespaceManager))).Cast<XObject>().FirstOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="xPathExpression"></param>
        /// <param name="namespaceManager"></param>
        /// <returns></returns>
        public static IEnumerable<XElement> JdfXPathSelectElements(this XNode element, string xPathExpression, XmlNamespaceManager namespaceManager = null) {
            var xPath = new XPathDecorator(xPathExpression).PrefixNames("jdf");
            return element.XPathSelectElements(xPath, MakeNamespaceResolver(namespaceManager));
        }

        /// <summary>
        /// Create an XPath of local names
        /// </summary>
        /// <param name="attribute"></param>
        /// <returns></returns>
        public static string LocalAttributeXPath(this XAttribute attribute) {
            var parentPath = attribute.Parent.LocalElementXPath();
            return parentPath
                + (parentPath.Length > 0 ? "/" : string.Empty)
                + "@"
                + attribute.Name.LocalName;
        }

        private static string MakePrefixedXPath(string xpath) {
            return xpath;
        }
        private static IXmlNamespaceResolver MakeNamespaceResolver(XmlNamespaceManager namespaceManager) {
            var resolver = namespaceManager ?? new XmlNamespaceManager(new NameTable());
            if (!resolver.HasNamespace("jdf")) {
                resolver.AddNamespace("jdf", Globals.JdfNamespace.ToString());
            }
            return resolver;
        }

        /// <summary>
        /// Create an XPath of local names
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string LocalElementXPath(this XElement element) {
            if (element.Parent == null)
                return string.Format("/{0}", element.Name.LocalName);
            var parentPath = element.Parent.LocalElementXPath();
            return parentPath
                + (parentPath.Length > 0 ? "/" : string.Empty)
                + element.Name.LocalName;
        }

        /// <summary>
        /// Evaluate an xpath in an <see cref="XContainer"/> against a selected resource in a selected process by xpath
        /// </summary>
        /// <param name="document">The document to operate upon.</param>
        /// <param name="processXPath">The process xpath</param>
        /// <param name="namespaceManager">The optional namespace manager to be used.  The jdf prefix
        /// will be added if it does not exist and will be for the JDF namespace.</param>
        /// <remarks><para>Process resource xpath allows you
        /// to easily find XObjects within a resource.</para>
        /// <para>Syntax is process:[process]/[resource[@usage=input|output (defaults to input]]/[remaining xpath]</para>
        /// <para>If the "process:" prefix is not provided, regular xpath will be used</para>
        /// <para>The xpath default namespace is the JDF namespace.</para>
        /// <para>The remaining xpath will automatically traverse ref elements.</para></remarks>
        /// <returns>An <see cref="XElement"/>.</returns>
        public static XElement ProcessXPathSelectElement(this XContainer document, string processXPath,
                                                         XmlNamespaceManager namespaceManager = null) {
            return ProcessXPathSelectElements(document, processXPath, namespaceManager).FirstOrDefault();
        }

        /// <summary>
        /// Evaluate an xpath in an <see cref="XContainer"/> against a selected resource in a selected process by xpath
        /// </summary>
        /// <param name="document">The document to operate upon.</param>
        /// <param name="processXPath">The process xpath</param>
        /// <param name="namespaceManager">The optional namespace manager to be used.  The jdf prefix
        /// will be added if it does not exist and will be for the JDF namespace.</param>
        /// <remarks><para>Process resource xpath allows you
        /// to easily find XObjects within a resource.</para>
        /// <para>Syntax is process:[process]/[resource[@usage=input|output (defaults to input]]/[remaining xpath]</para>
        /// <para>If the "process:" prefix is not provided, regular xpath will be used</para>
        /// <para>The xpath default namespace is the JDF namespace.</para>
        /// <para>The remaining xpath will automatically traverse ref elements.</para></remarks>
        /// <returns>An IEnumerable{<see cref="XElement"/>} containing matching <see cref="XElement"/> objects.</returns>
        public static IEnumerable<XElement> ProcessXPathSelectElements(this XNode document, string processXPath,
                                                                       XmlNamespaceManager namespaceManager = null) {
            //process:DigitalPrinting/DigitalPrintingParams[@usage=input]/rest of the xpath executed against JdfXPathSelectElement(s)
            ParameterCheck.ParameterRequired(document, "document");
            Contract.Requires(!string.IsNullOrEmpty(processXPath));

            if (!processXPath.StartsWith("process:")) {
                return document.JdfXPathSelectElements(processXPath, namespaceManager);
            }

            return null;
        }

    }
}