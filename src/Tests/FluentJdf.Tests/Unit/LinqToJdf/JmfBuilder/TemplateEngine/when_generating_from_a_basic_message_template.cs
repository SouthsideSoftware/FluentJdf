using System.Linq;
using FluentJdf.LinqToJdf;
using Infrastructure.Core.Testing;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.JmfBuilder.TemplateEngine
{
    [Subject("Message generation from template")]
    public class when_generating_from_a_basic_message_template {
        static FluentJdf.LinqToJdf.Message message;

        Because of = () => message = FluentJdf.LinqToJdf.Message.CreateFromTemplate(TestDataHelper.Instance.PathToTestFile("basicJmfTemplate.jmf"))
                                .With()
                                    .NameValue("deviceId", "deviceId")
                           .Generate();

        It should_have_generated_a_ticket = () => message.ShouldNotBeNull();

        It should_have_a_root_jmf = () => message.Root.IsJmfElement();

        It should_have_device_id_set = () => message.Descendants(Element.Queue).First().GetAttributeValueOrNull("DeviceID").ShouldEqual("deviceId");
    }
}
