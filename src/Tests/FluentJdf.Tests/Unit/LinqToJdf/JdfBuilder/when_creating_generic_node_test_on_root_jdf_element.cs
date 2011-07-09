using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentJdf.LinqToJdf;
using FluentJdf.LinqToJdf.Builder.Jmf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.JdfBuilder {

    [Subject("Highly fluent JDF interface")]
    public class when_creating_generic_node_test_on_root_jdf_element {

        static FluentJdf.LinqToJdf.Ticket ticket;

        Because of = () => ticket = FluentJdf.LinqToJdf.Ticket
                                    .CreateIntent()
                                    .Ticket
                                    .ModifyJdfNode()
                                    .AddNode("Test")
                                    .With()
                                    .Attribute("me", "4").Ticket;

        It should_have_element_name_of_test = () => ticket.Root.Element("Test").ShouldNotBeNull();

        It should_have_attribute_name_of_me = () => ticket.Root.Element("Test").Attribute("me").ShouldNotBeNull();

        It should_have_attribute_value_of_4 = () => ticket.Root.Element("Test").Attribute("me").Value.ShouldEqual("4");
    }
}
