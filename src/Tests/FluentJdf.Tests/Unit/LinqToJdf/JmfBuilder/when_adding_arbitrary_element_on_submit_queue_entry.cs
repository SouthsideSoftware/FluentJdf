using System.Xml.Linq;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.JmfBuilder {
    [Subject("Highly fluent JMF interface")]
    public class when_adding_arbitrary_element_on_submit_queue_entry {
        static FluentJdf.LinqToJdf.Message message;

        Because of = () => message = FluentJdf.LinqToJdf.Message.Create().AddCommand().SubmitQueueEntry().AddNode(new XElement("foo")).Message;

        It should_have_element_foo_on_command = () => message.Root.Element(Element.Command).Element("foo").ShouldNotBeNull();
    }
}