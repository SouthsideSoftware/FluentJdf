using System.Xml.Linq;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.Schema.FluentValidation {
    public static class Element {
        static readonly XNamespace JdfNamespace = "http://www.CIP4.org/JDFSchema_1_1";

        public static XName Jdf = JdfNamespace.GetName("JDF");
        public static XName ResourcePool = JdfNamespace.GetName("ResourcePool");
        public static XName ResourceLinkPool = JdfNamespace.GetName("ResourceLinkPool");
        public static XName Component = JdfNamespace.GetName("Component");

        public static XName Link(this XName resourceName) {
            return XName.Get(resourceName.LocalName + "Link", resourceName.NamespaceName);
        }
    }

    public static class TestAuthoring {
        static readonly XNamespace XsiNamespace = "http://www.w3.org/2001/XMLSchema-instance";

        public static XDocument GetTicket() {
            return new XDocument(
                new XElement(Element.Jdf,
                             new XAttribute("Type", "Product"),
                             new XAttribute(XsiNamespace.GetName("type"), "Product"),
                             new XAttribute("ID", "MyId"),
                             new XAttribute("JobID", "MyJobId"),
                             new XElement(Element.ResourcePool,
                                          new XElement(Element.Component,
                                                       new XAttribute("ID", "component1"))),
                             new XElement(Element.ResourceLinkPool,
                                          new XElement(Element.Component.Link(),
                                                       new XAttribute("Usage", "Output"),
                                                       new XAttribute("rRef", "component1")))));
        }
    }

    [Subject("Demo")]
    [Ignore("just for demo and scratch testing")]
    public class when_demonstrating {
        static Ticket ticket;
        static XDocument document;


        Because of = () => {
            document = TestAuthoring.GetTicket();
            document.Save(@"\logs\doc.jdf");


            ticket = Ticket.CreateIntent().WithInput().Component().Ticket;
            ticket.Save(@"\logs\fluent.jdf");

            var doc = new XDocument();
            doc.Add(new XElement(FluentJdf.LinqToJdf.Element.JDF));

            Message.Create().AddCommand().SubmitQueueEntry();

            // var doc = new XDocument(new XElement(XName.Get("JDF", "http://www.CIP4.org/JDFSchema_1_1", new XAttribute("JobID"))));
            //ticket.Save(@"c:\logs\test2.jdf");
        };

        It should_save = () => ticket.ValidateJdf().Save(@"\logs\test.jdf");
    }
}