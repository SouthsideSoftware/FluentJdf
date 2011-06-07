using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Jdp.Jdf.LinqToJdf;
using Machine.Specifications;

namespace Jdp.Jdf.Tests.Unit.LinqToJdf.ElementExtensions
{
    [Subject(typeof(Jdf.LinqToJdf.ElementExtensions))]
    public class when_using_get_jdf_parent_or_null_on_elements_that_have_jdf_parents {
        static XDocument ticket;
        static XElement resourcePoolJdfParent;
        static XElement resourceLinkPoolJdfParent;
        static XElement commentJdfParent;

        Establish content = () => ticket = Ticket.Create().AddIntentElement().ResourcePoolElement().Parent.AddIntentElement().ResourceLinkPoolElement().Document;

        Because of = () => {
                         resourcePoolJdfParent = ticket.Root.ResourcePoolElement(rp => rp.Add(new XElement(Element.Comment))).GetJdfParentOrNull();
                         resourceLinkPoolJdfParent = ticket.Root.Element(Element.JDF).ResourceLinkPoolElement().GetJdfParentOrNull();
                         commentJdfParent = ticket.Root.Descendants(Element.Comment).FirstOrDefault().GetJdfParentOrNull();
                     };

        It should_have_resource_pool_jdf_parent = () => resourcePoolJdfParent.ShouldNotBeNull();

        It should_have_jdf_parent_of_resource_pool_is_root = () => resourcePoolJdfParent.ShouldEqual(ticket.Root);

        It should_have_jdf_parent_of_comment = () => commentJdfParent.ShouldNotBeNull();

        It should_have_jdf_parent_of_comment_is_root = () => commentJdfParent.ShouldEqual(ticket.Root);

        It should_have_resource_link_pool_parent = () => resourceLinkPoolJdfParent.ShouldNotBeNull();

        It should_have_resource_link_pool_parent_is_jdf = () => resourceLinkPoolJdfParent.IsJdfElement();

        It should_have_resource_link_pool_parent_is_not_root = () => resourceLinkPoolJdfParent.ShouldNotEqual(ticket.Root);
    }
}
