using System.Xml.Linq;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.JdfElementExtensions
{
    [Subject("Fluent Creation of Intent Nodes")]
    public class when_creating_intent_node_in_empty_document {
        static XDocument document;

        Establish content = () => document = new XDocument();
        
        Because of = () => document.AddIntentElement();

        It should_have_root_node = () => document.Root.ShouldNotBeNull();

        It should_have_jdf_node_at_root = () => document.Root.IsJdfElement();

        It should_have_intent_node_at_root = () => document.Root.IsJdfIntentElement();

        It should_have_a_job_id_in_the_root_node = () => document.Root.GetJobId().ShouldNotBeEmpty();

        It should_not_have_a_job_part_id = () => document.Root.GetJobPartId().ShouldBeNull();

        It should_not_have_types = () => document.Root.GetJdfTypes().ShouldBeNull();
    }
}
