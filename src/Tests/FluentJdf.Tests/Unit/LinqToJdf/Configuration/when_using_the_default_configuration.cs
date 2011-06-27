using FluentJdf.Configuration;
using Infrastructure.Core.Helpers;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.Configuration
{
    [Subject(typeof(FluentJdf.Configuration.FluentJdfLibrary))]
    public class when_using_the_default_configuration {
        It should_have_agent_name_same_as_application_name = () => FluentJdf.Configuration.FluentJdfLibrary.Settings.JdfAuthoringSettings.AgentName.ShouldEqual(ApplicationInformation.Name);

        It should_have_author_same_as_application_name = () => FluentJdf.Configuration.FluentJdfLibrary.Settings.JdfAuthoringSettings.Author.ShouldEqual(ApplicationInformation.Name);

        It should_have_agent_version_same_as_application_version = () => FluentJdf.Configuration.FluentJdfLibrary.Settings.JdfAuthoringSettings.AgentVersion.ShouldEqual(ApplicationInformation.Version);

        It should_have_option_to_create_audit_on_ticket_create_on = () => FluentJdf.Configuration.FluentJdfLibrary.Settings.JdfAuthoringSettings.CreateAuditOnNewRootJdf.ShouldBeTrue();
    }
}
