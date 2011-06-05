using System.Xml.Linq;
using Jdp.Jdf.LinqToJdf;
using Machine.Specifications;

namespace Jdp.Jdf.Tests.Unit.LinqToJdf.ResourceExtensions {
    [Subject(typeof (Jdf.LinqToJdf.ResourceExtensions))]
    public class When_using_get_usage {
        static XElement jdf;

        Establish content =
            () => {
                jdf = Ticket.Create().AddIntentNode()
                    .AddInput(Resource.BindingIntent)
                    .AddOutput(Resource.FoldingIntent)
                    .NearestJdf();

                jdf.ResourceLinkPool()
                    .AddContent(
                        new XElement(Resource.StitchingParams.LinkName()),
                        new XElement(Resource.FoldingParams.LinkName()), new XAttribute("Usage", "Nuts"));
            };

        It should_get_usage_input_when_usage_is_input =
            () => jdf.ResourceLinkPool().Element(Resource.BindingIntent.LinkName()).GetUsage().ShouldEqual(ResourceUsage.Input);

        It should_get_usage_output_when_usage_is_output =
            () => jdf.ResourceLinkPool().Element(Resource.FoldingIntent.LinkName()).GetUsage().ShouldEqual(ResourceUsage.Output);

        It should_get_usage_unknown_when_usage_has_invalid_value =
            () =>
            jdf.ResourceLinkPool().Element(Resource.FoldingParams.LinkName()).GetUsage().ShouldEqual(
                ResourceUsage.Unknown);

        It should_get_usage_unknown_when_usage_is_null =
            () =>
            jdf.ResourceLinkPool().Element(Resource.StitchingParams.LinkName()).GetUsage().ShouldEqual(
                ResourceUsage.Unknown);
    }
}