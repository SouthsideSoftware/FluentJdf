using System.Linq;
using System.Xml.Linq;
using Jdp.Jdf.LinqToJdf;
using Jdp.Jdf.LinqToJdf.Configuration;
using Machine.Specifications;

namespace Jdp.Jdf.Tests.Unit.LinqToJdf.JdfElementExtensions.Audits {
    [Subject(typeof(Jdf.LinqToJdf.JdfElementExtensions))]
    public class when_configuration_is_set_not_to_put_created_audit_in_root {
        static XDocument document;

        Establish context = () => JdpLibrary.Settings.AddCreateAuditOnNewRootJdfIs(false);

        Because of = () => document = Ticket.Create()
                                          .AddNode().Intent().With().JobId("foo")
                                          .AddNode().Intent().With().JobId("foo").JobPartId("fi")
                                          .Element.Document;

        It should_not_have_an_audit_pool_in_root = () => document.Root.Element(Element.AuditPool).ShouldBeNull();

        It should_not_have_an_audit_pool_in_second_level_jdf = () => document.Root.Element(Element.JDF).Element(Element.AuditPool).ShouldBeNull();
    }
}