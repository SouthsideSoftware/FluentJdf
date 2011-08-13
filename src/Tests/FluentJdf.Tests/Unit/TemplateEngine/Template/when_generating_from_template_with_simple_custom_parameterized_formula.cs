//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using FluentJdf.LinqToJdf;
//using Machine.Specifications;

//namespace FluentJdf.Tests.Unit.TemplateEngine.Template {
//    [Subject(typeof(FluentJdf.TemplateEngine.Template))]
//    public class when_generating_from_template_with_simple_custom_parameterized_formula {
//        static FluentJdf.LinqToJdf.Message messageTemplate;
//        static FluentJdf.LinqToJdf.Message messageInstance;

//        Establish context = () => {
//            messageTemplate = FluentJdf.LinqToJdf.Message.Create().AddCommand().SubmitQueueEntry().With().Attribute("test", "[:test=customTestFuntion(testParm):]").Message;
//        };

//        Because of =
//            () => messageInstance = FluentJdf.LinqToJdf.Message.CreateFromTemplate(messageTemplate)
//                .With()
//                .NameValue("testParm", "replacement")
//                .CustomFormula("customTestFunction", (parm1) => string.Format("this is a test {0}", parm1));

//        It should_have_result_of_function_variable_location = () => messageTemplate.Descendants(Element.Command).First().GetAttributeValueOrNull("test").ShouldEqual("this is a test replacement");
//    }
//}
