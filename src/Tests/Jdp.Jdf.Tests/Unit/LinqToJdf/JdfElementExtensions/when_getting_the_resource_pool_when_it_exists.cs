using System.Xml.Linq;
using Jdp.Jdf.LinqToJdf;
using Machine.Specifications;

namespace Jdp.Jdf.Tests.Unit.LinqToJdf.JdfElementExtensions {
    [Subject(typeof(Jdf.LinqToJdf.JdfElementExtensions))]
    public class when_getting_the_resource_pool_when_it_exists {
        static XElement jdf;
        static XElement existingResourcePool;
        static XElement retrievedResourcePool;

        Establish context = () => {
                                jdf = new XElement(Element.JDF);
                                existingResourcePool = new XElement(Element.ResourcePool);
                                jdf.Add(existingResourcePool);
                            };

        Because of = () => retrievedResourcePool = jdf.ResourcePoolElement();

        It should_have_a_resource_pool_in_the_jdf = () => jdf.Element(Element.ResourcePool).ShouldNotBeNull();

        It should_have_returned_the_existing_resource_pool_when_ResourcePool_was_called =
            () => retrievedResourcePool.ShouldEqual(existingResourcePool);
    }
}