using System;
using System.Xml.Linq;
using Jdp.Jdf.LinqToJdf;
using Machine.Specifications;

namespace Jdp.Jdf.Tests.Unit.LinqToJdf.ElementExtensions {
    [Subject(typeof (Jdf.LinqToJdf.ElementExtensions))]
    public class when_using_nearest_jdf_on_various_nodes {
        static XDocument ticket;
        static XElement elementWithoutJdf;
        static Exception exception;

        Establish content = () => {
                                ticket = Ticket.Create().AddIntentElement().ResourcePoolElement().Parent.AddIntentElement().ResourceLinkPoolElement().Document;
                                elementWithoutJdf = new XElement(Element.RivetsExposed);
                            };

        It should_get_the_node_on_jdf_node_that_has_one = () => {
                                                                XElement nearestJdf =
                                                                    ticket.Root.Element(Element.JDF).NearestJdf();
                                                                nearestJdf.ShouldNotBeNull();
                                                                nearestJdf.ShouldEqual(ticket.Root.Element(Element.JDF));
                                                            };

        It should_get_jdf_parent_on_non_jdf_node_that_has_one = () => {
                                                                    XElement parent = (ticket.Root.FirstNode as XElement).NearestJdf();
                                                                    parent.ShouldNotBeNull();
                                                                    parent.ShouldEqual(ticket.Root);
                                                                };

        It should_throw_jdf_exception_when_trying_to_get_nearest_jdf_of_node_that_has_none = () => {
                                                                                                exception =
                                                                                                    Catch.Exception(() => elementWithoutJdf.NearestJdf());
                                                                                                exception.ShouldNotBeNull();
                                                                                                exception.ShouldBeOfType(typeof (JdfException));
                                                                                            };
    }
}