using System.Linq;
using System.Xml.Linq;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.ResourceExtensions {
    [Subject(typeof (FluentJdf.LinqToJdf.ResourceExtensions))]
    public class when_using_set_id_on_resource_with_link_with_option_set_so_references_are_not_updated {
        static XElement bindingIntent;

        Establish content = () => bindingIntent = FluentJdf.LinqToJdf.Ticket.CreateIntent().Element.AddInput(Resource.BindingIntent);

        Because of = () => bindingIntent.SetId("c1", false);

        It should_have_zero_referencing_elements = () => bindingIntent.ReferencingElements().Count().ShouldEqual(0);

        It should_have_resource_with_the_set_id = () => bindingIntent.GetId().ShouldEqual("c1");

        It should_return_a_list_of_references = () => bindingIntent.ReferencingElements().ShouldNotBeNull();
    }
}