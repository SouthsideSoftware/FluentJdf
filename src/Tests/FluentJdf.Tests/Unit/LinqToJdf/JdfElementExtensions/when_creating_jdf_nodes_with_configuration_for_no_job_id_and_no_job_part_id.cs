using FluentJdf.Configuration;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.JdfElementExtensions {
    [Subject(typeof(FluentJdf.LinqToJdf.JdfElementExtensions))]
    public class when_creating_jdf_nodes_with_configuration_for_no_job_id_and_no_job_part_id
    {
        static Ticket ticket;

        Establish context = () => Library.Settings.WithJdfAuthoringSettings()
            .GenerateJobPartId(false).GenerateJobId(false);

        Because of = () => ticket = Ticket.CreateIntent().AddNode().Intent().Ticket;

        It should_not_have_job_id_in_root = () => ticket.Root.GetJobId().ShouldBeNull();

        It should_not_have_job_part_id_in_root = () => ticket.Root.GetJobPartId().ShouldBeNull();

        It should_not_have_job_id_in_second_level = () => ticket.Root.Element(Element.JDF).GetJobId().ShouldBeNull();

        It should_not_have_job_part_id_in_second_level = () => ticket.Root.Element(Element.JDF).GetJobPartId().ShouldBeNull();
    }
}