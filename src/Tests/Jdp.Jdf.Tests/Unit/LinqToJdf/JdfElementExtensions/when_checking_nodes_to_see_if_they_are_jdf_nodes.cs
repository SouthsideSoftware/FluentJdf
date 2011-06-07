using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Machine.Specifications;
using Jdp.Jdf.LinqToJdf;

namespace Jdp.Jdf.Tests.Unit.LinqToJdf.JdfElementExtensions
{
    [Subject(typeof(Jdf.LinqToJdf.JdfElementExtensions))]
    public class when_checking_nodes_to_see_if_they_are_jdf_nodes
    {
        It should_return_true_if_element_is_jdf_node = () => new XElement(Element.JDF).IsJdfElement().ShouldBeTrue();

        It should_return_false_if_element_is_named_jdf_in_empty_namespace = () => new XElement("JDF").IsJdfElement().ShouldBeFalse();

        It should_return_false_if_lement_is_in_jdf_namespace_but_has_wrong_name = () => new XElement(Element.JMF).IsJdfElement().ShouldBeFalse();
    }
}
