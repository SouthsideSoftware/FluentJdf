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

namespace FluentJdf.Tests.Unit.LinqToJdf.ResourceExtensions {

    [Subject(typeof(FluentJdf.LinqToJdf.ResourceExtensions))]
    public class when_using_GetResourceLinkPoolResolvedItem_for_DigitalPrintingParams {
        static XDocument ticket;

        Because of = () => ticket = l.Ticket.Load(TestDataHelper.Instance.PathToTestFile("ProcessTwoMediaFiery.jdf"));

        It should_find_DigitalPrintingParams = () => ticket.GetResourceLinkPoolResolvedItem("DigitalPrintingParams", ResourceUsage.Input).ShouldNotBeNull();

        It should_not_find_BobDylan = () => ticket.GetResourceLinkPoolResolvedItem("BonDylan", ResourceUsage.Input).ShouldBeNull();
    }
}
