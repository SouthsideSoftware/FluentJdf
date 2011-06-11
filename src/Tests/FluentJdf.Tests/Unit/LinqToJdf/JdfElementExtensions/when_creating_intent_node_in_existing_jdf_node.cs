using System.Xml.Linq;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.JdfElementExtensions
{
    [Subject("Fluent Creation of Intent Nodes")]
    public class when_creating_intent_node_in_existing_jdf_node
    {
        static XElement newIntent;
        static XElement root;

        Establish content = () => root = new XDocument(new XElement(Element.JDF)).Root;

        Because of = () => newIntent = root.AddIntentElement();

        It should_have_jdf_node_as_first_child_of_root = () => (root.FirstNode as XElement).IsJdfElement().ShouldBeTrue();

        It should_have_jdf_intent_node_as_first_child_of_root = () => (root.FirstNode as XElement).IsJdfIntentElement().ShouldBeTrue();

        It should_not_have_job_id = () => newIntent.GetJobId().ShouldBeNull();

        It should_have_job_part_id = () => newIntent.GetJobPartId().ShouldNotBeNull();
    }
}
