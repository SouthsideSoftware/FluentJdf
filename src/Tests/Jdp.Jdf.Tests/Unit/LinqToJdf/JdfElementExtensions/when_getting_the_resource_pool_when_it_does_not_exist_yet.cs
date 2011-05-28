using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Jdp.Jdf.LinqToJdf;
using Machine.Specifications;

namespace Jdp.Jdf.Tests.Unit.LinqToJdf.JdfElementExtensions
{
    [Subject(typeof(Jdf.LinqToJdf.JdfElementExtensions))]
    public class when_getting_the_resource_pool_when_it_does_not_exist_yet {
        static XElement jdf;
        static XElement resourcePool;

        Establish context = () => jdf = new XElement(Element.JDF);

        Because of = () => resourcePool = jdf.ResourcePool();

        It should_have_a_resource_pool_in_the_jdf = () => jdf.Element(Element.ResourcePool).ShouldNotBeNull();

        It should_have_returned_the_resource_pool_when_ResourcePool_was_called = () => resourcePool.ShouldNotBeNull();
    }
}
