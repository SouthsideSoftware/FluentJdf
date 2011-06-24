using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.Schema.FluentValidation
{
    [Subject("Fluent Validation")]
    public class when_validating_jmf_using_the_fluent_interface
    {
        static Message message;

        Establish context = () => message = Message.Create().AddCommand().SubmitQueueEntry().Message;

        Because of = () => message.ValidateJmf();

        It should_have_is_valid_non_null = () => message.IsValid.ShouldNotBeNull();

        It should_have_is_valid_false_since_ticket_has_schema_errors = () => message.IsValid.Value.ShouldBeFalse();

        It should_have_some_errors = () => message.Errors.Count.ShouldBeGreaterThan(0);

        It should_have_messages_count_equal_to_errors_because_no_warnings = () => message.ValidationMessages.Count.ShouldEqual(message.Errors.Count);
    }
}