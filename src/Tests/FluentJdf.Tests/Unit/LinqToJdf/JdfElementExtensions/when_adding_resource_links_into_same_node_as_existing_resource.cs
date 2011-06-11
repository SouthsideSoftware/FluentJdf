using System.Linq;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.JdfElementExtensions {
    [Subject(typeof(FluentJdf.LinqToJdf.JdfElementExtensions))]
    public class when_adding_resource_links_into_same_node_as_existing_resource {
        static Ticket ticket;

        Establish context = () => ticket = Ticket.Create().AddNode().Intent()
                                               .AddNode().Intent().WithInput().BindingIntent("testRef").Ticket;

        Because of = () => ticket.Root.Element(Element.JDF).ModifyJdfNode()
                               .WithOutput().BindingIntent("testRef");

        It should_not_have_resource_in_parent_pool = () => ticket.Root.ResourcePoolElement().Element(Resource.BindingIntent).ShouldBeNull();

        It should_have_resource_in_original_location = () => ticket.Root.Element(Element.JDF).ResourcePoolElement().Element(Resource.BindingIntent).ShouldNotBeNull();

        It should_have_two_links = () => ticket.Root.GetResourceOrNull("testRef").ReferencingElements().Count().ShouldEqual(2);

        It should_have_input_link_in_original_location =
            () =>
            ticket.Root.GetResourceOrNull("testRef").ReferencingElements().Where(r => r.GetUsage() == ResourceUsage.Input).FirstOrDefault().JdfParent()
                .ShouldEqual(ticket.Root.Element(Element.JDF));

        It should_have_output_link_in_first_level_jdf =
            () =>
            ticket.Root.GetResourceOrNull("testRef").ReferencingElements().Where(r => r.GetUsage() == ResourceUsage.Output).FirstOrDefault().JdfParent()
                .ShouldEqual(ticket.Root.Element(Element.JDF));


    }
}