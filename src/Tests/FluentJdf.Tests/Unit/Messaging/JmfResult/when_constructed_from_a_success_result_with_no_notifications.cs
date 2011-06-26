using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using FluentJdf.Encoding;
using FluentJdf.Messaging;
using Infrastructure.Core.Testing;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.Messaging.JmfResult
{
    [Subject(typeof(FluentJdf.Messaging.JmfResult))]
    public class when_constructed_from_a_success_result_with_no_notifications {
        static FluentJdf.Messaging.JmfResult result;
        static FluentJdf.Encoding.TransmissionPartCollection transmissionPartCollection = new TransmissionPartCollection();

        Establish context =
            () => transmissionPartCollection.Add(new XmlTransmissionPart(TestDataHelper.Instance.PathToTestFile("QueueStatusResponseSuccess.jmf")));

        Because of = () => result = new FluentJdf.Messaging.JmfResult(transmissionPartCollection);

        It should_have_is_success_true = () => result.IsSuccess.ShouldBeTrue();

        It should_have_return_code_success = () => result.ReturnCode.ShouldEqual(ReturnCode.Success);

        It should_have_raw_return_code_zero = () => result.RawReturnCode.ShouldEqual(0);

        It should_not_have_any_notifications = () => result.Notifications.Count.ShouldEqual(0);


    }
}
