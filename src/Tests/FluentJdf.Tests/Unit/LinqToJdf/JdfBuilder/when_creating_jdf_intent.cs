using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentJdf.LinqToJdf;
using FluentJdf.LinqToJdf.Builder.Jmf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.JdfBuilder
{
    [Subject("Highly fluent JDF interface")]
    public class when_creating_jdf_intent {
        static FluentJdf.LinqToJdf.Ticket ticket;

        Because of = () => ticket = FluentJdf.LinqToJdf.Ticket.CreateIntent().Ticket;

        It should_have_root_with_type_product = () => ticket.Root.GetMessageType().ShouldEqual("Product");

        It should_have_xsi_type_for_intent = () => ticket.Root.GetXsiTypeAttribute().ShouldEqual(ProcessType.Intent);

        It should_have_namespace_definition_for_xsi_with_xsi_prefix =
            () => ticket.Root.ToString().ShouldContain("xsi:");
    }
}
