using System.Linq;
using System.Xml.Linq;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.ResourceExtensions {
    [Subject(typeof (FluentJdf.LinqToJdf.ResourceExtensions))]
    public class when_using_set_unique_id_recursive {
        static FluentJdf.LinqToJdf.Ticket ticket;

        Establish content = () => {
            ticket = FluentJdf.LinqToJdf.Ticket.CreateIntent().WithInput().BindingIntent().With().Id("t").ParentJdfNode.AddIntent().WithInput().BinderySignature().With().Id("f").Ticket;
        };

        Because of = () => ticket.Root.RecursiveSetUniqueId();

        It should_have_binding_intent_in_root_with_unique_id = () => ticket.Root.ResourcePoolElement().Element(Resource.BindingIntent).GetId().ShouldNotEqual("t");

        It should_have_bindery_signature_at_second_level_with_unique_id = () => ticket.Root.Element(Element.JDF).ResourcePoolElement().Element(Resource.BinderySignature).GetId().ShouldNotEqual("f");

        It should_have_a_link_referencing_binding_intent_in_root_with_unique_id =
            () => ticket.Root.ResourcePoolElement().Element(Resource.BindingIntent).ReferencingElements().Count().ShouldEqual(1);

        It should_have_a_link_referencing_bindery_signature_at_second_level_with_unique_id =
            () =>
            ticket.Root.Element(Element.JDF).ResourcePoolElement().Element(Resource.BinderySignature).ReferencingElements().Count().ShouldEqual(1);

        It should_have_different_ids_in_different_resources =
            () =>
            ticket.Root.ResourcePoolElement().Element(Resource.BindingIntent).GetId().ShouldNotEqual(
                ticket.Root.Element(Element.JDF).ResourcePoolElement().Element(Resource.BinderySignature).GetId());
    }
}