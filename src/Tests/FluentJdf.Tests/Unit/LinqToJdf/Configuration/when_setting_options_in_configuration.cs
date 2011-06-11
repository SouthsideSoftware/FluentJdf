using FluentJdf.LinqToJdf.Configuration;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.Configuration
{
    [Subject(typeof(JdpLibrary))]
    public class when_setting_options_in_configuration
    {
        Because of = () => JdpLibrary.Settings.AgentNameIs("Agent").AuthorIs("Author").AgentVersionIs("x1.1x").AddCreateAuditOnNewRootJdfIs(false);

        It should_have_agent_name_as_set = () => JdpLibrary.Settings.AgentName.ShouldEqual("Agent");

        It should_have_author_as_set = () => JdpLibrary.Settings.Author.ShouldEqual("Author");

        It should_have_agent_version_as_set = () => JdpLibrary.Settings.AgentVersion.ShouldEqual("x1.1x");

        It should_have_option_to_create_audit_as_set = () => JdpLibrary.Settings.AddCreateAuditOnNewRootJdf.ShouldBeFalse();
    }
}
