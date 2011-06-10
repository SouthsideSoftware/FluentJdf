using System.Xml.Linq;
using Jdp.Jdf.LinqToJdf;
using Machine.Specifications;

namespace Jdp.Jdf.Tests.Unit.Schema.FluentValidation {
    [Subject("Demo")]
    [Ignore("demo")]
    public class when_demonstrating {
        static Ticket ticket;

        Because of = () => {
                         ticket = Ticket.Create().AddNode().Intent()
                             .WithInput().BindingIntent().With().Id("foo")
                             .WithOutput().Component()
                             .AddNode().ProcessGroup()
                             .AddNode().Process(ProcessType.Creasing)
                             .Ticket;
                         ticket.Root.GetResourceOrNull("foo").SetId("fi");

                        // var doc = new XDocument(new XElement(XName.Get("JDF", "http://www.CIP4.org/JDFSchema_1_1", new XAttribute("JobID"))));
                        // doc.Save(@"c:\logs\test2.jdf");
                     };

        It should_save = () => ticket.ValidateJdf().Save(@"\logs\test.jdf");
    }
}