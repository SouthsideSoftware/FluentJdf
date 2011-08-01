using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.Testing;
using Machine.Specifications;
using FluentJdf.LinqToJdf;
using System.Xml.Linq;
using l = FluentJdf.LinqToJdf;
using x = FluentJdf.LinqToJdf.XPathExtensions;

namespace FluentJdf.Tests.Unit.LinqToJdf.XPathExtensions {

    [Subject(typeof(FluentJdf.LinqToJdf.XPathExtensions))]
    public class when_using_jdfXPathSelectElement_using_multilevel_document {

        static XDocument ticket;

        Establish context = () => {
            ticket = l.Ticket.Load(TestDataHelper.Instance.PathToTestFile("sampleJDF.xml"));
        };

        It should_resolve_rRef_from_parent_jdf =
            () => x.JdfXPathSelectElement(ticket, @"/JDF/JDF[@ID= 'Link0002']/ResourcePool/Component[@ID='Link0009']").ShouldNotBeNull();
    }
}
