using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.Schema.FluentValidation {
    [Subject("Demo")]
    [Ignore("just for demo and scratch testing")]
    public class when_demonstrating {
        static Ticket ticket;

        Because of = () => {
                         ticket = Ticket.Create().AddNode().Intent()
                             .WithOutput().Component()
                             .AddNode().Intent().WithInput().BindingIntent("foo")
                             .AddNode().ProcessGroup()
                             .AddNode().Process(ProcessType.Creasing)
                             .Ticket;
                         ticket.Root.ModifyJdfNode().WithOutput().BindingIntent("foo");

                         // var doc = new XDocument(new XElement(XName.Get("JDF", "http://www.CIP4.org/JDFSchema_1_1", new XAttribute("JobID"))));
                         // doc.Save(@"c:\logs\test2.jdf");
                     };

        It should_save = () => ticket.ValidateJdf().Save(@"\logs\test.jdf");
    }
}