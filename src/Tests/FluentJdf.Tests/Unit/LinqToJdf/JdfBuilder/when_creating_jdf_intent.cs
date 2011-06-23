using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.JdfBuilder
{
    [Subject("Highly fluent JDF interface")]
    public class when_creating_jdf_intent {
        static Ticket ticket;

        Because of = () => ticket = Ticket.CreateIntent().Ticket;

        It should_have_root_with_type_product = () => ticket.Root.GetMessageType().ShouldEqual("Product");
    }
}
