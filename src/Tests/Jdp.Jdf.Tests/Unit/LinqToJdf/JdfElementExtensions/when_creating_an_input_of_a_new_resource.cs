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
    public class when_creating_an_input_of_a_new_resource {
        static XElement jdf;

        Establish context = () => jdf = new XElement(ElementNames.JDF);

        Because of = () => jdf.AddInput(ElementNames.BindingIntent).AddOutput(ElementNames.FoldingIntent);

        It should_have_binding_intent_in_resource_pool = () => jdf.ResourcePool().Element(ElementNames.BindingIntent).ShouldNotBeNull();

        It should_have_binding_intent_link_in_the_resource_link_pool = () => jdf.ResourceLinkPool().Element(ElementNames.LinkNameForResource(ElementNames.BindingIntent)).ShouldNotBeNull();

        It should_have_binding_as_input = () => jdf.ResourceLinkPool().Element(ElementNames.LinkNameForResource(ElementNames.BindingIntent)).GetUsage().ShouldEqual(ResourceUsageType.Input);

        It should_have_binding_resource_linked_by_id = () => jdf.ResourcePool().Element(ElementNames.BindingIntent).GetId()
            .ShouldEqual(jdf.ResourceLinkPool().Element(ElementNames.LinkNameForResource(ElementNames.BindingIntent)).GetRefId());

        It should_have_folding_intent_in_resource_pool = () => jdf.ResourcePool().Element(ElementNames.FoldingIntent).ShouldNotBeNull();

        It should_have_folding_intent_link_in_the_resource_link_pool = () => jdf.ResourceLinkPool().Element(ElementNames.LinkNameForResource(ElementNames.FoldingIntent)).ShouldNotBeNull();

        It should_have_folding_as_output = () => jdf.ResourceLinkPool().Element(ElementNames.LinkNameForResource(ElementNames.FoldingIntent)).GetUsage().ShouldEqual(ResourceUsageType.Output);

        It should_have_folding_resource_linked_by_id = () => jdf.ResourcePool().Element(ElementNames.FoldingIntent).GetId()
            .ShouldEqual(jdf.ResourceLinkPool().Element(ElementNames.LinkNameForResource(ElementNames.FoldingIntent)).GetRefId());
    }
}
