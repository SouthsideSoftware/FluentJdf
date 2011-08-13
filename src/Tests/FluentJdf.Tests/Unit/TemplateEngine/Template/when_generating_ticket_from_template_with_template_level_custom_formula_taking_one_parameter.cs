using System.Linq;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.TemplateEngine.Template {
    [Subject(typeof(FluentJdf.TemplateEngine.Template))]
    public class when_generating_ticket_from_template_with_template_level_custom_formula_taking_one_parameter {
        static FluentJdf.LinqToJdf.Ticket ticketTemplate;
        static FluentJdf.LinqToJdf.Ticket ticketInstance;

        Establish context = () => {
            ticketTemplate = FluentJdf.LinqToJdf.Ticket.CreateIntent().WithInput().BindingIntent().With().Attribute("test", "[:test=customTestFunction(testParm):]").Ticket;
        };

        Because of =
            () => ticketInstance = FluentJdf.LinqToJdf.Ticket.CreateFromTemplate(ticketTemplate)
                                        .With()
                                        .NameValue("testParm", "replacement")
                                        .CustomFormula("customTestFunction", parm1 => string.Format("this is a test {0}", parm1))
                                        .Generate();

        It should_have_result_of_function_variable_location = () => ticketInstance.Descendants(Resource.BindingIntent).First().GetAttributeValueOrNull("test").ShouldEqual("this is a test replacement");
    }
}