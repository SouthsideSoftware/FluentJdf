using System;
using System.Linq;
using System.Xml.Linq;
using Jdp.Jdf.LinqToJdf;
using Jdp.Jdf.LinqToJdf.Configuration;
using Machine.Specifications;

namespace Jdp.Jdf.Tests.Unit.LinqToJdf.JdfElementExtensions.Audits {
    [Subject(typeof(Jdf.LinqToJdf.JdfElementExtensions))]
    public class when_adding_an_audit_with_explicit_values {
        static XDocument document;

        Establish context = () => {
                                //reset in case other tests changed
                                JdpLibrary.Settings.ResetToDefaults();

                                document = Ticket.Create()
                                    .AddNode().Intent().With().JobId("foo")
                                    .Element.Document;
                            };

        Because of = () => document.Root.AddAudit(Audit.Modified, "author", DateTime.Now, "agent", "agentVersion");

        It should_have_an_audit_pool_in_root = () => document.Root.Element(Element.AuditPool).ShouldNotBeNull();

        It should_have_one_modified_audit_in_the_audit_pool = () => document.Root.AuditPoolElement().Elements(Audit.Modified).Count().ShouldEqual(1);

        It should_have_agent_name_from_configuration = () => document.Root.AuditPoolElement().Element(Audit.Modified).GetAttributeValueOrNull("AgentName").ShouldEqual("agent");

        It should_have_agent_version_from_configuration = () => document.Root.AuditPoolElement().Element(Audit.Modified).GetAttributeValueOrNull("AgentVersion").ShouldEqual("agentVersion");

        It should_have_author_from_configuration = () => document.Root.AuditPoolElement().Element(Audit.Modified).GetAttributeValueOrNull("Author").ShouldEqual("author");

        It should_have_a_timestamp_ending_with_the_timezone_offset = () => document.Root.AuditPoolElement().Element(Audit.Modified).GetAttributeValueOrNull("TimeStamp").EndsWith("Z").ShouldBeFalse();
    }
}