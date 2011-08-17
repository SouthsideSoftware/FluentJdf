using System.Collections.Generic;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.Schema.Validator {
    [Subject(typeof(FluentJdf.Schema.Validator))]
    public class when_validating_a_ticket {
        static FluentJdf.LinqToJdf.Ticket ticket;
        static IList<FluentJdf.Schema.ValidationMessage> validationMessages;

        Establish context = () => ticket = FluentJdf.LinqToJdf.Ticket.CreateIntent().With().Id("123").Ticket;

        Because of = () => {
            validationMessages = ticket.ValidateJdf().ValidationMessages;
        };

        It should_have_one_error_after_validation = () => validationMessages.Count.ShouldEqual(1);

        It should_have_error_about_id_attribute_after_validation = () => validationMessages[0].Message.ShouldContain("The 'ID' attribute is invalid - The value '123' is invalid according to its datatype");
    }
}
