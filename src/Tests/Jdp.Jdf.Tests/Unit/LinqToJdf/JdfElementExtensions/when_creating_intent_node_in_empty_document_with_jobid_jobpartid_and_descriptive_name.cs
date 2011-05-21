using System.Xml.Linq;
using Jdp.Jdf.LinqToJdf;
using Machine.Specifications;

namespace Jdp.Jdf.Tests.Unit.LinqToJdf.JdfElementExtensions
{
    [Subject("Fluent Creation of Intent Nodes")]
    public class when_creating_intent_node_in_empty_document_with_jobid_jobpartid_and_descriptive_name {
        static XDocument document;

        Establish content = () => document = new XDocument();
        
        Because of = () => document.CreateItentNode(new JdfNodeCreationAttributes{DescriptiveName = "description", JobId = "jobId", JobPartid = "jobPartId"});

        It should_have_root_node = () => document.Root.ShouldNotBeNull();

        It should_have_jdf_node_at_root = () => document.Root.IsJdfNode();

        It should_have_intent_node_at_root = () => document.Root.IsJdfIntentNode();

        It should_have_expected_job_id = () => document.Root.GetJobId().ShouldEqual("jobId");

        It should_have_expected_job_part_id = () => document.Root.GetJobPartId().ShouldEqual("jobPartId");

        It should_have_expected_descriptive_name = () => document.Root.GetDescriptiveName().ShouldEqual("description");
    }
}