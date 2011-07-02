using FluentJdf.LinqToJdf;
using FluentJdf.LinqToJdf.Builder.Jmf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.JdfBuilder {
    [Subject("Highly fluent JDF interface")]
    public class when_creating_combined_jdf_process {
        static FluentJdf.LinqToJdf.Ticket ticket;

        Because of = () => ticket = FluentJdf.LinqToJdf.Ticket.CreateProcess(ProcessType.Cutting, ProcessType.Creasing, ProcessType.AssetListCreation).Ticket;

        It should_have_root_with_type_combined = () => ticket.Root.GetMessageType().ShouldEqual("Combined");

        It should_have_root_with_types_cutting_creasing_asset_list_creation = () => ticket.Root.GetAttributeValueOrNull("Types").ShouldEqual("Cutting Creasing AssetListCreation");

        It should_have_xsi_type_combined = () => ticket.Root.GetXsiTypeAttribute().ShouldEqual(ProcessType.Combined);

        It should_have_namespace_definition_for_xsi_with_xsi_prefix =
            () => ticket.Root.ToString().ShouldContain("xsi:");

        It should_have_version_attribute_with_default_value = () => ticket.Root.GetVersion().ShouldEqual("1.4");
    }
}