using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using Jdp.Jdf.LinqToJdf;
using Jdp.Jdf.Resources;
using Onpoint.Commons.Core.Logging;

namespace Jdp.Jdf.Schema
{
    /// <summary>
    /// Loads an XmlSchemaSet from resources and makes it available for use.
    /// </summary>
    public class SchemaSet {
        static ILog logger = LogManager.GetLogger(typeof (SchemaSet));

        static string schemaDir = "schema"; 

        /// <summary>
        /// Get the singleton instance
        /// </summary>
        public static SchemaSet Instance = new SchemaSet();

        private SchemaSet() {
            try {
                if (Directory.Exists(schemaDir)) {
                    Directory.Delete(schemaDir, true);
                }
                Directory.CreateDirectory(schemaDir);
    
                var assembly = GetType().Assembly;
                var schemaResourcePrefix = string.Format("{0}.Resources.Schema.", assembly.GetName().Name);
                var resources = assembly.GetManifestResourceNames();
                foreach (var resource in resources.Where(r => r.StartsWith(schemaResourcePrefix))) {
                    var filename = Path.Combine(schemaDir, resource.Replace(schemaResourcePrefix, ""));
                    using (var stream = new FileStream(filename, FileMode.CreateNew)) {
                        using (var manifestStream = assembly.GetManifestResourceStream(resource)) {
                            manifestStream.CopyTo(stream);
                        }
                    }
                }
            } catch (Exception err) {
                logger.ErrorFormat(Messages.Loader_Loader_FailedToLoadAndCompileSchema, err);
            }

            XmlReader xmlReader = XmlReader.Create(new StreamReader(Path.Combine(schemaDir, "jdf.xsd")));
            Schemas = new XmlSchemaSet();
            Schemas.Add(Globals.Namespace.NamespaceName, xmlReader);
            Schemas.Compile();
        }

        /// <summary>
        /// Gets the schema set.
        /// </summary>
        public XmlSchemaSet Schemas { get; private set; }
    }
}
