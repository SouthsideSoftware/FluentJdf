using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Jdp.Jdf.LinqToJdf;
using Jdp.Jdf.LinqToJdf.Configuration;
using Machine.Specifications;

namespace Jdp.Jdf.Tests.Unit.LinqToJdf.JdfElementExtensions.Audits
{
    [Subject(typeof(Jdf.LinqToJdf.JdfElementExtensions))]
    public class when_adding_an_audit_with_defaults {
        static XDocument document;

        Establish context = () => {
                                //reset in case other tests changed
                                JdpLibrary.Settings.ResetToDefaults();

                                document = Ticket.Create()
                                    .AddNode().Intent().With().JobId("foo")
                                    .Element.Document;
                            };

        Because of = () => document.Root.AddAudit(Audit.Modified);

        It should_have_an_audit_pool_in_root = () => document.Root.Element(Element.AuditPool).ShouldNotBeNull();

        It should_have_one_modified_audit_in_the_audit_pool = () => document.Root.AuditPoolElement().Elements(Audit.Modified).Count().ShouldEqual(1);

        It should_have_agent_name_from_configuration = () => document.Root.AuditPoolElement().Element(Audit.Modified).GetAttributeValueOrNull("AgentName").ShouldEqual(JdpLibrary.Settings.AgentName);

        It should_have_agent_version_from_configuration = () => document.Root.AuditPoolElement().Element(Audit.Modified).GetAttributeValueOrNull("AgentVersion").ShouldEqual(JdpLibrary.Settings.AgentVersion);

        It should_have_author_from_configuration = () => document.Root.AuditPoolElement().Element(Audit.Modified).GetAttributeValueOrNull("Author").ShouldEqual(JdpLibrary.Settings.Author);

        It should_have_a_timestamp_ending_with_z_since_it_was_utc = () => document.Root.AuditPoolElement().Element(Audit.Modified).GetAttributeValueOrNull("TimeStamp").ShouldEndWith("Z");
    }
}
