using System.Collections.Generic;
using System.Xml.Linq;
using FluentJdf.Schema;

namespace FluentJdf.LinqToJdf
{
    /// <summary>
    /// Starting point for creating JDF tickets.
    /// </summary>
    public class Ticket : XDocument {
        Validator validator;

        /// <summary>
        /// Constructor.
        /// </summary>
        public Ticket() {
            validator = new Validator(this);
        }

        /// <summary>
        /// Validate the document.
        /// </summary>
        /// <param name="addSchemaInfo"></param>
        public Ticket ValidateJdf(bool addSchemaInfo = true) {
            validator.Validate(addSchemaInfo);
            return this;
        }

        /// <summary>
        /// Gets the validity of the ticket.  Null if Validate
        /// has never been called.
        /// </summary>
        public bool? IsValid{ get { return validator.IsValid; }}

        /// <summary>
        /// Gets the current collection of validation errors.
        /// </summary>
        public IList<ValidationMessage> Errors { get { return validator.Errors; }}

        /// <summary>
        /// Gets the current collection of validation warnings.
        /// </summary>
        public IList<ValidationMessage> Warnings {get { return validator.Warnings; }}

        /// <summary>
        /// Create a new JDF ticket
        /// </summary>
        /// <returns></returns>
        public static Ticket Create() {
            return new Ticket();
        }
    }
}
