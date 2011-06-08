using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using Jdp.Jdf.LinqToJdf;
using Machine.Specifications;

namespace Jdp.Jdf.Tests.Unit.LinqToJdf.Builder {
    [Subject("Schema PSVI experiements")]
    [Ignore("Only works when scheam is manually copies to the bin directory right now")]
    public class when_using_schema {
        static XElement intent;
        static XmlSchemaSet schemas;

        Establish context = () => {
                                intent =
                                    Ticket.Create().AddNode().Intent().With().JobId("FOO").WithInput().BindingIntent().WithOutput().BindingIntent().
                                        Element.JdfParent();
                                schemas = new XmlSchemaSet();
                                XmlReader xmlReader = XmlReader.Create(new StreamReader(@"jdf.xsd"));
                                schemas.Add(Globals.Namespace.NamespaceName, xmlReader);
                                schemas.Compile();
                            };

        Because of = () => { intent.Document.Validate(schemas, (o, e) => Console.WriteLine(e), true); };

        It should_have_element_schema_type_on_root = () => {
                                                         IXmlSchemaInfo schemaInfo = intent.GetSchemaInfo();
                                                         schemaInfo.SchemaElement.ElementSchemaType.ShouldNotBeNull();
                                                     };
    }
}