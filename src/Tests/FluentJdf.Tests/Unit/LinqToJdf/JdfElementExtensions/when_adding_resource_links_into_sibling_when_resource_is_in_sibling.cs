using System.Linq;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.JdfElementExtensions {
    [Subject(typeof(FluentJdf.LinqToJdf.JdfElementExtensions))]
    public class when_adding_resource_links_into_sibling_when_resource_is_in_sibling {
        static Ticket ticket;

        Establish context = () => ticket = Ticket.CreateIntent()
                                               .AddNode().Intent().WithInput().BindingIntent("testRef").Ticket;

        Because of = () => ticket.Root.ModifyJdfNode()
                               .AddNode().Intent().WithInput().BindingIntent("testRef");

        It should_have_resource_in_parent_pool = () => ticket.Root.ResourcePoolElement().Element(Resource.BindingIntent).ShouldNotBeNull();

        It should_not_have_resource_in_original_child_location = () => ticket.Root.Element(Element.JDF).ResourcePoolElement().Element(Resource.BindingIntent).ShouldBeNull();

        It should_have_two_links = () => ticket.Root.GetResourceOrNull("testRef").ReferencingElements().Count().ShouldEqual(2);


    }
}