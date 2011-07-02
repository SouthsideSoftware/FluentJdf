using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.Encoding.TransmissionPartCollection
{
    [Subject(typeof(FluentJdf.Encoding.TransmissionPartCollection))]
    public class when_transmission_part_collection_is_empty
    {
        static FluentJdf.Encoding.TransmissionPartCollection transmissionPartCollection = new FluentJdf.Encoding.TransmissionPartCollection();

        It should_not_have_a_message = () => transmissionPartCollection.Message.ShouldBeNull();

        It should_return_has_message_false = () => transmissionPartCollection.HasMessage.ShouldBeFalse();

        It should_not_have_a_message_part = () => transmissionPartCollection.MessagePart.ShouldBeNull();
    }
}
