using System.Linq;
using System.Xml.Linq;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.JdfElementExtensions {
    [Subject("Fluent Creation of Linked Resources")]
    public class when_creating_an_output_of_an_existing_resource {
        static XElement jdf;

        Establish context =
            () => jdf = Ticket.Create().AddIntentElement();

        Because of = () => jdf.AddOutput(Resource.BindingIntent, "t").AddInput("t");

        It should_have_one_hole_making_intent_in_resource_pool = () => jdf.ResourcePoolElement().Elements(Resource.BindingIntent).Count().ShouldEqual(1);

        It should_have_two_hole_making_intent_links_in_the_resource_link_pool =
            () => jdf.ResourceLinkPoolElement().Elements(Resource.BindingIntent.LinkName()).Count().ShouldEqual(2);

        It should_have_one_hole_making_intent_link_as_input = () => jdf.JdfXPathSelectElements("//BindingIntentLink[@Usage='Input']").Count().ShouldEqual(1);

        It should_have_one_hole_making_intent_link_as_output = () => jdf.JdfXPathSelectElements("//BindingIntentLink[@Usage='Output']").Count().ShouldEqual(1);

        It should_have_hole_making_intent_input_link_with_rRef_t =
            () => jdf.JdfXPathSelectElement("//BindingIntentLink[@Usage='Input']").GetRefId().ShouldEqual("t");

        It should_have_hole_making_intent_output_link_with_rRef_t =
            () => jdf.JdfXPathSelectElement("//BindingIntentLink[@Usage='Output']").GetRefId().ShouldEqual("t");
    }
}