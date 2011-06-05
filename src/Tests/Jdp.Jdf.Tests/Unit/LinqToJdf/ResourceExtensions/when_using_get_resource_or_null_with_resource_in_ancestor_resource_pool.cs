using System.Xml.Linq;
using Jdp.Jdf.LinqToJdf;
using Machine.Specifications;

namespace Jdp.Jdf.Tests.Unit.LinqToJdf.ResourceExtensions {
    [Subject(typeof(Jdf.LinqToJdf.ResourceExtensions))]
    public class when_using_get_resource_or_null_with_resource_in_ancestor_resource_pool {
        static XDocument ticket;

        Establish context = () => ticket = Ticket.Create().AddIntentNode().AddIntentNode().AddInput(Resource.BindingIntent, "bi").NearestJdf().AddIntentNode().AddOutput(Resource.Component, "c").Document;

        It should_be_able_to_find_the_binding_intent = () => ticket.Root.GetResourceOrNull("bi").ShouldEqual(ticket.Root.Element(Element.JDF).ResourcePool().Element(Resource.BindingIntent));

        It should_be_able_to_find_the_component =
            () => ticket.Root.GetResourceOrNull("c").ShouldEqual(ticket.Root.Element(Element.JDF).Element(Element.JDF).ResourcePool().Element(Resource.Component));

        It should_return_null_if_id_does_not_exist = () => ticket.Root.GetResourceOrNull("notExisting").ShouldBeNull();
    }
}