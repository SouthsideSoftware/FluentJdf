using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentJdf.LinqToJdf;
using FluentJdf.LinqToJdf.Builder.Jmf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.JdfBuilder {

    [Subject("Highly fluent JDF interface")]
    public class when_creating_generic_node_test_on_three_level_deep_jdf_document {

        static FluentJdf.LinqToJdf.Ticket ticket;

        Because of = () => ticket = FluentJdf.LinqToJdf.Ticket
                                    .CreateIntent()
                                    .Ticket
                                    .ModifyJdfNode()
		                            .AddIntent()
		                            .AddNode("Test")
		                            .With()
		                            .Attribute("me", "6")
		                            .WithInput()
		                            .Address()
		                            .AddNode("AddressChild")
		                            .With()
		                            .Attribute("addressid", "1234")
		                            .AddIntent()
		                            .AddNode("Test")
		                            .With()
		                            .Attribute("me", "8").Ticket;

        It should_have_child_jdf_with_test_attribute_with_attribute_of_test_and_value_of_6 = () =>
                                    ticket.Root
                                    .SelectJDFDescendant("JDF")
                                    .Element("Test")
                                    .Attribute("me")
                                    .Value.ShouldEqual("6");

        It should_have_child_child_jdf_with_test_attribute_with_attribute_of_test_and_value_of_8 = () =>
                                    ticket.Root
                                    .SelectJDFDescendant("JDF")
                                    .SelectJDFDescendant("JDF")
                                    .Element("Test")
                                    .Attribute("me")
                                    .Value.ShouldEqual("8");

    }
}
