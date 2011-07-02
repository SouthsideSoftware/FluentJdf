using System;
using System.Xml.Linq;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.ElementExtensions {
    [Subject(typeof (FluentJdf.LinqToJdf.ElementExtensions))]
    public class when_using_jdf_root_on_various_nodes {
        static XDocument ticket;
        static XElement elementWithoutJdf;
        static Exception exception;

        Establish content = () => {
                                ticket = FluentJdf.LinqToJdf.Ticket.CreateIntent().Element.ResourcePoolElement().Parent.AddIntentElement().ResourceLinkPoolElement().AddContent(new XElement(Element.RingSystem, new XElement(Element.RingDiameter))).Document;
                                elementWithoutJdf = new XElement(Element.RivetsExposed);
                            };

        It should_get_jdf_root_on_jdf_node_that_has_one = () => {
                                                                XElement root =
                                                                    ticket.Root.Element(Element.JDF).JdfRoot();
                                                                root.ShouldNotBeNull();
                                                                root.ShouldEqual(ticket.Root);
                                                            };

        It should_get_jdf_root_on_non_jdf_node_that_has_one = () => {
                                                                    XElement root = (ticket.Root.FirstNode as XElement).JdfRoot();
                                                                    root.ShouldNotBeNull();
                                                                    root.ShouldEqual(ticket.Root);
                                                                };

        It should_throw_jdf_exception_when_trying_to_get_jdf_root_of_node_that_has_none = () => {
                                                                                                exception =
                                                                                                    Catch.Exception(() => elementWithoutJdf.JdfRoot());
                                                                                                exception.ShouldNotBeNull();
                                                                                                exception.ShouldBeOfType(typeof (JdfException));
                                                                                            };

        It should_find_correct_jdf_root_for_deeply_nested_node =
            () => ticket.JdfXPathSelectElement("//RingDiameter").JdfRoot().ShouldEqual(ticket.Root);
    }
}