using System.Xml.Linq;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.Schema.FluentValidation {
    [Subject("Demo")]
    [Ignore("just for demo and scratch testing")]
    public class when_demonstrating {
        static Ticket ticket;

        Because of = () => {
                         ticket = Ticket.CreateIntent().AddIntent()
                             .WithOutput().Component()
                             .AddIntent().WithInput().BindingIntent("foo")
                             .AddProcessGroup()
                             .AddProcess(ProcessType.Creasing)
                             .Ticket;
                         ticket.Root.ModifyJdfNode().WithOutput().BindingIntent("foo");

            var doc = new XDocument();
            doc.Add(new XElement(Element.JDF));

            Message.Create().AddCommand().SubmitQueueEntry();

            // var doc = new XDocument(new XElement(XName.Get("JDF", "http://www.CIP4.org/JDFSchema_1_1", new XAttribute("JobID"))));
            //ticket.Save(@"c:\logs\test2.jdf");
        };

        It should_save = () => ticket.ValidateJdf().Save(@"\logs\test.jdf");
    }
}