using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using FluentJdf.Configuration;
using FluentJdf.LinqToJdf;
using Infrastructure.Core.Testing;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.TemplateEngine.Template {
    [Subject(typeof(FluentJdf.TemplateEngine.Template))]
    public class when_generating_with_additional_custom_formula {
        static FluentJdf.TemplateEngine.Template template;
        static Dictionary<string, object> dict;
        static XDocument document;

        Establish context = () => {
            template = new FluentJdf.TemplateEngine.Template(TestDataHelper.Instance.PathToTestFile("BasicJmfTemplateCustomFormula.jmf"), 
                new Dictionary<string, Func<string>>{{"getDeviceId", () => Globals.CreateUniqueId("this_is_local_")}});
            dict = new Dictionary<string, object>();
        };

        Because of = () => document = template.Generate(dict);

        It should_generate_a_document = () => document.ShouldNotBeNull();

        It should_have_generated_device_id_in_queue_element = () => document.Descendants(Element.Queue).First().GetAttributeValueOrNull("DeviceID").ShouldStartWith("this_is_local_");
    }
}