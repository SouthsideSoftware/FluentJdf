using System;
using System.Collections.Generic;
using System.IO;
using FluentJdf.TemplateEngine;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jdf {
    /// <summary>
    /// Builder to configure and generate a ticket from a template.
    /// </summary>
    public class GeneratedTicketBuilder {
        readonly GeneratedDocumentBuilderHelper generatedDocumentBuilderHelper;

        internal GeneratedTicketBuilder(string templateFileName) {
            ParameterCheck.StringRequiredAndNotWhitespace(templateFileName, "templateFileName");

            generatedDocumentBuilderHelper = new GeneratedDocumentBuilderHelper(templateFileName);
        }

        internal GeneratedTicketBuilder(Stream templateStream)
        {
            ParameterCheck.ParameterRequired(templateStream, "templateStream");

            generatedDocumentBuilderHelper = new GeneratedDocumentBuilderHelper(templateStream);
        }

        /// <summary>
        /// Generates the ticket.
        /// </summary>
        /// <returns></returns>
        public Ticket Generate() {
            return generatedDocumentBuilderHelper.Generate().ToTicket();
        }

        /// <summary>
        /// Adds a name/value pair for variable replacement.
        /// </summary>
        /// <param name="name">The name.  Must be unique.</param>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentException">If name already exists in the collection.</exception>
        public GeneratedTicketBuilder NameValue(string name, object value) {
            generatedDocumentBuilderHelper.NameValue(name, value);
            return this;
        }

        /// <summary>
        /// Adds all the name value pairs for variable replacement.
        /// </summary>
        /// <param name="nameValues"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">If any of the names already exist in the collection.</exception>
        public GeneratedTicketBuilder NameValues(IEnumerable<KeyValuePair<string, object>> nameValues) {
            generatedDocumentBuilderHelper.NameValues(nameValues);
            return this;
        }

        /// <summary>
        /// Do not generate new id values for the document.
        /// </summary>
        /// <returns></returns>
        public GeneratedTicketBuilder DoNotGenerateNewUniqueIds()
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
        public GeneratedTicketBuilder GenerateNewUniqueIds()
        {
            generatedDocumentBuilderHelper.GenerateNewUniqueIds();
            return this;
        }

        /// <summary>
        /// Sets the job id of the instance.
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public GeneratedTicketBuilder JobId(string jobId) {
            generatedDocumentBuilderHelper.JobId(jobId);
            return this;
        }

        /// <summary>
        /// Generates a unique JobID for the instance.
        /// </summary>
        /// <returns></returns>
        /// <remarks>This is the default.</remarks>
        public GeneratedTicketBuilder UniqueJobId() {
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
        public GeneratedTicketBuilder CustomFormula(string name, Func<string> customFunction) {
            generatedDocumentBuilderHelper.CustomFormula(name, customFunction);
            return this;
        }
    }
}