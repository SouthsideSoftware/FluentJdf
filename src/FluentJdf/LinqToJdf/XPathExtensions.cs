using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using Infrastructure.Core.CodeContracts;
using System;

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
        public static XElement JdfXPathSelectElement(this XContainer document, string xpath,
                                                     XmlNamespaceManager namespaceManager = null) {
            return JdfXPathSelectElements(document, xpath, namespaceManager).FirstOrDefault();
        }

        /// <summary>
        /// Evaluate an xpath against JDF with optional foreign namespaces.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="xPathExpression"></param>
        /// <param name="namespaceManager"></param>
        /// <returns></returns>
        public static IEnumerable<XElement> JdfXPathSelectElements(this XContainer element, string xPathExpression,
            XmlNamespaceManager namespaceManager = null) {

            ParameterCheck.ParameterRequired(element, "element");
            ParameterCheck.StringRequiredAndNotWhitespace(xPathExpression, "xPathExpression");

            var xPath = new XPathDecorator(xPathExpression).PrefixNames("jdf");

            using (var normalizer = new RefExtensionsNormalizer(element)) {
                return normalizer.Node.XPathSelectElements(xPath, MakeNamespaceResolver(namespaceManager)).ToList(); //can't be lazy
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="xPathExpression"></param>
        /// <param name="namespaceManager"></param>
        /// <returns></returns>
        public static XObject JdfXPathSelectObject(this XContainer element, string xPathExpression,
            XmlNamespaceManager namespaceManager = null) {

            ParameterCheck.ParameterRequired(element, "element");
            ParameterCheck.StringRequiredAndNotWhitespace(xPathExpression, "xPathExpression");

            var xPath = new XPathDecorator(xPathExpression).PrefixNames("jdf");
            return ((IEnumerable)element.XPathEvaluate(xPath, MakeNamespaceResolver(namespaceManager))).Cast<XObject>().FirstOrDefault();
        }

        /// <summary>
        /// Create an XPath of local names
        /// </summary>
        /// <param name="attribute"></param>
        /// <returns></returns>
        public static string LocalAttributeXPath(this XAttribute attribute) {
            ParameterCheck.ParameterRequired(attribute, "attribute");

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
            ParameterCheck.ParameterRequired(element, "element");

            if (element.Parent == null)
                return string.Format("/{0}", element.Name.LocalName);
            var parentPath = element.Parent.LocalElementXPath();
            return parentPath
                + (parentPath.Length > 0 ? "/" : string.Empty)
                + element.Name.LocalName;
        }

#pragma warning disable 0618

        /// <summary>
        /// Evaluate an xpath in an <see cref="XContainer"/> against a selected resource in a selected process by xpath
        /// </summary>
        /// <param name="document">The document to operate upon.</param>
        /// <param name="processXPath">The process xpath</param>
        /// <param name="namespaceManager">The optional namespace manager to be used.  The jdf prefix
        /// will be added if it does not exist and will be for the JDF namespace.</param>
        /// <remarks><para>Process resource xpath allows you
        /// to easily find XObjects within a resource.</para>
        /// <para>Syntax is process:[process]/[resource[@usage=input|output (defaults to input)]]/[remaining xpath]</para>
        /// <para>If the "process:" prefix is not provided, regular xpath will be used</para>
        /// <para>The xpath default namespace is the JDF namespace.</para>
        /// <para>The remaining xpath will automatically traverse ref elements.</para></remarks>
        /// <returns>An <see cref="XElement"/>.</returns>
        [Obsolete("Use new Fluent interface Ticket.GetProcess()")]
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
        /// <para>Syntax is process:[process]/[resource[@usage=input|output (defaults to input)]]/[remaining xpath]</para>
        /// <para>If the "process:" prefix is not provided, regular xpath will be used</para>
        /// <para>The xpath default namespace is the JDF namespace.</para>
        /// <para>The remaining xpath will automatically traverse ref elements.</para></remarks>
        /// <returns>An IEnumerable{<see cref="XElement"/>} containing matching <see cref="XElement"/> objects.</returns>
        [Obsolete("Use new Fluent interface Ticket.GetProcess()")]
        public static IEnumerable<XElement> ProcessXPathSelectElements(this XContainer document, string processXPath,
                                                                       XmlNamespaceManager namespaceManager = null) {
            //process:DigitalPrinting/DigitalPrintingParams[@usage=input]/rest of the xpath executed against JdfXPathSelectElement(s)
            ParameterCheck.ParameterRequired(document, "document");
            ParameterCheck.StringRequiredAndNotWhitespace(processXPath, "processXPath");

            if (!processXPath.StartsWith(ProcessXPathParser.PROCESS)) {
                foreach (var item in document.JdfXPathSelectElements(processXPath, namespaceManager)) {
                    yield return item;
                }
            }
            else {
                var parser = ProcessXPathParser.Parse(processXPath);
                var processElements = document.GetJdfNodesContainingProcessType(parser.ProcessName);
                foreach (var processElement in processElements) {
                    var link = processElement.GetResourceLinkPoolResolvedItem(parser.ResourceName, parser.ResourceUsage);
                    if (link != null) {
                        if (!string.IsNullOrWhiteSpace(parser.XPathStatement)) {
                            //You must wrap the document in the normalizer or you may not obtain the xml correctly.
                            using (var resolver = new RefExtensionsNormalizer(processElement)) {
                                var xPath = new XPathDecorator(parser.XPathStatement).PrefixNames("jdf");
                                foreach (var item in link.XPathSelectElements(xPath, MakeNamespaceResolver(namespaceManager))) {
                                    yield return item;
                                }
                            }
                        }
                        else {
                            yield return link;
                        }
                    }
                }
            }
        }

#pragma warning restore 0618

        /// <summary>
        /// Traverse the JDF structure and auto resolve the Ref elements if needed to return the expected node.
        /// </summary>
        /// <remarks>
        /// To allow for fluent walking, we allow the element to be null, we will just return right away.
        /// </remarks>
        /// <param name="elements">The elements to begin walking</param>
        /// <param name="name">The name of the resource to find</param>
        /// <param name="traverseRefs">if we should look for ref elements or just walk the name explicitly.</param>
        /// <returns></returns>
        public static XElement SelectJDFDescendant(this IEnumerable<XContainer> elements, XName name, bool traverseRefs = true) {
            ParameterCheck.ParameterRequired(elements, "elements");
            return SelectJDFDescendants(elements, name, traverseRefs).FirstOrDefault();
        }

        /// <summary>
        /// Traverse the JDF structure and auto resolve the Ref elements if needed to return the expected node.
        /// </summary>
        /// <remarks>
        /// To allow for fluent walking, we allow the element to be null, we will just return right away.
        /// </remarks>
        /// <param name="element">The element to begin walking</param>
        /// <param name="name">The name of the resource to find</param>
        /// <param name="traverseRefs">if we should look for ref elements or just walk the name explicitly.</param>
        /// <returns></returns>
        public static XElement SelectJDFDescendant(this XContainer element, XName name, bool traverseRefs = true) {
            if (element == null) {
                return null;
            }
            return SelectJDFDescendants(element, name, traverseRefs).FirstOrDefault();
        }

        /// <summary>
        /// Traverse the JDF structure and auto resolve the Ref elements if needed to return the expected node.
        /// </summary>
        /// <remarks>
        /// To allow for fluent walking, we allow the element to be null, we will just return right away.
        /// </remarks>
        /// <param name="elements">The elements to begin walking</param>
        /// <param name="name">The name of the resource to find</param>
        /// <param name="traverseRefs">if we should look for ref elements or just walk the name explicitly.</param>
        /// <returns></returns>
        public static IEnumerable<XElement> SelectJDFDescendants(this IEnumerable<XContainer> elements, XName name, bool traverseRefs = true) {
            ParameterCheck.ParameterRequired(elements, "elements");
            foreach (var element in elements) {
                foreach (var result in SelectJDFDescendants(element, name, traverseRefs)) {
                    yield return result;
                }
            }
        }

        /// <summary>
        /// Traverse the JDF structure and auto resolve the Ref elements if needed to return the expected node.
        /// </summary>
        /// <remarks>
        /// To allow for fluent walking, we allow the element to be null, we will just return right away.
        /// </remarks>
        /// <param name="element">The element to begin walking</param>
        /// <param name="name">The name of the resource to find</param>
        /// <param name="traverseRefs">if we should look for ref elements or just walk the name explicitly.</param>
        /// <returns></returns>
        public static IEnumerable<XElement> SelectJDFDescendants(this XContainer element, XName name, bool traverseRefs = true) {
            ParameterCheck.ParameterRequired(name, "name");

            if (element == null) {
                yield break;
            }

            string xPath;
            if (traverseRefs) {
                xPath = string.Format(@".//jdf:{0} | .//jdf:{0}Ref", name.LocalName);
            }
            else {
                xPath = string.Format(@".//jdf:{0}", name.LocalName);
            }

            var resolver = MakeNamespaceResolver(null);

            foreach (var item in element.XPathSelectElements(xPath, resolver)) {
                if (item.Name.LocalName.EndsWith("Ref")) {
                    var rRef = item.GetRefId();

                    var retVal = item.GetResourceOrNull(rRef);
                    if (retVal != null) {
                        yield return retVal;
                    }
                }
                else {
                    yield return item;
                }
            }
        }
    }
}