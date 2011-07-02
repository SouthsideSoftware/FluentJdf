using System.Xml.Linq;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.ElementExtensions {
    [Subject(typeof(FluentJdf.LinqToJdf.ElementExtensions))]
    public class when_using_get_nearest_jdf_or_null_on_child_of_jdf_element
    {
        static XDocument ticket;
        static XElement secondLevelResourceLinkPool;
        static XElement secondLevelJdf;
        static XElement nearestJdf;

        Establish context = () =>
                            {
                                ticket = FluentJdf.LinqToJdf.Ticket.CreateIntent().Element.AddIntentElement().ResourceLinkPoolElement().Document;
                                secondLevelJdf = ticket.Root.Element(Element.JDF);
                                secondLevelResourceLinkPool = secondLevelJdf.Element(Element.ResourceLinkPool);
                            };

        Because of = () => nearestJdf = secondLevelResourceLinkPool.GetNearestJdfOrNull();

        It should_have_a_non_null_result = () => nearestJdf.ShouldNotBeNull();

        It should_have_nearest_jdf_same_as_second_level_jdf = () => nearestJdf.ShouldEqual(secondLevelJdf);
    }
}