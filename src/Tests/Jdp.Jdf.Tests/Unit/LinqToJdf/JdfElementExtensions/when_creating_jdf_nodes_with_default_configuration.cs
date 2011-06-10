using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jdp.Jdf.LinqToJdf;
using Machine.Specifications;

namespace Jdp.Jdf.Tests.Unit.LinqToJdf.JdfElementExtensions
{
    [Subject(typeof(Jdf.LinqToJdf.JdfElementExtensions))]
    public class when_creating_jdf_nodes_with_default_configuration
    {
        static Ticket ticket;

        Because of = () => ticket = Ticket.Create().AddNode().Intent().AddNode().Intent().Ticket;

        It should_have_job_id_in_root = () => ticket.Root.GetJobId().ShouldNotBeNull();

        It should_not_have_job_part_id_in_root = () => ticket.Root.GetJobPartId().ShouldBeNull();

        It should_not_have_job_id_in_second_level = () => ticket.Root.Element(Element.JDF).GetJobId().ShouldBeNull();

        It should_have_job_part_id_in_second_level = () => ticket.Root.Element(Element.JDF).GetJobPartId().ShouldNotBeNull();
    }
}
