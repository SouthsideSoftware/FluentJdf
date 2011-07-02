using System.Xml.Linq;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.Schema.Validator
{
    [Subject(typeof(FluentJdf.Schema.ValidationMessage))]
    public class when_validate_has_not_been_called_yet
    {
        static XDocument document;
        static FluentJdf.Schema.Validator validator;

        Establish context =
            () => document = FluentJdf.LinqToJdf.Ticket.CreateProcess(ProcessType.Cutting, ProcessType.Creasing).WithInput().BindingIntent().Element.Document;

        Because of = () => validator = new FluentJdf.Schema.Validator(document);

        It should_have_is_valid_null = () => validator.IsValid.ShouldBeNull();

        It should_have_zero_messages = () => validator.Messages.Count.ShouldEqual(0);

        It should_have_zero_errors = () => validator.Errors.Count.ShouldEqual(0);

        It should_have_zero_warnings = () => validator.Warnings.Count.ShouldEqual(0);

        It should_have_has_been_validated_at_least_once_false = () => validator.HasValidatedAtLeastOnce.ShouldBeFalse();
    }
}
