using System.Xml.Linq;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.ResourceExtensions {
    [Subject(typeof(FluentJdf.LinqToJdf.ResourceExtensions))]
    public class when_using_get_resource_or_null_with_resource_in_ancestor_resource_pool {
        static XDocument ticket;

        Establish context = () => ticket = FluentJdf.LinqToJdf.Ticket.CreateIntent().Element.AddIntentElement().AddInput(Resource.BindingIntent, "bi").NearestJdf().AddIntentElement().AddOutput(Resource.Component, "c").Document;

        It should_be_able_to_find_the_binding_intent = () => ticket.Root.GetResourceOrNull("bi").ShouldEqual(ticket.Root.Element(Element.JDF).ResourcePoolElement().Element(Resource.BindingIntent));

        It should_be_able_to_find_the_component =
            () => ticket.Root.GetResourceOrNull("c").ShouldEqual(ticket.Root.Element(Element.JDF).Element(Element.JDF).ResourcePoolElement().Element(Resource.Component));

        It should_return_null_if_id_does_not_exist = () => ticket.Root.GetResourceOrNull("notExisting").ShouldBeNull();
    }
}