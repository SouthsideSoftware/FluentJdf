using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Jdp.Jdf.Schema;

namespace Jdp.Jdf.LinqToJdf
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
        public void ValidateJdf(bool addSchemaInfo = true) {
            validator.Validate(addSchemaInfo);
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
