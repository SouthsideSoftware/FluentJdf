using System.Xml.Linq;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.JdfElementExtensions {
    [Subject(typeof(FluentJdf.LinqToJdf.JdfElementExtensions))]
    public class when_getting_the_resource_link_pool_when_it_exists {
        static XElement jdf;
        static XElement existingResourceLinkPool;
        static XElement retrievedResourceLinkPool;

        Establish context = () => {
                                jdf = new XElement(Element.JDF);
                                existingResourceLinkPool = new XElement(Element.ResourceLinkPool);
                                jdf.Add(existingResourceLinkPool);
                            };

        Because of = () => retrievedResourceLinkPool = jdf.ResourceLinkPoolElement();

        It should_have_a_resource_link_pool_in_the_jdf = () => jdf.Element(Element.ResourceLinkPool).ShouldNotBeNull();

        It should_have_returned_the_existing_resource_link_pool_when_ResourceLinkPool_was_called =
            () => retrievedResourceLinkPool.ShouldEqual(existingResourceLinkPool);
    }
}