using System.Linq;
using FluentJdf.LinqToJdf;
using Infrastructure.Core.Testing;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.JdfBuilder.TemplateEngine {
    [Subject("Ticket generation from template")]
    public class when_generating_from_a_ticket_template_that_uses_configured_default_version {
        static FluentJdf.LinqToJdf.Ticket ticket;

        Because of =
            () =>
            ticket =
            FluentJdf.LinqToJdf.Ticket.CreateFromTemplate(TestDataHelper.Instance.PathToTestFile("JdfTemplateUsesConfiguredDefaultVersion.xml")).
                Generate();

        It should_have_a_root_jdf = () => ticket.Root.IsJdfElement();

        It should_have_version_set_to_current_default = () => ticket.Root.GetVersion().ShouldEqual(FluentJdf.Configuration.FluentJdfLibrary.Settings.JdfAuthoringSettings.JdfVersion);

        It should_have_generated_a_ticket = () => ticket.ShouldNotBeNull();
    }
}