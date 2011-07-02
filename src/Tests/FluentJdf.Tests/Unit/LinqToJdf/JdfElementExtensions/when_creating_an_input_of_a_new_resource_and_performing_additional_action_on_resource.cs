using System.Xml.Linq;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.JdfElementExtensions
{
    [Subject("Fluent Creation of Linked Resources")]
    public class when_creating_an_input_of_a_new_resource_and_performing_additional_action_on_resource
    {
        static XElement jdf;

        Establish context = () => jdf = FluentJdf.LinqToJdf.Ticket.CreateIntent().Element;

        Because of = () => jdf.AddInput(Resource.BindingIntent).SetDescriptiveName("fooey");

        It should_have_descriptive_name_set_in_action =
            () => jdf.ResourcePoolElement().Element(Resource.BindingIntent).GetDescriptiveName().ShouldEqual("fooey");
    }
}
