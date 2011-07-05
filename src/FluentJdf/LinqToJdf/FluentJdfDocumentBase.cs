using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using FluentJdf.Resources;
using FluentJdf.Schema;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf {
    //todo: provide option to pass override JdfAuthoringSettings configuration to constructor and use throughout
    /// <summary>
    /// Base class for XDocument descendants in FluentJDF.
    /// </summary>
    public abstract class FluentJdfDocumentBase : XDocument {
        /// <summary>
        /// Gets and sets the validator.
        /// </summary>
        protected Validator validator;

        /// <summary>
        /// Constructor.
        /// </summary>
        protected FluentJdfDocumentBase() {
            Initialize();
        }

        void Initialize() {
            validator = new Validator(this);
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="document"></param>
        public FluentJdfDocumentBase(XDocument document) : base(document) {
            if (document.Root == null) {
                throw new ArgumentException(Resources.Messages.FluentJdfDocumentBase_FluentJdfDocumentBase_FluentJDF_RootNodeRequired);
            }
            Initialize();
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
        /// Gets the current collection of validation warnings and errors.
        /// </summary>
        public IList<ValidationMessage> ValidationMessages { get { return validator.Messages; } }

        /// <summary>
        /// Gets true if the document has been validated at least once.
        /// </summary>
        /// <remarks>A return of true only means the document was 
        /// validuated at some point.  It does not mean it was
        /// validated in its current state.</remarks>
        public bool HasBeenValidatedAtLeastOnce { get { return validator.HasValidatedAtLeastOnce; } }

        /// <summary>
        /// This saves the document to a stream
        /// using UTF8 encoding, no byte markers 
        /// formatted with indentation and each element
        /// on a newline.
        /// </summary>
        /// <param name="stream"></param>
        /// <remarks></remarks>
        public void SaveHttpReady(Stream stream) {
            ParameterCheck.ParameterRequired(stream, "stream");

            if (stream.CanSeek) {
                stream.Seek(0, SeekOrigin.Begin);
            }

            var xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.Encoding = new UTF8Encoding(false);
            xmlWriterSettings.Indent = true;
            using (var writer = XmlWriter.Create(stream, xmlWriterSettings)) {
                Save(writer);
            }
        }
    }
}