using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Jdp.Jdf.LinqToJdf;
using Machine.Specifications;

namespace Jdp.Jdf.Tests.Unit.LinqToJdf.ResourceExtensions {
    [Subject(typeof (Jdf.LinqToJdf.ResourceExtensions))]
    public class when_using_referencing_elements_on_resource_element_with_multiple_legal_references {
        static XElement bindingIntent;
        static List<XElement> references;

        Establish content = () => {
                                bindingIntent = Ticket.Create().AddIntentNode().AddInput(Resource.BindingIntent);
                                bindingIntent.NearestJdf().AddIntentNode().ResourceLinkPool().Add(new XElement("Tom",
                                                                                                              new XAttribute("rRef",
                                                                                                                             bindingIntent.GetId())));
                            };

        Because of = () => references = bindingIntent.ReferencingElements().ToList();

        It should_have_the_additional_referencing_node_as_one_of_the_referencing_element =
            () => references.Where(r => r.Name == "Tom").FirstOrDefault().ShouldNotBeNull();

        It should_have_the_link_as_one_of_the_referencing_element =
            () => references.Where(r => r.Name == Resource.BindingIntent.LinkName()).FirstOrDefault().ShouldNotBeNull();

        It should_have_two_referencing_elements = () => references.Count.ShouldEqual(2);

        It should_return_a_list_of_references = () => references.ShouldNotBeNull();
    }
}