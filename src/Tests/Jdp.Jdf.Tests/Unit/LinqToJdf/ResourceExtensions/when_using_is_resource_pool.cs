using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Jdp.Jdf.LinqToJdf;
using Machine.Specifications;

namespace Jdp.Jdf.Tests.Unit.LinqToJdf.ResourceExtensions
{
    [Subject(typeof(Jdf.LinqToJdf.ResourceExtensions))]
    public class when_using_is_resource_pool {
        static XElement jdf;

        Establish content = () => jdf = Ticket.Create().AddItentNode()
                                    .AddInput(ResourceNames.BindingIntent);
                           

        It should_have_is_resource_pool_true_in_root_resource_pool = () => jdf.Element(ElementNames.ResourcePool).IsResourcePool().ShouldBeTrue();

        It should_have_is_resource_pool_false_on_root = () => jdf.IsResourcePool().ShouldBeFalse();
    }
}
