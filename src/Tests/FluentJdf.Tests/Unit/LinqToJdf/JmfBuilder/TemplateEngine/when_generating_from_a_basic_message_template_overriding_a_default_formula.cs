using System.Linq;
using FluentJdf.LinqToJdf;
using Infrastructure.Testing;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.JmfBuilder.TemplateEngine
{
    [Subject("Message generation from template")]
    public class when_generating_from_a_basic_message_template_overriding_a_default_formula {
        static FluentJdf.LinqToJdf.Message message;

        Because of = () => message = FluentJdf.LinqToJdf.Message.CreateFromTemplate(TestDataHelper.Instance.PathToTestFile("basicJmfTemplate.jmf"))
                                .With()
                                    .NameValue("deviceId", "deviceId")
                                    .CustomFormula("generate", () => "this_is_my_test")
                                    .DoNotGenerateNewUniqueIds()
                           .Generate();

        It should_have_generated_a_ticket = () => message.ShouldNotBeNull();

        It should_have_a_root_jmf = () => message.Root.IsJmfElement();

        It should_have_device_id_set = () => message.Descendants(Element.Queue).First().GetAttributeValueOrNull("DeviceID").ShouldEqual("deviceId");

        It should_have_response_id_set_by_custom_formula = () => message.Descendants(Element.Response).First().GetId().ShouldEqual("this_is_my_test");
    }
}
