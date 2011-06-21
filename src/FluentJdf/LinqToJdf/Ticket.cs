using System;
using System.IO;
using System.Xml.Linq;
using FluentJdf.Resources;
using Infrastructure.Core.CodeContracts;
using Infrastructure.Core.Logging;

namespace FluentJdf.LinqToJdf
{
    /// <summary>
    /// Starting point for creating JDF tickets.
    /// </summary>
    public class Ticket : FluentJdfDocumentBase {
        static ILog logger = LogManager.GetLogger(typeof (FluentJdfDocumentBase));
        internal const string Intent = "Product";
        internal const string ProcessGroup = "ProcessGroup";

        /// <summary>
        /// Constructor.
        /// </summary>
        private Ticket() : this(Intent) {
        }

        private Ticket(params string [] types) {
            if (types == null || types.Length == 0) {
                types = new string[] {Intent};
            }
        }

        /// <summary>
        /// Loads the ticket from a stream.
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public new static Ticket Load(Stream stream)
        {
            return new Ticket(XDocument.Load(stream));
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="document"></param>
        public Ticket(XDocument document) : base(document) {
            document.Root.ThrowExceptionIfNotJdfElement();            
        }

        /// <summary>
        /// Gets the builder for the root.
        /// </summary>
        /// <returns></returns>
        public JdfNodeBuilder ModifyJdfNode()
        {
            if (Root == null || !Root.IsJdfElement())
            {
                throw new Exception(Messages.Ticket_ModifyJdfNode_RootMustExistAndBeJdf);
            }

            return new JdfNodeBuilder(Root);
        }

        /// <summary>
        /// Create a new JDF intent ticket.
        /// </summary>
        /// <returns></returns>
        public static JdfNodeBuilder CreateIntent() {
            return new JdfNodeBuilder(new Ticket(Intent));
        }

        /// <summary>
        /// Create a new JDF ticket with a process node at the root.
        /// </summary>
        /// <returns></returns>
        public static JdfNodeBuilder CreateProcess(params string [] types)
        {
            if (types == null || types.Length == 0) {
                throw new ArgumentException(Messages.AtLeastOneProcessMustBeSpecified);
            }
            return new JdfNodeBuilder(new Ticket(types));
        }

        /// <summary>
        /// Create a new JDF ticket with a process group node at the root.
        /// </summary>
        /// <returns></returns>
        public static JdfNodeBuilder CreateProcessGroup()
        {
            return new JdfNodeBuilder(new Ticket(ProcessGroup));
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
