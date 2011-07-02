using FluentJdf.Configuration;
using FluentJdf.LinqToJdf;
using FluentJdf.LinqToJdf.Builder.Jmf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.JmfBuilder {
    [Subject("Highly fluent JMF interface")]
    public class when_creating_jmf_with_sender_id_configured {
        static FluentJdf.LinqToJdf.Message message;

        Establish context = () => FluentJdf.Configuration.FluentJdfLibrary.Settings.WithJdfAuthoringSettings().SenderId("test");

        Because of = () => message = FluentJdf.LinqToJdf.Message.Create().AddCommand().SubmitQueueEntry().Message;

        It should_have_sender_id_as_set_at_root = () => message.Root.GetSenderId().ShouldEqual("test");
    }
}