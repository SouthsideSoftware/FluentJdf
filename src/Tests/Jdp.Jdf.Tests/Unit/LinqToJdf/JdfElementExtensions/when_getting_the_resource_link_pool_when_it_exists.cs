using System.Xml.Linq;
using Jdp.Jdf.LinqToJdf;
using Machine.Specifications;

namespace Jdp.Jdf.Tests.Unit.LinqToJdf.JdfElementExtensions {
    [Subject(typeof(Jdf.LinqToJdf.JdfElementExtensions))]
    public class when_getting_the_resource_link_pool_when_it_exists {
        static XElement jdf;
        static XElement existingResourceLinkPool;
        static XElement retrievedResourceLinkPool;

        Establish context = () => {
                                jdf = new XElement(ElementNames.JDF);
                                existingResourceLinkPool = new XElement(ElementNames.ResourceLinkPool);
                                jdf.Add(existingResourceLinkPool);
                            };

        Because of = () => retrievedResourceLinkPool = jdf.ResourceLinkPool();

        It should_have_a_resource_link_pool_in_the_jdf = () => jdf.Element(ElementNames.ResourceLinkPool).ShouldNotBeNull();

        It should_have_returned_the_existing_resource_link_pool_when_ResourceLinkPool_was_called =
            () => retrievedResourceLinkPool.ShouldEqual(existingResourceLinkPool);
    }
}