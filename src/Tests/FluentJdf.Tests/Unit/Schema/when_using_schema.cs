using System.Xml.Linq;
using System.Xml.Schema;
using FluentJdf.LinqToJdf;
using FluentJdf.Schema;
using Infrastructure.Core.Logging;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.Schema {
    [Subject("Schema PSVI experiements")]
    public class when_using_schema {
        static XElement intent;

        //must NOT intitialize logger in the static declaration because
        //the logging library is initialized in an IAssemblyContext
        //implementation (located in AssemblyContext).  Unfortunately,
        //MSpec does not call this until after it constructs the first test class.
        //If that test class happens to initialize the logger in the
        //static declaration, configuration has not happened yet so the
        //null logger gets used.
        static ILog logger;

        Establish context = () => {
                                logger = LogManager.GetLogger(typeof (when_using_schema));
                                intent =
                                    Ticket.Create().AddNode().Intent().With().JobId("FOO").WithInput().BindingIntent().WithOutput().BindingIntent().
                                        Element.JdfParent();
                            };

        Because of = () => {
                         intent.Document.Validate(SchemaSet.Instance.Schemas, (o, e) => {
                                                               }, true);
                     };

        It should_have_element_schema_type_on_root = () => {
                                                         IXmlSchemaInfo schemaInfo = intent.GetSchemaInfo();
                                                         schemaInfo.SchemaElement.ElementSchemaType.ShouldNotBeNull();
                                                     };
    }
}