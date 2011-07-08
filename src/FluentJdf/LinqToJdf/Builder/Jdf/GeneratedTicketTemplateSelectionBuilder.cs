using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FluentJdf.LinqToJdf.Builder.Jdf
{
    /// <summary>
    /// Builder to select template for ticket generation.
    /// </summary>
    public class GeneratedTicketTemplateSelectionBuilder : GeneratedDocumentTemplateSelectionBuilderBase
    {
        internal GeneratedTicketTemplateSelectionBuilder(string templateFileName) : base(templateFileName) {}

        internal GeneratedTicketTemplateSelectionBuilder(Stream templateStream) : base(templateStream) {}

        /// <summary>
        /// Gets the builder for doing configuration and generation.
        /// </summary>
        /// <returns></returns>
        public GeneratedTicketBuilder With()
        {
            if (TemplateStream != null) {
                return new GeneratedTicketBuilder(TemplateStream);
            }
            return new GeneratedTicketBuilder(TemplateFileName);
        }

        /// <summary>
        /// Generate a ticket from the template with default settings.
        /// </summary>
        /// <returns></returns>
        /// <remarks>You must use With() to add replacement
        /// variable if the template requires replacements.</remarks>
        public Ticket Generate() {
            if (TemplateStream != null)
            {
                return new GeneratedTicketBuilder(TemplateStream).Generate();
            }
            return new GeneratedTicketBuilder(TemplateFileName).Generate();
        }
    }
}
