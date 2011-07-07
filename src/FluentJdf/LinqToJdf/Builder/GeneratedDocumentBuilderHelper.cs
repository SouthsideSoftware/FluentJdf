using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using FluentJdf.Resources;
using FluentJdf.TemplateEngine;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder
{
    /// <summary>
    /// Builder for generating documents from the template engine.
    /// </summary>
    public class GeneratedDocumentBuilderHelper {
        Template template;
        Dictionary<string, object> nameValues;
        string jobId;
        bool makeIdsUnique = true;

        internal GeneratedDocumentBuilderHelper(Template template) {
            ParameterCheck.ParameterRequired(template, "template");

            this.template = template;
            nameValues = new Dictionary<string, object>();
        }

        /// <summary>
        /// Adds a name/value pair for variable replacement.
        /// </summary>
        /// <param name="name">The name.  Must be unique.</param>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentException">If name already exists in the collection.</exception>
        public GeneratedDocumentBuilderHelper NameValue(string name, object value) {
            ParameterCheck.StringRequiredAndNotWhitespace(name, "name");
            ParameterCheck.ParameterRequired(value, "value");

            if (nameValues.ContainsKey(name)) {
                throw new ArgumentException(string.Format(Messages.GeneratedDocumentConfigurationBuilder_NameValue_NameAlreadyInNameValues, name));
            }
            nameValues.Add(name, value);
            return this;
        }

        /// <summary>
        /// Adds all the name value pairs for variable replacement.
        /// </summary>
        /// <param name="nameValues"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">If any of the names already exist in the collection.</exception>
        public GeneratedDocumentBuilderHelper NameValues(IEnumerable<KeyValuePair<string, object>> nameValues) {
            ParameterCheck.ParameterRequired(nameValues, "nameValues");

            foreach (var keyValuePair in nameValues) {
                NameValue(keyValuePair.Key, keyValuePair.Value);
            }

            return this;
        }

        /// <summary>
        /// Use ID values found in the template.
        /// </summary>
        /// <returns></returns>
        public GeneratedDocumentBuilderHelper IdValuesFromTemplate() {
            makeIdsUnique = false;
            return this;
        }

        /// <summary>
        /// Make all ids in the document unique.
        /// </summary>
        /// <returns></returns>
        /// <remarks>This is the default.</remarks>
        public GeneratedDocumentBuilderHelper UniqueIds() {
            makeIdsUnique = true;
            return this;
        }

        /// <summary>
        /// Sets the job id of the instance.
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public GeneratedDocumentBuilderHelper JobId(string jobId) {
            ParameterCheck.StringRequiredAndNotWhitespace(jobId, "jobId");

            this.jobId = jobId;
            return this;
        }

        /// <summary>
        /// Generates a unique JobID for the instance.
        /// </summary>
        /// <returns></returns>
        /// <remarks>This is the default.</remarks>
        public GeneratedDocumentBuilderHelper UniqueJobId() {
            jobId = null;
            return this;
        }

        /// <summary>
        /// Generate the document.
        /// </summary>
        /// <returns></returns>
        internal XDocument Generate() {
            return template.Generate(nameValues, jobId, makeIdsUnique);
        }
    }
}
