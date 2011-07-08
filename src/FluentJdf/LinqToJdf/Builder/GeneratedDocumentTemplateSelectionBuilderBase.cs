using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using FluentJdf.Resources;
using FluentJdf.TemplateEngine;
using Infrastructure.Core.CodeContracts;
using Infrastructure.Core.Helpers;

namespace FluentJdf.LinqToJdf.Builder
{
    /// <summary>
    /// Builder to select template for document generation.
    /// </summary>
    public class GeneratedDocumentTemplateSelectionBuilderBase {
        /// <summary>
        /// Gets the template stream.  Will be <see langword="null"/>
        /// if filename is set.
        /// </summary>
        protected Stream TemplateStream { get; private set; }

        /// <summary>
        /// Gets the file name.  Will be <see langword="null"/> if stream is set.
        /// </summary>
        protected string TemplateFileName { get; private set; }

        internal GeneratedDocumentTemplateSelectionBuilderBase(string templateFileName) {
            ParameterCheck.StringRequiredAndNotWhitespace(templateFileName, "templateFileName");
            TemplateFileName = templateFileName;
        }

        internal GeneratedDocumentTemplateSelectionBuilderBase(Stream templateStream) {
            ParameterCheck.ParameterRequired(templateStream, "templateStream");

            TemplateStream = templateStream;
        }
    }
}
