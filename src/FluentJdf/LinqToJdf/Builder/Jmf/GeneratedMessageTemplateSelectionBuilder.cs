using System.IO;
using FluentJdf.LinqToJdf.Builder.Jdf;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
    /// <summary>
    /// Builder to select template for ticket generation.
    /// </summary>
    public class GeneratedMessageTemplateSelectionBuilder : GeneratedDocumentTemplateSelectionBuilderBase
    {
        internal GeneratedMessageTemplateSelectionBuilder(string templateFileName) : base(templateFileName) {}

        internal GeneratedMessageTemplateSelectionBuilder(Stream templateStream) : base(templateStream) {}

        /// <summary>
        /// Gets the builder for doing configuration and generation.
        /// </summary>
        /// <returns></returns>
        public GeneratedMessageBuilder With()
        {
            if (TemplateFileName != null) {
                return new GeneratedMessageBuilder(TemplateFileName);
            }
            return new GeneratedMessageBuilder(TemplateStream);
        }

        /// <summary>
        /// Generate a message from the template with default settings.
        /// </summary>
        /// <returns></returns>
        /// <remarks>You must use With() to add replacement
        /// variable if the template requires replacements.</remarks>
        public Message Generate() {
            if (TemplateFileName != null)
            {
                return new GeneratedMessageBuilder(TemplateFileName).Generate();
            }
            return new GeneratedMessageBuilder(TemplateStream).Generate();
        }
    }
}