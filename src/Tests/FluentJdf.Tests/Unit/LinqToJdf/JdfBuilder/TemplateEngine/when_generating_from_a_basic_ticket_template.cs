using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentJdf.LinqToJdf;
using Infrastructure.Core.Testing;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.JdfBuilder.TemplateEngine
{
    [Subject("Ticket generation from template")]
    public class when_generating_from_a_basic_ticket_template {
        static FluentJdf.LinqToJdf.Ticket ticket;

        Because of = () => ticket = FluentJdf.LinqToJdf.Ticket.CreateFromTemplate(TestDataHelper.Instance.PathToTestFile("sampleJdfTemplate.xml"))
                                .With()
                                    .NameValue("IntegerSpan", "11")
                                    .NameValue("Amount1", "101.36")
                           .Generate();

        It should_have_generated_a_ticket = () => ticket.ShouldNotBeNull();

        It should_have_a_root_jdf = () => ticket.Root.IsJdfElement();

        It should_have_amount_set = () => ticket.Root.ResourcePoolElement().Elements(Resource.Component).Skip(2).First().GetAttributeValueAsDoubleOrNull("Amount").ShouldEqual(101.36);
    }
}
