using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.JdfElementExtensions {
    [Subject(typeof (FluentJdf.LinqToJdf.JdfElementExtensions))]
    public class when_setting_and_getting_status {
        It should_be_able_to_get_default_status = () => FluentJdf.LinqToJdf.Ticket.CreateIntent().Element.GetStatus().ShouldEqual(JdfStatus.Waiting);

        It should_be_able_to_set_status_to_legal_value_and_get_it_back =
            () => FluentJdf.LinqToJdf.Ticket.CreateIntent().With().Status(JdfStatus.Stopped).Element.GetStatus().ShouldEqual(JdfStatus.Stopped);
    }
}