using FluentJdf.Configuration;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.Configuration
{
    [Subject(typeof(Library))]
    public class when_setting_options_in_configuration
    {
        Because of = () => Library.Settings.WithJdfAuthoringSettings().AgentName("Agent").Author("Author").AgentVersion("x1.1x").CreateAuditOnNewRootJdf(false);

        It should_have_agent_name_as_set = () => Library.Settings.JdfAuthoringSettings.AgentName.ShouldEqual("Agent");

        It should_have_author_as_set = () => Library.Settings.JdfAuthoringSettings.Author.ShouldEqual("Author");

        It should_have_agent_version_as_set = () => Library.Settings.JdfAuthoringSettings.AgentVersion.ShouldEqual("x1.1x");

        It should_have_option_to_create_audit_as_set = () => Library.Settings.JdfAuthoringSettings.CreateAuditOnNewRootJdf.ShouldBeFalse();
    }
}
