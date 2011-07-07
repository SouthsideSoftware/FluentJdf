using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Infrastructure.Core.Testing;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.TemplateEngine.Template
{
    [Subject(typeof(FluentJdf.TemplateEngine.Template))]
    public class when_generating_from_template_with_table_but_table_is_not_supplied {
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

            template = new FluentJdf.TemplateEngine.Template(TestDataHelper.Instance.PathToTestFile("TestTableTemplate.xml"));
           
        };

        It should_throw_argument_exception_on_generate = () => Catch.Exception(() => template.Generate(dict)).ShouldBeOfType(typeof(ArgumentException));

        It should_have_field_name_in_exception = () => Catch.Exception(() => template.Generate(dict)).Message.ShouldContain("queueEntries");
    }
}
