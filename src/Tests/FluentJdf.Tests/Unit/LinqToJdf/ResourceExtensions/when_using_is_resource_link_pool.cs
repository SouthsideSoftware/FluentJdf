using System.Xml.Linq;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.ResourceExtensions {
    [Subject(typeof(FluentJdf.LinqToJdf.ResourceExtensions))]
    public class when_using_is_resource_link_pool {
        static XElement jdf;

        Establish content = () => jdf = Ticket.CreateIntent().Element
                                            .AddInput(Resource.BindingIntent)
                                            .NearestJdf();
                           

        It should_have_is_resource_link_pool_true_in_root_resource_link_pool = () => jdf.Element(Element.ResourceLinkPool).IsResourceLinkPool().ShouldBeTrue();

        It should_have_is_resource_link_pool_false_on_root = () => jdf.IsResourceLinkPool().ShouldBeFalse();

        It should_have_is_resource_link_pool_false_on_root_resource_pool = () => jdf.Element(Element.ResourcePool).IsResourceLinkPool().ShouldBeFalse();
    }
}