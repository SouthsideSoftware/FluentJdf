using System.Xml.Linq;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.ElementExtensions {
    [Subject(typeof (FluentJdf.LinqToJdf.ElementExtensions))]
    public class when_using_get_nearest_jdf_or_null_on_element_with_no_jdf_nodes_associated {
        static XDocument ticket;
        static XElement nearestJdf;

        Establish context = () => {
                                ticket = new XDocument();
                                ticket.Add(new XElement(Element.Transfer));
                            };

        Because of = () => nearestJdf = ticket.Root.GetNearestJdfOrNull();

        It should_have_a_null_result = () => nearestJdf.ShouldBeNull();
    }
}