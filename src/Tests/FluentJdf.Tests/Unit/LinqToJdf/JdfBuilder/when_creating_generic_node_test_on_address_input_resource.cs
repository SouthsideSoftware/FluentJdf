using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentJdf.LinqToJdf;
using FluentJdf.LinqToJdf.Builder.Jmf;
using Machine.Specifications;
using System.Xml.Linq;

namespace FluentJdf.Tests.Unit.LinqToJdf.JdfBuilder {

    [Subject("Highly fluent JDF interface")]
    public class when_creating_generic_node_test_on_address_input_resource {

        static FluentJdf.LinqToJdf.Ticket ticket;

        Because of = () => ticket = FluentJdf.LinqToJdf.Ticket
                                            .CreateIntent()
                                            .Ticket
                                            .ModifyJdfNode()
                                            .WithInput()
                                            .Address()
                                            .AddNode(new XElement("AddressChild"))
                                            .With()
                                            .Attribute("addressid", "1234").Ticket;

        It should_have_element_name_of_test = () => ticket.SelectJDFDescendant("Address")
                                                            .Element("AddressChild").ShouldNotBeNull();

        It should_have_attribute_name_of_addressid = () => ticket.SelectJDFDescendant("Address")
                                                            .Element("AddressChild").Attribute("addressid").ShouldNotBeNull();

        It should_have_attribute_value_of_1234 = () => ticket.SelectJDFDescendant("Address")
                                                            .Element("AddressChild").Attribute("addressid").Value.ShouldEqual("1234");

    }
}
