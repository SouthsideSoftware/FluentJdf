using System.Linq;
using System.Xml.Linq;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.JdfBuilder {
    [Subject("Highly fluent interface")]
    public class when_using_the_highly_fluent_add_method_to_add_input_and_output_resources {
        static XElement intent;

        Establish context = () => intent = Ticket.CreateIntent().With().JobId("FOO").Element;

        Because of = () => intent.ModifyJdfNode().WithInput().BindingIntent().WithOutput().BindingIntent();

        It should_have_binding_intent_as_input = () => intent.JdfXPathSelectElements("//BindingIntentLink[@Usage='Input']").Count().ShouldEqual(1);

        It should_have_binding_intent_as_output = () => intent.JdfXPathSelectElements("//BindingIntentLink[@Usage='Output']").Count().ShouldEqual(1);
    }
}