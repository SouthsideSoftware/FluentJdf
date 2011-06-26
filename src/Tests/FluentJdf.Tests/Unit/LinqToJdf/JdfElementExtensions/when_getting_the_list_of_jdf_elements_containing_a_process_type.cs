using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using FluentJdf.LinqToJdf;
using Infrastructure.Core.Testing;
using System.Xml.Linq;
using l = FluentJdf.LinqToJdf;
using x = FluentJdf.LinqToJdf.XPathExtensions;

namespace FluentJdf.Tests.Unit.LinqToJdf.JdfElementExtensions {

    [Subject(typeof(l.JdfElementExtensions))]
    public class when_getting_the_list_of_jdf_elements_containing_a_process_type {
        static XDocument ticket;

        Establish context = () => {
            ticket = l.Ticket.Load(TestDataHelper.Instance.PathToTestFile("ProcessTwoMediaFiery.jdf"));
        };

        It should_find_DigitalPrinting_process_type = () => ticket.GetJdfNodesContainingProcessType("DigitalPrinting").ShouldNotBeNull();

        It should_not_find_Car_process_type = () => ticket.GetJdfNodesContainingProcessType("Car").ShouldBeEmpty();

    }
}

