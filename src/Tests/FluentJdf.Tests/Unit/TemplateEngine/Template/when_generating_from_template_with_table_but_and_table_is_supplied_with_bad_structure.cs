using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using FluentJdf.LinqToJdf;
using FluentJdf.TemplateEngine;
using Infrastructure.Core.Testing;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.TemplateEngine.Template {
    [Subject(typeof(FluentJdf.TemplateEngine.Template))]
    public class when_generating_from_template_with_table_but_and_table_is_supplied_with_bad_structure {
        static FluentJdf.TemplateEngine.Template template;
        static Dictionary<string, object> dict;

        Establish context = () => {
            
            dict = new Dictionary<string, object>();
            dict.Add("queueEntryId", "entryID");
            dict.Add("queueEntryStatus", "Running");
            dict.Add("senderId", "serverID");
            dict.Add("commandId", "commandID");
            dict.Add("deviceId", "serverID");
            dict.Add("queueStatus", "Running");
            dict.Add("queueEntries", new List<string> {"foo"});

            template = new FluentJdf.TemplateEngine.Template(TestDataHelper.Instance.PathToTestFile("TestTableTemplate.xml"));
           
        };

        It should_throw_template_expansion_exception = () => Catch.Exception(() => template.Generate(dict)).ShouldBeOfType(typeof(TemplateExpansionException));
    }
}