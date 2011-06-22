using System.Linq;
using System.Xml.Linq;
using FluentJdf.Configuration;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.JdfElementExtensions.Audits {
    [Subject(typeof (FluentJdf.LinqToJdf.JdfElementExtensions))]
    public class when_created_audit_gets_created_automatically_in_two_level_tree {
        static XDocument document;

        Because of = () => document = Ticket.CreateIntent().With().JobId("foo")
                                          .AddIntent().With().JobId("foo").JobPartId("fi")
                                          .Element.Document;

        It should_have_a_timestamp_ending_with_z_since_it_was_utc =
            () => document.Root.AuditPoolElement().Element(Audit.Created).GetAttributeValueOrNull("TimeStamp").ShouldEndWith("Z");

        It should_have_agent_name_from_configuration =
            () =>
            document.Root.AuditPoolElement().Element(Audit.Created).GetAttributeValueOrNull("AgentName").ShouldEqual(
                Library.Settings.JdfAuthoringSettings.AgentName);

        It should_have_agent_version_from_configuration =
            () =>
            document.Root.AuditPoolElement().Element(Audit.Created).GetAttributeValueOrNull("AgentVersion").ShouldEqual(
                Library.Settings.JdfAuthoringSettings.AgentVersion);

        It should_have_an_audit_pool_in_root = () => document.Root.Element(Element.AuditPool).ShouldNotBeNull();

        It should_have_author_from_configuration =
            () =>
            document.Root.AuditPoolElement().Element(Audit.Created).GetAttributeValueOrNull("Author").ShouldEqual(
                Library.Settings.JdfAuthoringSettings.Author);

        It should_have_one_created_audit_in_the_audit_pool = () => document.Root.AuditPoolElement().Elements(Audit.Created).Count().ShouldEqual(1);
        It should_not_have_an_audit_pool_in_second_level_jdf = () => document.Root.Element(Element.JDF).Element(Element.AuditPool).ShouldBeNull();
    }
}