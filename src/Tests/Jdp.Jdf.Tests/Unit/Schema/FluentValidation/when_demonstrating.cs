using Jdp.Jdf.LinqToJdf;
using Jdp.Jdf.LinqToJdf.Configuration;
using Machine.Specifications;

namespace Jdp.Jdf.Tests.Unit.Schema.FluentValidation {
    [Subject("Demo")]
    [Ignore("demo")]
    public class when_demonstrating {
        static Ticket ticket;

        Because of = () => {
                         ticket = null;
                     };

        It should_save = () => ticket.ValidateJdf().Save(@"c:\logs\test.jdf");
    }
}