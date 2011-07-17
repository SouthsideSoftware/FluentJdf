using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using System.Xml.Linq;
using FluentJdf.LinqToJdf;

namespace FluentJdf.Tests.Unit.LinqToJdf.Ticket {

    [Subject(typeof(FluentJdf.LinqToJdf.Ticket))]
    public class when_using_ticket_getprocess {
        static FluentJdf.LinqToJdf.Ticket sourceTicket;
       

        Establish context = () => sourceTicket = FluentJdf.LinqToJdf.Ticket.CreateIntent().WithInput().BindingIntent().Ticket;

        Because of = () => sourceTicket = FluentJdf.LinqToJdf.Ticket
			                                        .CreateProcess(ProcessType.Bending)
			                                        //.AddProcess(ProcessType.Buffer)
			                                        //.AddIntent()
			                                        .Ticket
			                                        .ModifyJdfNode()
			                                        .WithInput()
			                                        .RunList()
			                                        .WithInput()
			                                        .LayoutElement()
			                                        .WithInput()
			                                        .FileSpec()
			                                        .AddProcessGroup()
			                                        //.BindingIntent()
			                                        .AddNode(new XElement("AddressChild"))
			                                        .With()
			                                        .Attribute("addressid", "1234").Ticket;

        It should_be_able_to_locate_bending = () => sourceTicket.GetProcess()
                                                                .Bending()
                                                                .WithInput(Resource.LayoutElement)

                                                                //.WithInput("LayoutElement");
                                                                ;

        It should_be_able_to_locate_bending_using_named = () => sourceTicket.GetProcess()
                                                        .Bending()
                                                        .WithInput().Named(Resource.LayoutElement);
    }
}
