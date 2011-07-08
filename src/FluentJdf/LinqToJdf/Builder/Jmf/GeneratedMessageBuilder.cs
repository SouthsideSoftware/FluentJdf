using System;
using System.Collections.Generic;
using System.IO;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
    /// <summary>
    /// Builder to configure and generate a ticket from a template.
    /// </summary>
    public class GeneratedMessageBuilder {
        readonly GeneratedDocumentBuilderHelper generatedDocumentBuilderHelper;

        internal GeneratedMessageBuilder(String templateFileName) {
            ParameterCheck.StringRequiredAndNotWhitespace(templateFileName, "templateFileName");
            
            generatedDocumentBuilderHelper = new GeneratedDocumentBuilderHelper(templateFileName);
        }

        internal GeneratedMessageBuilder(Stream templateStream) {
            ParameterCheck.ParameterRequired(templateStream, "templateStream");

            generatedDocumentBuilderHelper = new GeneratedDocumentBuilderHelper(templateStream);
        }

        /// <summary>
        /// Generates the message.
        /// </summary>
        /// <returns></returns>
        public Message Generate() {
            return generatedDocumentBuilderHelper.Generate().ToMessage();
        }

        /// <summary>
        /// Adds a name/value pair for variable replacement.
        /// </summary>
        /// <param name="name">The name.  Must be unique.</param>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentException">If name already exists in the collection.</exception>
        public GeneratedMessageBuilder NameValue(string name, object value) {
            generatedDocumentBuilderHelper.NameValue(name, value);
            return this;
        }

        /// <summary>
        /// Adds all the name value pairs for variable replacement.
        /// </summary>
        /// <param name="nameValues"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">If any of the names already exist in the collection.</exception>
        public GeneratedMessageBuilder NameValues(IEnumerable<KeyValuePair<string, object>> nameValues) {
            generatedDocumentBuilderHelper.NameValues(nameValues);
            return this;
        }

        /// <summary>
        /// Do not generate new id values for the document.
        /// </summary>
        /// <returns></returns>
        public GeneratedMessageBuilder DoNotGenerateNewUniqueIds()
        {
            generatedDocumentBuilderHelper.DoNotGenerateNewUniqueIds();
            return this;
        }

        /// <summary>
        /// Generate new unique ids for all ID attributes in the document.
        /// Also fixes up references.
        /// </summary>
        /// <returns></returns>
        /// <remarks>This is the default.</remarks>
        public GeneratedMessageBuilder GenerateNewUniqueIds()
        {
            generatedDocumentBuilderHelper.GenerateNewUniqueIds();
            return this;
        }

        /// <summary>
        /// Sets the job id of the instance.
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public GeneratedMessageBuilder JobId(string jobId) {
            generatedDocumentBuilderHelper.JobId(jobId);
            return this;
        }

        /// <summary>
        /// Generates a unique JobID for the instance.
        /// </summary>
        /// <returns></returns>
        /// <remarks>This is the default.</remarks>
        public GeneratedMessageBuilder UniqueJobId() {
            generatedDocumentBuilderHelper.UniqueJobId();
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
        public GeneratedMessageBuilder CustomFormula(string name, Func<string> customFunction) {
            generatedDocumentBuilderHelper.CustomFormula(name, customFunction);
            return this;
        }
    }
}