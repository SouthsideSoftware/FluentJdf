using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.Schema.FluentValidation
{
    [Subject("Fluent Validation")]
    public class when_validating_using_the_fluent_interface {
        static Ticket ticket;

        Establish context = () => ticket = Ticket.Create()
            .AddNode().Intent()
            .WithInput().BindingIntent().Ticket;

        Because of = () => ticket.ValidateJdf();

        It should_have_is_valid_non_null = () => ticket.IsValid.ShouldNotBeNull();

        It should_have_is_valid_false_since_ticket_has_schema_errors = () => ticket.IsValid.Value.ShouldBeFalse();

        It should_have_some_errors = () => ticket.Errors.Count.ShouldBeGreaterThan(0);
    }
}
