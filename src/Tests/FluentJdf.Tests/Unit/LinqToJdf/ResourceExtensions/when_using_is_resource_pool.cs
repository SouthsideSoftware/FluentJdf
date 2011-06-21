using System.Xml.Linq;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.ResourceExtensions
{
    [Subject(typeof(FluentJdf.LinqToJdf.ResourceExtensions))]
    public class when_using_is_resource_pool {
        static XElement jdf;

        Establish content = () => jdf = Ticket.CreateIntent().Element
                                    .AddInput(Resource.BindingIntent)
                                    .NearestJdf();
                           

        It should_have_is_resource_pool_true_in_root_resource_pool = () => jdf.Element(Element.ResourcePool).IsResourcePool().ShouldBeTrue();

        It should_have_is_resource_pool_false_on_root = () => jdf.IsResourcePool().ShouldBeFalse();
    }
}
