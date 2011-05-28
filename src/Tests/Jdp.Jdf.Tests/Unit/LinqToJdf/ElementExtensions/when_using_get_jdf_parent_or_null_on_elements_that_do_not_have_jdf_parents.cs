using System.Linq;
using System.Xml.Linq;
using Jdp.Jdf.LinqToJdf;
using Machine.Specifications;

namespace Jdp.Jdf.Tests.Unit.LinqToJdf.ElementExtensions {
    [Subject(typeof(Jdf.LinqToJdf.ElementExtensions))]
    public class when_using_get_jdf_parent_or_null_on_elements_that_do_not_have_jdf_parents {
        static XDocument ticket;
        static XElement jdfParent;
        

        Establish content = () => { ticket = Ticket.Create();
        ticket.Add(new XElement(Element.RingDiameter));};

        Because of = () => {
                         jdfParent = ticket.Root.GetJdfParentOrNull();
                     };

        It should_not_have_a_jdf_parent = () => jdfParent.ShouldBeNull();
    }
}