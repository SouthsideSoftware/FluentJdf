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
        static string id;

        Establish context = () => jdf = Ticket.Create().AddItentNode();

        Because of = () => jdf.AddInput(ResourceNames.BindingIntent, null, (resource, link) =>
                                                                              {
                                                                                  id = resource.GetId();
                                                                                  resource.SetDescriptiveName("fooey");
                                                                              });

        It should_have_resource_id_matching_captured_id =
            () => jdf.ResourcePool().Element(ResourceNames.BindingIntent).GetAttributeValueOrNull("ID").ShouldEqual(id);

        It should_have_descriptive_name_set_in_action =
            () => jdf.ResourcePool().Element(ResourceNames.BindingIntent).GetDescriptiveName().ShouldEqual("fooey");
    }
}
