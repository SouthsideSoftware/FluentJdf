using Infrastructure.Core.Logging;

namespace FluentJdf.LinqToJdf
{
    /// <summary>
    /// Starting point for creating JDF tickets.
    /// </summary>
    public class Ticket : FluentJdfDocumentBase {
        static ILog logger = LogManager.GetLogger(typeof (FluentJdfDocumentBase));

        /// <summary>
        /// Constructor.
        /// </summary>
        private Ticket() {
        }

        /// <summary>
        /// Create a new JDF ticket
        /// </summary>
        /// <returns></returns>
        public static Ticket Create() {
            return new Ticket();
        }

        /// <summary>
        /// Validate the document.
        /// </summary>
        /// <param name="addSchemaInfo"></param>
        public Ticket ValidateJdf(bool addSchemaInfo = true)
        {
            validator.Validate(addSchemaInfo);
            return this;
        }
    }
}
