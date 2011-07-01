using System;
using System.Xml.Linq;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.JmfElementExtensions {
    [Subject(typeof(FluentJdf.LinqToJdf.JmfElementExtensions))]
    public class when_using_to_message_method
    {
        It should_be_able_to_use_on_empty_document = () => new XDocument().ToMessage().ShouldBe(typeof(Message));

        It should_be_able_to_use_on_jmf_tree = () => new XDocument(new XElement(Element.JMF, new XElement(Element.JMF))).ToMessage().ShouldBe(typeof(Message));

        It should_throw_argument_exception_if_root_is_not_jmf = () => Catch.Exception(() => new XDocument(new XElement("foo")).ToMessage()).ShouldBe(typeof(ArgumentException));
    }
}