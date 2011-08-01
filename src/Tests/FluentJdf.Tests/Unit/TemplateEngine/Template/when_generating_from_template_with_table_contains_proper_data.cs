using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using FluentJdf.LinqToJdf;
using Infrastructure.Testing;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.TemplateEngine.Template {
    [Subject(typeof(FluentJdf.TemplateEngine.Template))]
    public class when_generating_from_template_with_table_contains_proper_data {
        static FluentJdf.TemplateEngine.Template template;
        static Dictionary<string, object> dict;
        static XDocument document;

        Establish context = () => {
            var tableObject1 = new TestTableObject {
                                                       queueEntryId = Guid.NewGuid(),
                                                       queueEntryPriority = 1,
                                                       queueEntryStatus = "status1",
                                                       queueEntryJobId = "jobId1"
                                                   };
            var tableObject2 = new TestTableObject {
                                                       queueEntryId = Guid.NewGuid(),
                                                       queueEntryPriority = 2,
                                                       queueEntryStatus = "status2",
                                                       queueEntryJobId = "jobId2"
                                                   };
            
            dict = new Dictionary<string, object>();
            dict.Add("queueEntryId", "entryID");
            dict.Add("queueEntryStatus", "Running");
            dict.Add("senderId", "serverID");
            dict.Add("commandId", "commandID");
            dict.Add("deviceId", "serverID");
            dict.Add("queueStatus", "Running");
            dict.Add("queueEntries", new List<TestTableObject> { tableObject1, tableObject2 });

            template = new FluentJdf.TemplateEngine.Template(TestDataHelper.Instance.PathToTestFile("TestTableTemplate.xml"));
           
        };

        Because of = () => document = template.Generate(dict);

        It should_generate_a_document = () => document.ShouldNotBeNull();

        It should_have_1_queue_entry_element_in_queue_per_row = () => document.Descendants(Element.Queue).Descendants(Element.QueueEntry).Count().ShouldEqual(2);

        It should_have_priority_as_set_on_first_queue_entry_in_queue = () => document.Descendants(Element.Queue).Descendants(Element.QueueEntry).First().GetAttributeValueAsIntOrNull("Priority").ShouldEqual(1);

        It should_have_status_as_set_on_first_queue_entry_in_queue = () => document.Descendants(Element.Queue).Descendants(Element.QueueEntry).First().GetAttributeValueOrNull("Status").ShouldEqual("status1");

        It should_not_have_attribute_with_default_but_no_value_provided =
            () => document.Root.GetAttributeValueOrNull("JobPartID").ShouldBeNull();

        It should_have_priority_as_set_on_second_queue_entry_in_queue = () => document.Descendants(Element.Queue).Descendants(Element.QueueEntry).Skip(1).First().GetAttributeValueAsIntOrNull("Priority").ShouldEqual(2);

    }

    public class TestTableObject {
        public Guid queueEntryId { get; set; }
        public int queueEntryPriority { get; set; }
        public string queueEntryStatus { get; set; }
        public string queueEntryJobId { get; set; }
    }
}