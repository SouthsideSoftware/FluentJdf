using System.Xml.Linq;
using Jdp.Jdf.LinqToJdf;
using Machine.Specifications;

namespace Jdp.Jdf.Tests.Unit.LinqToJdf.ResourceExtensions {
    [Subject(typeof(Jdf.LinqToJdf.ResourceExtensions))]
    [Ignore("Not ready yet")]
    public class when_adding_resource_links_requiring_promotion {
        static Ticket ticket;

        Establish context = () => ticket = Ticket.Create().AddNode().Intent()
                                               .AddNode().Intent().WithInput().BindingIntent("testRef").Ticket;

        Because of = () => ticket.Root.ModifyJdfNode()
                               .WithInput().BindingIntent("testRef");

        It should_have_resource_in_root_pool = () => ticket.Root.ResourcePoolElement().Element(Resource.BindingIntent).ShouldNotBeNull();

        It should_not_have_resource_in_second_level_pool = () => ticket.Root.Element(Element.JDF).ResourcePoolElement().Element(Resource.BindingIntent).ShouldBeNull();


    }
}