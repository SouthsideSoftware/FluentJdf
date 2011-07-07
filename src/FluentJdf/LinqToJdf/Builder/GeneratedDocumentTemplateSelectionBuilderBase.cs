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
        /// Gets the template.
        /// </summary>
        protected Template Template { get; private set; }

        internal GeneratedDocumentTemplateSelectionBuilderBase(string templateFileName) {
            Template = new Template(templateFileName);
        }

        internal GeneratedDocumentTemplateSelectionBuilderBase(Stream templateStream) {
            Template = new Template(templateStream, Guid.NewGuid().ToString());           
        }
    }
}
