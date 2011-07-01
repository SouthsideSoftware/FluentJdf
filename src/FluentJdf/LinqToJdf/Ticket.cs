using System;
using System.IO;
using System.Xml.Linq;
using FluentJdf.LinqToJdf.Builder.Jdf;
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

        /// <summary>
        /// Constructor.
        /// </summary>
        internal Ticket() {
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
                throw new Exception(Resources.Messages.Ticket_ModifyJdfNode_RootMustExistAndBeJdf);
            }

            return new JdfNodeBuilder(Root);
        }

        /// <summary>
        /// Create a new JDF intent ticket.
        /// </summary>
        /// <returns></returns>
        public static JdfNodeBuilder CreateIntent() {
            return new JdfNodeBuilder(new Ticket(), ProcessType.Intent);
        }

        /// <summary>
        /// Create a new JDF ticket with a process node at the root.
        /// </summary>
        /// <returns></returns>
        public static JdfNodeBuilder CreateProcess(params string [] types)
        {
            if (types == null || types.Length == 0) {
                throw new ArgumentException(Resources.Messages.AtLeastOneProcessMustBeSpecified);
            }
            return new JdfNodeBuilder(new Ticket(), types);
        }

        /// <summary>
        /// Create a new JDF ticket with a process group node at the root.
        /// </summary>
        /// <returns></returns>
        public static JdfNodeBuilder CreateProcessGroup()
        {
            return new JdfNodeBuilder(new Ticket(), ProcessType.ProcessGroup);
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
