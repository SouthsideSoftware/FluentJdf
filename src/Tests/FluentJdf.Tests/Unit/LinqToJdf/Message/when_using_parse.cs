using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.Message
{
    [Subject(typeof(FluentJdf.LinqToJdf.Message))]
    public class when_using_parse {
        static FluentJdf.LinqToJdf.Message sourceMessage;
        static FluentJdf.LinqToJdf.Message parsedMessage;

        Establish context = () => sourceMessage = FluentJdf.LinqToJdf.Message.Create().AddQuery().SubmissionMethods().Message;

        Because of = () => parsedMessage = FluentJdf.LinqToJdf.Message.Parse(sourceMessage.ToString());

        It should_have_parsed_content_same_as_source = () => FluentJdf.LinqToJdf.Message.DeepEquals(parsedMessage, sourceMessage);
    }
}
