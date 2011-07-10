using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;
using System.Xml;

namespace FluentJdf.LinqToJdf {

    //WARNING WARNING WARNING WARNING WARNING WARNING WARNING WARNING WARNING WARNING WARNING WARNING 
    //Proof of concept. this is not intended to be used in the final release.
    //WARNING WARNING WARNING WARNING WARNING WARNING WARNING WARNING WARNING WARNING WARNING WARNING 

    /*
     
    Ticket.GetProcess().Bending(); This gets first bending process. 

    Ticket.GetProcesses().Bending(); This gets an enumerator over bending processes. MAYBE LATER?

    Ticket.GetProcess().Named(my xustom xname); This gets a named process.

    Ticket.GetProcesses().Named(my custom xname); This gets an enumerator over named processes. MAYBE LATER?

    Ticket.GetProcess().Named(ProcessType.Bending); This gets bending too since that is the xname for Bending in the JDF namespace.

    Ticket.GetProcess().Bending().WithInput().RunList() This gets the first run list resource that is an input of the first bending.

    Ticket().GetProcess().Bending().WithInputs().RunList() This gets all run list resources that are an input of the first bending. MAYBE LATER.

    You can always stick SelectJDFDescendant(s) onto the end of one of these. Obviously, anything involving a return that is more than one 
    element makes everything more complicated. That's why I indicated we might defer those into another issue to be tackled later.    
    */

    /// <summary>
    /// Extension methods for <see cref="Ticket"/> Class for GetProcess()
    /// </summary>
    public static class TicketGetProcessExtensions {

        /// <summary>
        /// Get Process
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns></returns>
        public static TicketGetProcess GetProcess(this Ticket ticket) {
            ParameterCheck.ParameterRequired(ticket, "ticket");
            return new TicketGetProcess(ticket);
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public class TicketGetProcess {

        Ticket _ticket;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="ticket"></param>
        public TicketGetProcess(Ticket ticket) {
            ParameterCheck.ParameterRequired(ticket, "ticket");
            _ticket = ticket;
        }

        //named item
        //TODO generate the other items.

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public TicketProcess Bending() {
            return Named(ProcessType.Bending);
        }

        //ProcessType.Bending.

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public TicketProcess Named(XName name) {
            ParameterCheck.ParameterRequired(name, "name");
            var processElements = _ticket.GetJdfNodesContainingProcessType(name.LocalName);
            
            return new TicketProcess(_ticket, processElements.First());
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public class TicketProcess {

        Ticket _ticket;
        XElement _element;

        /// <summary>
        /// The element
        /// </summary>
        public XElement Element {
            get {
                return _element;
            }
        }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="ticket"></param>
        /// <param name="element"></param>
        public TicketProcess(Ticket ticket, XElement element) {
            ParameterCheck.ParameterRequired(ticket, "ticket");
            ParameterCheck.ParameterRequired(element, "element");
            _ticket = ticket;
            _element = element;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public TicketResouces WithInput() {
            var link = Element.GetResourceLinkPoolResolvedItemForUsage(ResourceUsage.Input);

            var first = link.FirstOrDefault();
            if (first == null) {
                return null; //todo do we just return am empty item so we don't get a null ref?
            }
            return new TicketResouces(_ticket, first);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        public TicketResouces WithInput(XName resourceName) {
            var link = Element.GetResourceLinkPoolResolvedItemForUsage(ResourceUsage.Input);

            var first = link.FirstOrDefault(item => item.Name != null && item.Name.LocalName == resourceName);
            if (first == null) {
                return null; //todo do we just return am empty item so we don't get a null ref?
            }
            return new TicketResouces(_ticket, first);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public TicketResouces WithOutput() {
            var link = Element.GetResourceLinkPoolResolvedItemForUsage(ResourceUsage.Output);

            var first = link.FirstOrDefault();
            if (first == null) {
                return null; //todo do we just return am empty item so we don't get a null ref?
            }
            return new TicketResouces(_ticket, first);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        public TicketResouces WithOutput(XName resourceName) {
            var link = Element.GetResourceLinkPoolResolvedItemForUsage(ResourceUsage.Output);

            var first = link.FirstOrDefault(item => item.Name != null && item.Name.LocalName == resourceName);
            if (first == null) {
                return null; //todo do we just return am empty item so we don't get a null ref?
            }
            return new TicketResouces(_ticket, first);
        }

        //private static IEnumerable<XElement> ProcessXPathSelectElements(Ticket document, string processName) {
        //    //process:DigitalPrinting/DigitalPrintingParams[@usage=input]/rest of the xpath executed against JdfXPathSelectElement(s)
        //    ParameterCheck.ParameterRequired(document, "document");
        //    ParameterCheck.StringRequiredAndNotWhitespace(processName, "processXPath");

        //    var processElements = document.GetJdfNodesContainingProcessType(processName);
        //    foreach (var processElement in processElements) {
        //        var link = processElement.GetResourceLinkPoolResolvedItem(parser.ResourceName, parser.ResourceUsage);
        //        if (link != null) {
        //            if (!string.IsNullOrWhiteSpace(parser.XPathStatement)) {
        //                //You must wrap the document in the normalizer or you may not obtain the xml correctly.
        //                using (var resolver = new RefExtensionsNormalizer(processElement)) {
        //                    var xPath = new XPathDecorator(parser.XPathStatement).PrefixNames("jdf");
        //                    foreach (var item in link.XPathSelectElements(xPath, MakeNamespaceResolver(namespaceManager))) {
        //                        yield return item;
        //                    }
        //                }
        //            }
        //            else {
        //                yield return link;
        //            }
        //        }
        //    }
        //}
    }

    /// <summary>
    /// 
    /// </summary>
    public class TicketResouces {

        Ticket _ticket;
        XElement _element;

        /// <summary>
        /// The element
        /// </summary>
        public XElement Element {
            get {
                return _element;
            }
        }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="ticket"></param>
        /// <param name="element"></param>
        public TicketResouces(Ticket ticket, XElement element) {
            ParameterCheck.ParameterRequired(ticket, "ticket");
            ParameterCheck.ParameterRequired(element, "element");
            _ticket = ticket;
            _element = element;
        }
    }

}
