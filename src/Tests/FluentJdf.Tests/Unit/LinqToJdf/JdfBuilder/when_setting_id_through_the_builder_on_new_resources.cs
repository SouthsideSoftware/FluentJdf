using System.Linq;
using System.Xml.Linq;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.JdfBuilder {
    [Subject("Highly fluent JDF interface")]
    public class when_setting_id_through_the_builder_on_new_resources {
        static XElement intent;

        Establish context = () => intent = Ticket.CreateIntent().With().JobId("FOO").Element;

        Because of = () => intent.ModifyJdfNode().WithInput().BindingIntent().With().Id("foo").WithOutput().BindingIntent().With().Id("fi");

        It should_have_binding_intent_as_input = () => intent.JdfXPathSelectElements("//BindingIntentLink[@Usage='Input']").Count().ShouldEqual(1);

        It should_have_ref_id_foo_on_input_link = () => intent.JdfXPathSelectElement("//BindingIntentLink[@Usage='Input']").GetRefId().ShouldEqual("foo");

        It should_have_resource_with_id_foo = () => intent.GetResourceOrNull("foo").ShouldNotBeNull();

        It should_have_binding_intent_resource_with_id_foo = () => intent.GetResourceOrNull("foo").Name.ShouldEqual(Resource.BindingIntent);

        It should_have_binding_intent_as_output = () => intent.JdfXPathSelectElements("//BindingIntentLink[@Usage='Output']").Count().ShouldEqual(1);

        It should_have_ref_id_fi_on_output = () => intent.JdfXPathSelectElement("//BindingIntentLink[@Usage='Output']").GetRefId().ShouldEqual("fi");

        It should_have_resource_with_id_fi = () => intent.GetResourceOrNull("fi").ShouldNotBeNull();

        It should_have_binding_intent_resource_with_id_fi = () => intent.GetResourceOrNull("fi").Name.ShouldEqual(Resource.BindingIntent);
    }
}