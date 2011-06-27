using FluentJdf.Configuration;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.Configuration
{
    [Subject(typeof(FluentJdf.Configuration.FluentJdfLibrary))]
    public class when_setting_options_in_configuration
    {
        Because of = () => FluentJdf.Configuration.FluentJdfLibrary.Settings.WithJdfAuthoringSettings().AgentName("Agent").Author("Author").AgentVersion("x1.1x").CreateAuditOnNewRootJdf(false);

        It should_have_agent_name_as_set = () => FluentJdf.Configuration.FluentJdfLibrary.Settings.JdfAuthoringSettings.AgentName.ShouldEqual("Agent");

        It should_have_author_as_set = () => FluentJdf.Configuration.FluentJdfLibrary.Settings.JdfAuthoringSettings.Author.ShouldEqual("Author");

        It should_have_agent_version_as_set = () => FluentJdf.Configuration.FluentJdfLibrary.Settings.JdfAuthoringSettings.AgentVersion.ShouldEqual("x1.1x");

        It should_have_option_to_create_audit_as_set = () => FluentJdf.Configuration.FluentJdfLibrary.Settings.JdfAuthoringSettings.CreateAuditOnNewRootJdf.ShouldBeFalse();
    }
}
