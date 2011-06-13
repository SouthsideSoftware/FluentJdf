using FluentJdf.Configuration;
using Infrastructure.Core.Helpers;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.Configuration
{
    [Subject(typeof(Library))]
    public class when_using_the_default_configuration {
        It should_have_agent_name_same_as_application_name = () => Library.Settings.JdfAuthoringSettings.AgentName.ShouldEqual(ApplicationInformation.Name);

        It should_have_author_same_as_application_name = () => Library.Settings.JdfAuthoringSettings.Author.ShouldEqual(ApplicationInformation.Name);

        It should_have_agent_version_same_as_application_version = () => Library.Settings.JdfAuthoringSettings.AgentVersion.ShouldEqual(ApplicationInformation.Version);

        It should_have_option_to_create_audit_on_ticket_create_on = () => Library.Settings.JdfAuthoringSettings.CreateAuditOnNewRootJdf.ShouldBeTrue();
    }
}
