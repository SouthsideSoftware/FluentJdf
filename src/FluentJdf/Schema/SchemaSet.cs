using System;
using System.IO;
using System.Linq;
using System.Xml.Schema;
using FluentJdf.LinqToJdf;
using FluentJdf.Resources;
using Infrastructure.Core.Helpers;
using Infrastructure.Core.Logging;

namespace FluentJdf.Schema {
    /// <summary>
    /// Loads an XmlSchemaSet from resources and makes it available for use.
    /// </summary>
    public class SchemaSet {
        ILog logger = LogManager.GetLogger(typeof(SchemaSet));

        const string RelativeSchemaDir = "schema";

        /// <summary>
        /// Get the singleton instance
        /// </summary>
        public static SchemaSet Instance = new SchemaSet();

        private SchemaSet() {
            var schemaDir = Path.Combine(ApplicationInformation.Directory, RelativeSchemaDir);
            if (!SchemaHasBeenCopied(schemaDir)) {
                try {

                    if (Directory.Exists(schemaDir)) {
                        Directory.Delete(schemaDir, true);
                    }
                    Directory.CreateDirectory(schemaDir);

                    var assembly = GetType().Assembly;
                    var schemaResourcePrefix = string.Format("{0}.Resources.Schema.", assembly.GetName().Name);
                    var resources = assembly.GetManifestResourceNames();
                    foreach (var resource in resources.Where(r => r.StartsWith(schemaResourcePrefix))) {
                        var filename = Path.Combine(schemaDir, resource.Replace(schemaResourcePrefix, string.Empty));
                        using (var stream = new FileStream(filename, FileMode.CreateNew)) {
                            using (var manifestStream = assembly.GetManifestResourceStream(resource)) {
                                manifestStream.CopyTo(stream);
                            }
                        }
                    }
                }
                catch (Exception err) {
                    logger.ErrorFormat(Messages.Loader_Loader_FailedToLoadAndCompileSchema, err);
                    throw;
                }
            }

            Schemas = new XmlSchemaSet();
            Schemas.Add(Globals.JdfNamespace.NamespaceName, Path.Combine(schemaDir, "jdf.xsd"));
            Schemas.Compile();
        }

        /// <summary>
        /// Ensure we have already copied the files and they are at v1.4
        /// </summary>
        /// <remarks>Item may be in appdomain (LinqPad) and we will fail if we don't verify first.</remarks>
        /// <param name="schemaDir">The directory to verify.</param>
        /// <returns></returns>
        private bool SchemaHasBeenCopied(string schemaDir) {
            try {
                if (!Directory.Exists(schemaDir)) {
                    return false;
                }

                var assembly = GetType().Assembly;
                var schemaResourcePrefix = string.Format("{0}.Resources.Schema.", assembly.GetName().Name);
                var resources = assembly.GetManifestResourceNames();
                foreach (var resource in resources.Where(r => r.StartsWith(schemaResourcePrefix))) {
                    var filename = Path.Combine(schemaDir, resource.Replace(schemaResourcePrefix, string.Empty));

                    if (File.Exists(filename)) {
                        //TODO we want to validate the version at some point
                    }
                    else {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception err) {
                logger.ErrorFormat(Messages.FailedToValidateExistingJDFSchemaFolderTheErrorIs0, err);
            }
            return false;
        }

        /// <summary>
        /// Gets the schema set.
        /// </summary>
        public XmlSchemaSet Schemas {
            get;
            private set;
        }
    }
}
