using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Jdp.Jdf.LinqToJdf;
using Machine.Specifications;

namespace Jdp.Jdf.Tests.Unit.LinqToJdf.ResourceExtensions {
    [Subject(typeof(Jdf.LinqToJdf.ResourceExtensions))]
    public class when_using_referencing_elements_on_stand_alone_resource_element {
        static XElement bindingIntent;
        static List<XElement> references;

        Establish content = () => bindingIntent = new XElement(Resource.BindingIntent);

        Because of = () => references = bindingIntent.ReferencingElements().ToList();

        It should_return_a_list_of_references = () => references.ShouldNotBeNull();

        It should_have_no_referencing_elements = () => references.Count.ShouldEqual(0);
    }
}