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
    public class when_using_ProcessXPathSelectElements_return_DigitalPrintingParams {
        static XDocument ticket;
        static string path = "process:DigitalPrinting/DigitalPrintingParams[@usage=input]/./DigitalPrintingParams/Media";

        Establish context = () => {
            ticket = l.Ticket.Load(TestDataHelper.Instance.PathToTestFile("ProcessTwoMediaFiery.jdf"));
        };
#pragma warning disable 0618
        It should_find_digital_printing_params_media = () => ticket.ProcessXPathSelectElements(path).ShouldNotBeEmpty();

        It should_find_digital_printing_params_correct_mid = () => ticket.ProcessXPathSelectElements(path).FirstOrDefault()
                                                            .Attribute("MID").Value.ShouldEqual("32285");
#pragma warning restore 0618
    }

}
