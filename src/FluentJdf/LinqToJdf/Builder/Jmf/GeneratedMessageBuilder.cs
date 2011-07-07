using System;
using System.Collections.Generic;
using FluentJdf.TemplateEngine;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
    /// <summary>
    /// Builder to configure and generate a ticket from a template.
    /// </summary>
    public class GeneratedMessageBuilder
    {
        GeneratedDocumentBuilderHelper generatedDocumentBuilderHelper;

        internal GeneratedMessageBuilder(Template template)
        {
            ParameterCheck.ParameterRequired(template, "template");

            generatedDocumentBuilderHelper = new GeneratedDocumentBuilderHelper(template);
        }

        /// <summary>
        /// Generates the message.
        /// </summary>
        /// <returns></returns>
        public Message Generate()
        {
            return generatedDocumentBuilderHelper.Generate().ToMessage();
        }

        /// <summary>
        /// Adds a name/value pair for variable replacement.
        /// </summary>
        /// <param name="name">The name.  Must be unique.</param>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentException">If name already exists in the collection.</exception>
        public GeneratedMessageBuilder NameValue(string name, object value)
        {
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
        /// Use ID values found in the template.
        /// </summary>
        /// <returns></returns>
        public GeneratedMessageBuilder IdValuesFromTemplate() {
            generatedDocumentBuilderHelper.IdValuesFromTemplate();
            return this;
        }

        /// <summary>
        /// Make all ids in the document unique.
        /// </summary>
        /// <returns></returns>
        /// <remarks>This is the default.</remarks>
        public GeneratedMessageBuilder UniqueIds() {
            generatedDocumentBuilderHelper.UniqueIds();
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
    }
}