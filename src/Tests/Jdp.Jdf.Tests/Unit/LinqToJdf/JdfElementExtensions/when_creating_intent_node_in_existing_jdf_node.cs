using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Jdp.Jdf.LinqToJdf;
using Machine.Specifications;

namespace Jdp.Jdf.Tests.Unit.LinqToJdf.JdfElementExtensions
{
    [Subject("Fluent Creation of Intent Nodes")]
    public class when_creating_intent_node_in_existing_jdf_node
    {
        static XElement newIntent;
        static XElement root;

        Establish content = () => root = new XDocument(new XElement(ElementNames.JDF)).Root;

        Because of = () => newIntent = root.AddItentNode(intent => intent.SetUniqueJobId());

        It should_have_jdf_node_as_first_child_of_root = () => (root.FirstNode as XElement).IsJdfNode();

        It should_have_jdf_intent_node_as_first_child_of_root = () => (root.FirstNode as XElement).IsJdfIntentNode();

        It should_have_job_id = () => newIntent.GetJobId().ShouldNotBeNull();
    }
}
