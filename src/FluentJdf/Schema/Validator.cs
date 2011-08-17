using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Schema;
using Infrastructure.Core;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.Schema {
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
        /// Gets true if the validate method of this validator has
        /// been called at least once.
        /// </summary>
        public bool HasValidatedAtLeastOnce { get; private set; }

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
        /// <param name="addSchemaInfo">True adds default elements, default attributes and schema info to the ticket.  False leaves this alone.  Default is true.</param>
        /// <param name="workAroundMSBug">True works around an issue in the .NET framework that causes validation to work improperly on schema types that inherit 
        /// from an abstract base class if the document is created via node authoring code instead of by Parse or Load methods.  Default is true.</param>
        /// <returns></returns>
        public bool Validate(bool addSchemaInfo = true, bool workAroundMSBug = true) {
            //todo: this method should probably return ResultOf.  ResultOf needs to be taken from connent and move to common to accomplish this properly.
            messages.Clear();
            ticket.Document.Validate(SchemaSet.Instance.Schemas, (o, e) => messages.Add(new ValidationMessage(o, e.Severity, e.Message)),addSchemaInfo);
            if (workAroundMSBug) {
                using (var tempFileSream = new TempFileStream()) {
                    messages.Clear();
                    ticket.Document.Save(tempFileSream);
                    tempFileSream.Seek(0, SeekOrigin.Begin);
                    var newDocument = XDocument.Load(tempFileSream);
                    newDocument.Validate(SchemaSet.Instance.Schemas, (o, e) => messages.Add(new ValidationMessage(o, e.Severity, e.Message)),
                                         false);
                }
            }
            IsValid = messages.Where(m => m.ValidationMessageType == ValidationMessageType.Error).Count() == 0;
            Messages = new ReadOnlyCollection<ValidationMessage>(messages);
            HasValidatedAtLeastOnce = true;
            return IsValid.Value;
        }
    }
}