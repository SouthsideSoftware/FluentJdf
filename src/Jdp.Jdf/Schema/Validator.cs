using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Schema;
using Onpoint.Commons.Core.CodeContracts;

namespace Jdp.Jdf.Schema {
    /// <summary>
    /// Validates a JDF ticket.
    /// </summary>
    public class Validator {
        readonly List<ValidationMessage> messages = new List<ValidationMessage>();
        readonly XContainer ticket;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="ticket"></param>
        public Validator(XContainer ticket) {
            ParameterCheck.ParameterRequired(ticket, "ticket");

            Messages = new ReadOnlyCollection<ValidationMessage>(messages);
            this.ticket = ticket;
        }

        /// <summary>
        /// Gets a readonly collection of messages from the last
        /// validation call.  Will be empty until Validate is called
        /// for the first time.
        /// </summary>
        public IList<ValidationMessage> Messages { get; private set; }

        /// <summary>
        /// Gets a read only collection of warnings.
        /// </summary>
        public IList<ValidationMessage> Warnings {
            get { return new ReadOnlyCollection<ValidationMessage>(messages.Where(m => m.ValidationMessageType == ValidationMessageType.Warning).ToList()); }
        }

        /// <summary>
        /// Gets a read only collection of errors.
        /// </summary>
        public IList<ValidationMessage> Errors {
            get {
                return
                    new ReadOnlyCollection<ValidationMessage>(messages.Where(m => m.ValidationMessageType == ValidationMessageType.Error).ToList());
            }
        }

        /// <summary>
        /// Gets the validity state of the document.  Null until
        /// Validate is called for the first time. 
        /// </summary>
        public bool? IsValid { get; private set; }

        /// <summary>
        /// Validate the ticket and optionally add schema info (defaults and PVSI)
        /// </summary>
        /// <param name="addSchemaInfo">True adds default elements, default attributes and schema info to the ticket.  False leaves this alone.</param>
        /// <returns></returns>
        /// <remarks>the default is to add the schema info.  Override this by passing addSchemaInfo = false.</remarks>
        public bool Validate(bool addSchemaInfo = true) {
            //todo: this method should probably return ResultOf.  ResultOf needs to be taken from connent and move to common to accomplish this properly.
            messages.Clear();
            ticket.Document.Validate(SchemaSet.Instance.Schemas, (o, e) => messages.Add(new ValidationMessage(o, e.Severity, e.Message)),
                                     addSchemaInfo);
            IsValid = messages.Where(m => m.ValidationMessageType == ValidationMessageType.Error).Count() == 0;
            Messages = new ReadOnlyCollection<ValidationMessage>(messages);

            return IsValid.Value;
        }
    }
}