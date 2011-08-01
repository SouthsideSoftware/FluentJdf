using System.Linq;
using FluentJdf.LinqToJdf;
using Infrastructure.Testing;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.JmfBuilder.TemplateEngine {
    [Subject("Message generation from template")]
    public class when_generating_from_a_template_using_custom_formula {
        static FluentJdf.LinqToJdf.Message message;

        Because of = () => message = FluentJdf.LinqToJdf.Message.CreateFromTemplate(TestDataHelper.Instance.PathToTestFile("basicJmfTemplateCustomFormula.jmf"))
                                         .With()
                                         .CustomFormula("getDeviceId", () => Globals.CreateUniqueId("my_device_id_"))
                                         .Generate();

        It should_have_generated_a_ticket = () => message.ShouldNotBeNull();

        It should_have_a_root_jmf = () => message.Root.IsJmfElement();

        It should_have_device_id_generated_by_custom_formula = () => message.Descendants(Element.Queue).First().GetAttributeValueOrNull("DeviceID").ShouldStartWith("my_device_id_");
    }
}