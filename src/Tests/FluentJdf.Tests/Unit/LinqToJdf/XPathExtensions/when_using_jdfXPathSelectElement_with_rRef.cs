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

namespace FluentJdf.Tests.Unit.LinqToJdf.XPathExtensions {

    [Subject(typeof(FluentJdf.LinqToJdf.XPathExtensions))]
    public class when_using_jdfXPathSelectElement_with_rRef {

        static XDocument ticket;

        Establish context = () => {
            ticket = l.Ticket.Load(TestDataHelper.Instance.PathToTestFile("ProcessTwoMediaFiery.jdf"));
        };

        It should_have_DigitalPrintingParams_Media_resolved_by_xpath =
            () => x.JdfXPathSelectElement(ticket, @"/JDF/ResourcePool/DigitalPrintingParams/Media").ShouldNotBeNull();

        It should_have_DigitalPrintingParams_Media_resolved_to_correct_media_id =
            () => x.JdfXPathSelectElement(ticket, @"/JDF/ResourcePool/DigitalPrintingParams/Media").GetAttributeValueOrEmpty("DescriptiveName").ShouldEqual("RK_Paper_Size");

        It should_have_one_result_DigitalPrintingParams_Media =
            () => x.JdfXPathSelectElements(ticket, @"/JDF/ResourcePool/DigitalPrintingParams/Media").Count().ShouldEqual(1);

        It should_have_two_media_items_in_resource_pool =
            () => x.JdfXPathSelectElements(ticket, @"/JDF/ResourcePool/Media").Count().ShouldEqual(2);
    }
}
