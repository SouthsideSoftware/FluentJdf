using System.Xml.Linq;
using Jdp.Jdf.LinqToJdf;
using Machine.Specifications;

namespace Jdp.Jdf.Tests.Unit.LinqToJdf.JdfElementExtensions {
    [Subject(typeof(Jdf.LinqToJdf.JdfElementExtensions))]
    public class when_getting_the_resource_link_pool_when_it_does_not_exist_yet {
        static XElement jdf;
        static XElement resourceLinkPool;

        Establish context = () => jdf = new XElement(Element.JDF);

        Because of = () => resourceLinkPool = jdf.ResourceLinkPool();

        It should_have_a_resource_link_pool_in_the_jdf = () => jdf.Element(Element.ResourceLinkPool).ShouldNotBeNull();

        It should_have_returned_the_resource_link_pool_when_ResourceLinkPool_was_called = () => resourceLinkPool.ShouldNotBeNull();
    }
}