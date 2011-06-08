using System.Xml.Linq;
using Jdp.Jdf.LinqToJdf;
using Machine.Specifications;

namespace Jdp.Jdf.Tests.Unit.Schema.Validator {
    [Subject(typeof(Jdf.Schema.ValidationMessage))]
    public class when_validate_has_been_called
    {
        static XDocument document;
        static Jdf.Schema.Validator validator;

        Establish context =
            () => {
                document = Ticket.Create().AddNode().Process(ProcessType.Cutting, ProcessType.Creasing).WithInput().BindingIntent().Element.Document;
                document.Root.Add(new XElement(XName.Get("local", "foo")));
            };

        Because of = () => {
                         validator = new Jdf.Schema.Validator(document);
                         validator.Validate();
                     };

        It should_have_is_valid_not_null = () => validator.IsValid.ShouldNotBeNull();

        It should_have_id_valid_false_because_ticket_has_schema_errors = () => validator.IsValid.Value.ShouldBeFalse();

        It should_have_some_messages = () => validator.Messages.Count.ShouldBeGreaterThan(0);

        It should_have_some_error_messages = () => validator.Errors.Count.ShouldBeGreaterThan(0);

        It should_have_zero_warning_messages = () => validator.Warnings.Count.ShouldEqual(0);

        It should_have_message_count_equal_to_errors_plus_warnings = () => validator.Messages.Count.ShouldEqual(validator.Warnings.Count + validator.Errors.Count);
    }
}