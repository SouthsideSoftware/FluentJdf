using System.Xml.Linq;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.Builder
{
    [Subject("Highly fluent interface")]
    public class when_using_the_highly_fluent_add_method_to_add_intent_and_set_attributes {
        static XElement intent;

        Because of = () => intent = Ticket.Create().AddNode().Intent().With().JobId("FOO").Element;

        It should_have_intent_node_as_root = () => intent.Document.Root.ShouldEqual(intent);

        It should_have_intent_with_type_product = () => intent.GetAttributeValueOrNull("Type").ShouldEqual("Product");

        It should_have_job_id_as_set_in_with = () => intent.GetJobId().ShouldEqual("FOO");
    }
}
