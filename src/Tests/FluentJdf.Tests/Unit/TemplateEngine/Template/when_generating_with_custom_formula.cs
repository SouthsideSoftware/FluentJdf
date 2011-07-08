using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using FluentJdf.LinqToJdf;
using Infrastructure.Core.Testing;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.TemplateEngine.Template {
    [Subject(typeof(FluentJdf.TemplateEngine.Template))]
    public class when_generating_with_custom_formula {
        static FluentJdf.TemplateEngine.Template template;
        static Dictionary<string, object> dict;
        static XDocument document;

        Establish context = () => {
            
            dict = new Dictionary<string, object>();
            dict.Add("queueEntryId", "entryID");
            dict.Add("queueEntryStatus", "Running");
            dict.Add("senderId", "serverID");
            dict.Add("commandId", "commandID");
            dict.Add("deviceId", "serverID");
            dict.Add("queueStatus", "Running");
            dict.Add("queueEntries", new List<string>());

            template = new FluentJdf.TemplateEngine.Template(TestDataHelper.Instance.PathToTestFile("TestTableTemplate.xml"));
           
        };

        Because of = () => document = template.Generate(dict);

        It should_generate_a_document = () => document.ShouldNotBeNull();

        It should_not_have_queue_entry_elements_in_queue = () => document.Descendants(Element.Queue).Descendants(Element.QueueEntry).Count().ShouldEqual(0);

    }
}