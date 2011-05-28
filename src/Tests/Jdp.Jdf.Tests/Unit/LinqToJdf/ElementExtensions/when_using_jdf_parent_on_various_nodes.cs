using System;
using System.Xml.Linq;
using Jdp.Jdf.LinqToJdf;
using Machine.Specifications;

namespace Jdp.Jdf.Tests.Unit.LinqToJdf.ElementExtensions {
    [Subject(typeof (Jdf.LinqToJdf.ElementExtensions))]
    public class when_using_jdf_parent_on_various_nodes {
        static XDocument ticket;
        static XElement elementWithoutJdf;
        static Exception exception;

        Establish content = () => {
                                ticket = Ticket.Create().AddItentNode().ResourcePool().Parent.AddItentNode().ResourceLinkPool().Document;
                                elementWithoutJdf = new XElement(Element.RivetsExposed);
                            };

        It should_get_jdf_parent_on_jdf_node_that_has_one = () => {
                                                                XElement parent =
                                                                    ticket.Root.Element(Element.JDF).JdfParent();
                                                                parent.ShouldNotBeNull();
                                                                parent.ShouldEqual(ticket.Root);
                                                            };

        It should_get_jdf_parent_on_non_jdf_node_that_has_one = () => {
                                                                    XElement parent = (ticket.Root.FirstNode as XElement).JdfParent();
                                                                    parent.ShouldNotBeNull();
                                                                    parent.ShouldEqual(ticket.Root);
                                                                };

        It should_throw_jdf_exception_when_trying_to_get_jdf_parent_of_node_that_has_none = () => {
                                                                                                exception =
                                                                                                    Catch.Exception(() => elementWithoutJdf.JdfParent());
                                                                                                exception.ShouldNotBeNull();
                                                                                                exception.ShouldBeOfType(typeof (JdfException));
                                                                                            };
    }
}