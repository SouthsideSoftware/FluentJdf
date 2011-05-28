using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Jdp.Jdf.LinqToJdf;
using Machine.Specifications;

namespace Jdp.Jdf.Tests.Unit.LinqToJdf.JdfElementExtensions
{
    [Subject("Fluent Creation of Linked Resources")]
    public class when_creating_an_input_of_a_new_resource_and_performing_additional_action_on_resource
    {
        static XElement jdf;

        Establish context = () => jdf = Ticket.Create().AddItentNode();

        Because of = () => jdf.AddInput(Resource.BindingIntent).SetDescriptiveName("fooey");

        It should_have_descriptive_name_set_in_action =
            () => jdf.ResourcePool().Element(Resource.BindingIntent).GetDescriptiveName().ShouldEqual("fooey");
    }
}
