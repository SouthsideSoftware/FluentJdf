using System;
using System.IO;
using System.Linq;
using System.Xml.Schema;
using FluentJdf.LinqToJdf;
using FluentJdf.Resources;
using Infrastructure.Core.Logging;

namespace FluentJdf.Schema
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

            Schemas = new XmlSchemaSet();
            Schemas.Add(Globals.Namespace.NamespaceName, Path.Combine(schemaDir, "jdf.xsd"));
            Schemas.Compile();
        }

        /// <summary>
        /// Gets the schema set.
        /// </summary>
        public XmlSchemaSet Schemas { get; private set; }
    }
}
