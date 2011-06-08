using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using Jdp.Jdf.LinqToJdf;
using Machine.Specifications;
using Onpoint.Commons.Core.Logging;

namespace Jdp.Jdf.Tests.Unit.LinqToJdf.Builder {
    [Subject("Schema PSVI experiements")]
    //[Ignore("Only works when scheam is manually copies to the bin directory right now")]
    public class when_using_schema {
        static XElement intent;
        static XmlSchemaSet schemas;
        static ILog logger;

        Establish context = () => {
                                //must NOT intitialize logger in the static declaration because
                                //the logging library is initialized in an IAssemblyContext
                                //implementation (located in AssemblyContext).  Unfortunately,
                                //MSpec does not call this until after it constructs the first test class.
                                //If that test class happens to initialize the logger in the
                                //static declaration, configuration has not happened yet so the
                                //null logger gets used.
                                logger = LogManager.GetLogger(typeof (when_using_schema));
                                intent =
                                    Ticket.Create().AddNode().Intent().With().JobId("FOO").WithInput().BindingIntent().WithOutput().BindingIntent().
                                        Element.JdfParent();
                                schemas = new XmlSchemaSet();
                                XmlReader xmlReader = XmlReader.Create(new StreamReader(@"jdf.xsd"));
                                schemas.Add(Globals.Namespace.NamespaceName, xmlReader);
                                schemas.Compile();
                            };

        Because of = () => {
                         intent.Document.Validate(schemas, (o, e) => {
                                                               if (e.Severity == XmlSeverityType.Error) {
                                                                   logger.Error(e.Message);
                                                               }
                                                               else {
                                                                   logger.Warn(e.Message);
                                                               }
                                                           }, true);
                     };

        It should_have_element_schema_type_on_root = () => {
                                                         IXmlSchemaInfo schemaInfo = intent.GetSchemaInfo();
                                                         schemaInfo.SchemaElement.ElementSchemaType.ShouldNotBeNull();
                                                     };
    }
}