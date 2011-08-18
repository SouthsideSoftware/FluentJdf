using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.AttributeExtensions {
    [Subject(typeof(FluentJdf.LinqToJdf.AttributeExtensions))]
    public class when_attempting_to_get_span_value_or_null_but_span_element_does_not_exist {
        static FluentJdf.LinqToJdf.Ticket ticket;
        static string spanValue;

        Establish context = () => ticket = FluentJdf.LinqToJdf.Ticket.CreateIntent().WithInput().BindingIntent().Ticket;

        Because of = () => spanValue = ticket.GetIntent().WithInput(Element.BindingIntent).Elements.First().GetSpanAttributeActualPreferredOrNull(Element.BindingType);

        It should_have_null_value_because_span_element_does_not_exist = () => spanValue.ShouldBeNull();
    }
}
