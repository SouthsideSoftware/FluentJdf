using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using FluentJdf.Configuration;
using FluentJdf.LinqToJdf;
using Infrastructure.Testing;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.TemplateEngine.Template {
    [Subject(typeof(FluentJdf.TemplateEngine.Template))]
    public class when_generating_with_additional_custom_formula {
        static FluentJdf.TemplateEngine.Template template;
        static Dictionary<string, object> dict;
        static XDocument document;

        Establish context = () => {
            Func<string> func = () => Globals.CreateUniqueId("this_is_local_");
            template = new FluentJdf.TemplateEngine.Template(TestDataHelper.Instance.PathToTestFile("BasicJmfTemplateCustomFormula.jmf"), 
                new Dictionary<string, Delegate>{{"getDeviceId", func}});
            dict = new Dictionary<string, object>();
        };

        Because of = () => document = template.Generate(dict);

        It should_generate_a_document = () => document.ShouldNotBeNull();

        It should_have_generated_device_id_in_queue_element = () => document.Descendants(Element.Queue).First().GetAttributeValueOrNull("DeviceID").ShouldStartWith("this_is_local_");
    }
}