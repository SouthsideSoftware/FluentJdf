using FluentJdf.Configuration;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.JmfBuilder {
    [Subject("Highly fluent JMF interface")]
    public class when_creating_jmf_with_older_version_of_jdf_configured_as_default {
        static FluentJdf.LinqToJdf.Message message;

        Establish context = () => FluentJdf.Configuration.FluentJdfLibrary.Settings.WithJdfAuthoringSettings().JdfVersion(JdfVersion.Version_1_1);

        Because of = () => message = FluentJdf.LinqToJdf.Message.Create().AddCommand().SubmitQueueEntry().Message;

        It should_have_jmf_at_root = () => message.Root.Name.ShouldEqual(Element.JMF);

        It should_have_version_attribute_in_jmfwith_default_value = () => message.Root.GetVersion().ShouldEqual("1.1");
    }
}