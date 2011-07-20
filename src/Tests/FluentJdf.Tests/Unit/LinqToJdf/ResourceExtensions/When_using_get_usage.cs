using System.Xml.Linq;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.ResourceExtensions {
    [Subject(typeof (FluentJdf.LinqToJdf.ResourceExtensions))]
    public class when_using_get_usage {
        static XElement jdf;

        Establish content =
            () => {
                jdf = FluentJdf.LinqToJdf.Ticket.CreateIntent().Element
                    .AddInput(Resource.BindingIntent)
                    .AddOutput(Resource.FoldingIntent)
                    .NearestJdf();

                jdf.ResourceLinkPoolElement()
                    .AddContent(
                        new XElement(Resource.StitchingParams.LinkName()),
                        new XElement(Resource.FoldingParams.LinkName()), new XAttribute("Usage", "Nuts"));
            };

        It should_get_usage_input_when_usage_is_input =
            () => jdf.ResourceLinkPoolElement().Element(Resource.BindingIntent.LinkName()).GetUsage().ShouldEqual(ResourceUsage.Input);

        It should_get_usage_output_when_usage_is_output =
            () => jdf.ResourceLinkPoolElement().Element(Resource.FoldingIntent.LinkName()).GetUsage().ShouldEqual(ResourceUsage.Output);

        It should_get_usage_unknown_when_usage_has_invalid_value =
            () =>
            jdf.ResourceLinkPoolElement().Element(Resource.FoldingParams.LinkName()).GetUsage().ShouldEqual(
                ResourceUsage.Unknown);

        It should_get_usage_unknown_when_usage_is_null =
            () =>
            jdf.ResourceLinkPoolElement().Element(Resource.StitchingParams.LinkName()).GetUsage().ShouldEqual(
                ResourceUsage.Unknown);
    }
}