using System.Linq;
using System.Xml.Linq;
using FluentJdf.Configuration;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.JdfElementExtensions.Audits {
    [Subject(typeof (FluentJdf.LinqToJdf.JdfElementExtensions))]
    public class when_adding_an_audit_with_defaults {
        static XDocument document;

        Establish context = () => {
                                document = FluentJdf.LinqToJdf.Ticket.CreateIntent().With().JobId("foo")
                                    .Element.Document;
                            };

        Because of = () => document.Root.AddAudit(Audit.Modified);

        It should_have_a_timestamp_ending_with_z_since_it_was_utc =
            () => document.Root.AuditPoolElement().Element(Audit.Modified).GetAttributeValueOrNull("TimeStamp").ShouldEndWith("Z");

        It should_have_agent_name_from_configuration =
            () =>
            document.Root.AuditPoolElement().Element(Audit.Modified).GetAttributeValueOrNull("AgentName").ShouldEqual(
                FluentJdf.Configuration.FluentJdfLibrary.Settings.JdfAuthoringSettings.AgentName);

        It should_have_agent_version_from_configuration =
            () =>
            document.Root.AuditPoolElement().Element(Audit.Modified).GetAttributeValueOrNull("AgentVersion").ShouldEqual(
                FluentJdf.Configuration.FluentJdfLibrary.Settings.JdfAuthoringSettings.AgentVersion);

        It should_have_an_audit_pool_in_root = () => document.Root.Element(Element.AuditPool).ShouldNotBeNull();

        It should_have_author_from_configuration =
            () =>
            document.Root.AuditPoolElement().Element(Audit.Modified).GetAttributeValueOrNull("Author").ShouldEqual(
                FluentJdf.Configuration.FluentJdfLibrary.Settings.JdfAuthoringSettings.Author);

        It should_have_one_modified_audit_in_the_audit_pool = () => document.Root.AuditPoolElement().Elements(Audit.Modified).Count().ShouldEqual(1);
    }
}