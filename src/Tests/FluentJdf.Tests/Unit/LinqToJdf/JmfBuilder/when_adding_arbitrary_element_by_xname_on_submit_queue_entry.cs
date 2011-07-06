using System.Xml.Linq;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.JmfBuilder {
    [Subject("Highly fluent JMF interface")]
    public class when_adding_arbitrary_element_by_xname_on_submit_queue_entry {
        static FluentJdf.LinqToJdf.Message message;

        Because of = () => message = FluentJdf.LinqToJdf.Message.Create().AddCommand().SubmitQueueEntry().AddNode("foo").With().Attribute("fi", "x").AddNode("yyy").Message;

        It should_have_element_as_added_on_command = () => message.Root.Element(Element.Command).Element("foo").ShouldNotBeNull();

        It should_have_attribute_value_as_set_on_arbitrary_element =
            () => message.Root.Element(Element.Command).Element("foo").Attribute("fi").Value.ShouldEqual("x");

        It should_have_child_element_added_to_arbitrary_element =
            () => message.Root.Element(Element.Command).Element("foo").Element("yyy").ShouldNotBeNull();
    }
}