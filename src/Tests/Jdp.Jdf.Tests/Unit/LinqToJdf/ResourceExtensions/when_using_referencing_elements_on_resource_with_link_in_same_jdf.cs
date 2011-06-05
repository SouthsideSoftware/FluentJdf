using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Jdp.Jdf.LinqToJdf;
using Machine.Specifications;

namespace Jdp.Jdf.Tests.Unit.LinqToJdf.ResourceExtensions
{
    [Subject(typeof(Jdf.LinqToJdf.ResourceExtensions))]
    public class when_using_referencing_elements_on_resource_with_link_in_same_jdf {
        static XElement bindingIntent;
        static List<XElement> references;

        Establish content = () => bindingIntent = Ticket.Create().AddIntentNode().AddInput(Resource.BindingIntent);

        Because of = () => references = bindingIntent.ReferencingElements().ToList();

        It should_return_a_list_of_references = () => references.ShouldNotBeNull();

        It should_have_one_referencing_element = () => references.Count.ShouldEqual(1);

        It should_have_the_link_as_the_referencing_element = () => references[0].ShouldEqual(bindingIntent.Document.Descendants(Resource.BindingIntent.LinkName()).FirstOrDefault());
    }
}
