using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.ElementExtensions
{
    [Subject(typeof(FluentJdf.LinqToJdf.ElementExtensions))]
    public class when_checking_node_depth {
        static Ticket ticket;

        Establish context = () => ticket = Ticket.CreateIntent().WithInput().BindingIntent()
                                               .AddIntent().WithInput().BindingIntent().Ticket;

        It should_have_zero_depth_on_root = () => ticket.Root.Depth().ShouldEqual(0);

        It should_have_depth_1_on_resource_pool_of_root = () => ticket.Root.ResourcePoolElement().Depth().ShouldEqual(1);

        It should_have_depth_2_on_resource_in_root_pool = () => ticket.Root.ResourcePoolElement().Element(Resource.BindingIntent).Depth().ShouldEqual(2);

        It should_have_depth_1_on_second_level_jdf = () => ticket.Root.Element(Element.JDF).Depth().ShouldEqual(1);

        It should_have_depth_2_on_second_level_resource_pool = () => ticket.Root.Element(Element.JDF).ResourcePoolElement().Depth().ShouldEqual(2);

        It should_have_depth_3_on_second_level_resource = () => ticket.Root.Element(Element.JDF).ResourcePoolElement().Element(Resource.BindingIntent).Depth().ShouldEqual(3);


    }
}
