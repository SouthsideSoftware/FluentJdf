using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
        string templateFileName;
        Stream templateStream;
        Dictionary<string, object> nameValues;
        string jobId;
        bool makeIdsUnique = true;
        Dictionary<string, Func<string>> customFormulas;

        internal GeneratedDocumentBuilderHelper(string templateFileName) {
            ParameterCheck.StringRequiredAndNotWhitespace(templateFileName, "templateFileName");

            Initialize();
            this.templateFileName = templateFileName;
        }

        void Initialize() {
            nameValues = new Dictionary<string, object>();
            customFormulas = new Dictionary<string, Func<string>>();
        }

        internal GeneratedDocumentBuilderHelper(Stream templateStream) {
            ParameterCheck.ParameterRequired(templateStream, "templateStream");

            Initialize();
            this.templateStream = templateStream;
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
        /// Do not generate new id values for the document.
        /// </summary>
        /// <returns></returns>
        public GeneratedDocumentBuilderHelper DoNotGenerateNewUniqueIds() {
            makeIdsUnique = false;
            return this;
        }

        /// <summary>
        /// Generate new unique ids for all ID attributes in the document.
        /// Also fixes up references.
        /// </summary>
        /// <returns></returns>
        /// <remarks>This is the default.</remarks>
        public GeneratedDocumentBuilderHelper GenerateNewUniqueIds() {
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
        /// Adds a custom formula for use in this template.
        /// </summary>
        /// <param name="name">The name of the custom formula.  Is case sensitive.</param>
        /// <param name="customFunction">The custom function that returns a string.</param>
        /// <returns></returns>
        /// <remarks>The result of the custom function will be used for replacement if
        /// there is no replacement defined in the name values for the variable.</remarks>
        public GeneratedDocumentBuilderHelper CustomFormula(string name, Func<string> customFunction) {
            ParameterCheck.StringRequiredAndNotWhitespace(name, "name");
            ParameterCheck.ParameterRequired(customFunction, "customFunction");

            customFormulas[name] = customFunction;
            return this;
        }

        /// <summary>
        /// Generate the document.
        /// </summary>
        /// <returns></returns>
        internal XDocument Generate() {
            Template template;
            if (templateStream != null) {
                template = new Template(templateStream, Globals.CreateUniqueId("Template_"), customFormulas);
            } else {
                template = new Template(templateFileName, customFormulas);
            }
            return template.Generate(nameValues, jobId, makeIdsUnique);
        }
    }
}
