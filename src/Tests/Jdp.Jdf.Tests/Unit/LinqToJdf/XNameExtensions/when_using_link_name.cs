using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Jdp.Jdf.LinqToJdf;
using Machine.Specifications;

namespace Jdp.Jdf.Tests.Unit.LinqToJdf.XNameExtensions
{
    [Subject(typeof(Jdf.LinqToJdf.XNameExtension))]
    public class when_using_link_name
    {
        It should_have_jdf_namespace_when_created_from_element_in_jdf_namespace = () => ResourceNames.BindingIntent.LinkName().NamespaceName.ShouldEqual(Globals.Namespace.ToString());

        It should_end_in_link_when_created_from_element_in_jdf_namespace = () => ResourceNames.BindingIntent.LinkName().LocalName.ShouldEndWith("Link");

        It should_have_empty_namespace_when_created_from_element_in_empty_namespace =
            () => XName.Get("MyIntent", "").LinkName().NamespaceName.ShouldEqual("");

        It should_end_in_link_when_created_from_element_in_empty_namespace = () => XName.Get("MyIntent", "").LinkName().LocalName.ShouldEndWith("Link");

        It should_have_foreign_namespace_when_created_from_element_in_foreign_namespace = () => XName.Get("MyIntent", "foreignNamespace").LinkName().NamespaceName.ShouldEqual("foreignNamespace");

        It should_end_in_link_when_created_from_element_in_foreign_namespace = () => XName.Get("MyIntent", "foreignNamespace").LinkName().LocalName.ShouldEndWith("Link");
    }
}
