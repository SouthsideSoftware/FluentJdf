using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.JdfElementExtensions {
    
    [Subject(typeof(FluentJdf.LinqToJdf.JdfElementExtensions))]
    public class when_adding_two_resources_with_same_id_using_with {
        static FluentJdf.LinqToJdf.Ticket ticket;

        Establish context = () => ticket = FluentJdf.LinqToJdf.Ticket
                                                                    .CreateProcess(ProcessType.Bending, ProcessType.CaseMaking)
                                                                    .With().JobId("job1234")
                                                                    .AddProcess(ProcessType.BoxFolding)
                                                                    .With().JobId("box1234")
                                                                    .WithInput().RunList().With().Id("foo")
                                                                    .AddNode("Test")
                                                                    .Ticket;

        Because of = () => ticket.ModifyJdfNode().AddProcess(ProcessType.BoxPacking)
		                        .With().JobId("pack1234")
		                        .WithInput().RunList().With().Id("foo");


        It should_only_have_one_element_with_the_id_of_foo = () => ticket.JdfXPathSelectElements("//*[@ID='foo']").Count().ShouldEqual(1);

        It should_have_promoted_the_runlist_to_the_root_jdf_node = () => ticket.JdfXPathSelectElements("//JDF/ResourcePool/RunList[@ID='foo']").Count().ShouldEqual(1);
    }
}
