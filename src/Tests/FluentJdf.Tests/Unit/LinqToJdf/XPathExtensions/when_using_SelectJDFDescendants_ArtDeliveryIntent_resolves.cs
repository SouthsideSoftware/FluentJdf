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
    public class when_using_SelectJDFDescendants_ArtDeliveryIntent_resolves {
        static XDocument ticket;

        Establish context = () => {
            ticket = l.Ticket.Load(TestDataHelper.Instance.PathToTestFile("ArtDeliveryIntentTest.jdf"));
        };

        It should_find_artdeliveryintent_when_ref_element_exists = () => ticket.SelectJDFDescendants(Resource.ArtDeliveryIntent).Count().ShouldEqual(1);

        It should_match_correct_id = () => ticket.SelectJDFDescendant(Resource.ArtDeliveryIntent).Attribute("ID").Value
                                                                        .ShouldEqual("ArtDeliveryIntent_5eaf599a-0d57-4f21-b77e-b50d5d5c785f");

        It should_find_artdeliveryintent_and_child_runlist = () => ticket.SelectJDFDescendants(Resource.ArtDeliveryIntent)
                                                                    .SelectJDFDescendant(Resource.RunList).ShouldNotBeNull();

        It should_find_three_components = () => ticket.SelectJDFDescendants(Resource.Component).Count().ShouldEqual(3);

        It should_find_two_mediaintent = () => ticket.SelectJDFDescendants(Resource.MediaIntent).Count().ShouldEqual(2);
    }
}
