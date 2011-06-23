using System.Xml.Linq;
using FluentJdf.Configuration;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.JdfElementExtensions.Audits {
    [Subject(typeof(FluentJdf.LinqToJdf.JdfElementExtensions))]
    public class when_configuration_is_set_not_to_put_created_audit_in_root {
        static XDocument document;

        Establish context = () => Library.Settings.WithJdfAuthoringSettings().CreateAuditOnNewRootJdf(false);

        Because of = () => document = Ticket.CreateIntent().With().JobId("foo")
                                          .AddIntent().With().JobId("foo").JobPartId("fi")
                                          .Element.Document;

        It should_not_have_an_audit_pool_in_root = () => document.Root.Element(Element.AuditPool).ShouldBeNull();

        It should_not_have_an_audit_pool_in_second_level_jdf = () => document.Root.Element(Element.JDF).Element(Element.AuditPool).ShouldBeNull();
    }
}