using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Jdp.Jdf.LinqToJdf;
using Machine.Specifications;

namespace Jdp.Jdf.Tests.Unit.Schema.Validator
{
    [Subject(typeof(Jdf.Schema.ValidationMessage))]
    public class when_validate_has_not_been_called_yet
    {
        static XDocument document;
        static Jdf.Schema.Validator validator;

        Establish context =
            () => document = Ticket.Create().AddNode().Process(ProcessType.Cutting, ProcessType.Creasing).WithInput().BindingIntent().Element.Document;

        Because of = () => validator = new Jdf.Schema.Validator(document);

        It should_have_is_valid_null = () => validator.IsValid.ShouldBeNull();

        It should_have_zero_messages = () => validator.Messages.Count.ShouldEqual(0);

        It should_have_zero_errors = () => validator.Errors.Count.ShouldEqual(0);

        It should_have_zero_warnings = () => validator.Warnings.Count.ShouldEqual(0);
    }
}
