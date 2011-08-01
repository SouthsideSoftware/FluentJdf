using System.Linq;
using FluentJdf.Encoding;
using FluentJdf.Messaging;
using Infrastructure.Testing;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.Messaging.JmfResult {
    [Subject(typeof(FluentJdf.Messaging.JmfResult))]
    public class when_constructed_from_a_mixed_result_with_notifications {
        static FluentJdf.Messaging.JmfResult result;
        static FluentJdf.Encoding.TransmissionPartCollection transmissionPartCollection = new TransmissionPartCollection();

        Establish context =
            () => transmissionPartCollection.Add(new MessageTransmissionPart(TestDataHelper.Instance.PathToTestFile("TwoResponseOneSuccessOneError.jmf")));

        Because of = () => result = new FluentJdf.Messaging.JmfResult(transmissionPartCollection);

        It should_have_is_success_false = () => result.IsSuccess.ShouldBeFalse();

        It should_have_return_code_success_on_success_result = () => result.Details[0].ReturnCode.ShouldEqual(ReturnCode.Success);

        It should_have_raw_return_code_zero_on_success_result = () => result.Details[0].RawReturnCode.ShouldEqual(0);

        It should_not_have_any_notifications_on_success_result = () => result.Details[0].Notifications.Count.ShouldEqual(0);

        It should_have_return_code_as_set_on_error_result = () => result.Details[1].ReturnCode.ShouldEqual(ReturnCode.GeneralError);

        It should_have_raw_return_code_as_set_on_error_result = () => result.Details[1].RawReturnCode.ShouldEqual(1);

        It should_not_have_one_notifications_on_error_result = () => result.Details[1].Notifications.Count.ShouldEqual(1);

        It should_not_assigned_comment_text_in_notification_on_error_result =
            () => result.Details[1].Notifications.First().Comments.First().ShouldEqual("Message caused internal error");


    }
}