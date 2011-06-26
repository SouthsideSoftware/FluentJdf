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

namespace FluentJdf.Tests.Unit.LinqToJdf.ProcessXPathParser {
   
    [Subject(typeof(FluentJdf.LinqToJdf.ProcessXPathParser))]
    public class when_using_processxpathparser_validates_no_xpath_has_usage {
        static l.ProcessXPathParser parser;

        Because of = () => parser = l.ProcessXPathParser.Parse("process:DigitalPrinting/DigitalPrintingParams[@usage=output]");

        It should_find_DigitalPrinting_ProcessName = () => parser.ProcessName.ShouldEqual("DigitalPrinting");

        It should_find_DigitalPrintingParams_ResourceName = () => parser.ResourceName.ShouldEqual("DigitalPrintingParams");

        It should_find_Output_ResourceUsage = () => parser.ResourceUsage.ShouldEqual(ResourceUsage.Output);

        It should_have_xPathStatement = () => parser.XPathStatement.ShouldBeEmpty();
    }
}
