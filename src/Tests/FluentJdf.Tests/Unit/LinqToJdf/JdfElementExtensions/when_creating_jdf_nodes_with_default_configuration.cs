using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.JdfElementExtensions
{
    [Subject(typeof(FluentJdf.LinqToJdf.JdfElementExtensions))]
    public class when_creating_jdf_nodes_with_default_configuration
    {
        static FluentJdf.LinqToJdf.Ticket ticket;

        Because of = () => ticket = FluentJdf.LinqToJdf.Ticket.CreateIntent().AddIntent().Ticket;

        It should_have_job_id_in_root = () => ticket.Root.GetJobId().ShouldNotBeNull();

        It should_not_have_job_part_id_in_root = () => ticket.Root.GetJobPartId().ShouldBeNull();

        It should_not_have_job_id_in_second_level = () => ticket.Root.Element(Element.JDF).GetJobId().ShouldBeNull();

        It should_have_job_part_id_in_second_level = () => ticket.Root.Element(Element.JDF).GetJobPartId().ShouldNotBeNull();
    }
}
