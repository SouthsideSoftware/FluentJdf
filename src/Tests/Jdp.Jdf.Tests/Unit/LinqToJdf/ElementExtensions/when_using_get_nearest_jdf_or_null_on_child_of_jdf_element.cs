using System.Xml.Linq;
using Jdp.Jdf.LinqToJdf;
using Machine.Specifications;

namespace Jdp.Jdf.Tests.Unit.LinqToJdf.ElementExtensions {
    [Subject(typeof(Jdf.LinqToJdf.ElementExtensions))]
    public class when_using_get_nearest_jdf_or_null_on_child_of_jdf_element
    {
        static XDocument ticket;
        static XElement secondLevelResourceLinkPool;
        static XElement secondLevelJdf;
        static XElement nearestJdf;

        Establish context = () =>
                            {
                                ticket = Ticket.Create().AddIntentNode().AddIntentNode().ResourceLinkPool().Document;
                                secondLevelJdf = ticket.Root.FirstNode as XElement;
                                secondLevelResourceLinkPool = secondLevelJdf.FirstNode as XElement;
                            };

        Because of = () => nearestJdf = secondLevelResourceLinkPool.GetNearestJdfOrNull();

        It should_have_a_non_null_result = () => nearestJdf.ShouldNotBeNull();

        It should_have_nearest_jdf_same_as_second_level_jdf = () => nearestJdf.ShouldEqual(secondLevelJdf);
    }
}