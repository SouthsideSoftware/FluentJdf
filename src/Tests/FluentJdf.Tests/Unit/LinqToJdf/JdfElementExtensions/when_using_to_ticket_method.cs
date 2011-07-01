using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.JdfElementExtensions
{
    [Subject(typeof(FluentJdf.LinqToJdf.JdfElementExtensions))]
    public class when_using_to_ticket_method
    {
        It should_be_able_to_use_on_empty_document = () => new XDocument().ToTicket().ShouldBe(typeof(Ticket));

        It should_be_able_to_use_on_jdf_tree = () => new XDocument(new XElement(Element.JDF, new XElement(Element.JDF))).ToTicket().ShouldBe(typeof(Ticket));

        It should_throw_argument_exception_if_root_is_not_jdf = () => Catch.Exception(() => new XDocument(new XElement("foo")).ToTicket()).ShouldBe(typeof(ArgumentException));
    }
}
