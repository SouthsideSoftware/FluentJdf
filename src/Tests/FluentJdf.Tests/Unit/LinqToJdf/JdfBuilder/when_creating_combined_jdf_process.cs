using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.JdfBuilder {
    [Subject("Highly fluent JDF interface")]
    public class when_creating_combined_jdf_process {
        static Ticket ticket;

        Because of = () => ticket = Ticket.CreateProcess(ProcessType.Cutting, ProcessType.Creasing, ProcessType.AssetListCreation).Ticket;

        It should_have_root_with_type_combined = () => ticket.Root.GetMessageType().ShouldEqual("Combined");

        It should_have_root_with_types_cutting_creasing_asset_list_creation = () => ticket.Root.GetAttributeValueOrNull("Types").ShouldEqual("Cutting Creasing AssetListCreation");
    }
}