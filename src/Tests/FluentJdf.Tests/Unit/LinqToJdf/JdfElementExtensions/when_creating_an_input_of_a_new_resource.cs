using System.Xml.Linq;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.JdfElementExtensions
{
    [Subject("Fluent Creation of Linked Resources")]
    public class when_creating_an_input_of_a_new_resource {
        static XElement jdf;

        Establish context = () => jdf = new XElement(Element.JDF);

        Because of = () => jdf.AddInput(Resource.BindingIntent).AddInput(Resource.FoldingIntent);

        It should_have_binding_intent_in_resource_pool = () => jdf.ResourcePoolElement().Element(Resource.BindingIntent).ShouldNotBeNull();

        It should_have_binding_intent_link_in_the_resource_link_pool = () => jdf.ResourceLinkPoolElement().Element(Resource.BindingIntent.LinkName()).ShouldNotBeNull();

        It should_have_binding_as_input = () => jdf.ResourceLinkPoolElement().Element(Resource.BindingIntent.LinkName()).GetUsage().ShouldEqual(ResourceUsage.Input);

        It should_have_binding_resource_linked_by_id = () => jdf.ResourcePoolElement().Element(Resource.BindingIntent).GetId()
            .ShouldEqual(jdf.ResourceLinkPoolElement().Element(Resource.BindingIntent.LinkName()).GetRefId());

        It should_have_folding_intent_in_resource_pool = () => jdf.ResourcePoolElement().Element(Resource.FoldingIntent).ShouldNotBeNull();

        It should_have_folding_intent_link_in_the_resource_link_pool = () => jdf.ResourceLinkPoolElement().Element(Resource.FoldingIntent.LinkName()).ShouldNotBeNull();

        It should_have_folding_as_output = () => jdf.ResourceLinkPoolElement().Element(Resource.FoldingIntent.LinkName()).GetUsage().ShouldEqual(ResourceUsage.Input);

        It should_have_folding_resource_linked_by_id = () => jdf.ResourcePoolElement().Element(Resource.FoldingIntent).GetId()
            .ShouldEqual(jdf.ResourceLinkPoolElement().Element(Resource.FoldingIntent.LinkName()).GetRefId());
    }
}
