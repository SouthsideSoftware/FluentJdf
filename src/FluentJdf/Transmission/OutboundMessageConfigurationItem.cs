using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace FluentJdf.Transmission {
    /// <summary>
    /// Represents the configuration of a single outbound message descendant. Which contains HandlerConfigurationCollection.
    /// </summary>
    public class OutboundMessageConfigurationItem {
        private MessageHandlerConfigurationCollection _handlers;
        private bool _readOnly = false;

        /// <summary>
        /// Used internally by JDP.  Objective Advantage, Inc. may change these
        /// internally used classes and methods.
        /// </summary>
        public OutboundMessageConfigurationItem(MessageHandlerConfigurationCollection handlers) {
            if (handlers == null) {
                _handlers = new MessageHandlerConfigurationCollection();
            }
            else {
                _handlers = handlers;
            }
        }

        /// <summary>
        /// Used internally by JDP.  Objective Advantage, Inc. may change these
        /// internally used classes and methods.
        /// </summary>
        private OutboundMessageConfigurationItem(OutboundMessageConfigurationItem original, bool readOnly) :
            this(original.Handlers.Copy(readOnly)) {
            _readOnly = readOnly;
        }


        /// <summary>
        /// Used internally by JDP.  Objective Advantage, Inc. may change these
        /// internally used classes and methods.
        /// </summary>
        public MessageHandlerConfigurationCollection Handlers {
            get {
                return _handlers;
            }
        }

        /// <summary>
        /// Used internally by JDP.  Objective Advantage, Inc. may change these
        /// internally used classes and methods.
        /// </summary>
        public OutboundMessageConfigurationItem Copy() {
            return new OutboundMessageConfigurationItem(_handlers.Copy());
        }

        /// <summary>
        /// Used internally by JDP.  Objective Advantage, Inc. may change these
        /// internally used classes and methods.
        /// </summary>
        public void CopyFrom(OutboundMessageConfigurationItem item) {
            _handlers.CopyFrom(item.Handlers);
        }

        /// <summary>
        /// Used internally by JDP.  Objective Advantage, Inc. may change these
        /// internally used classes and methods.
        /// </summary>
        public virtual void Dump() {
            Trace.Indent();
            try {
                Trace.WriteLine(ToString());
                _handlers.Dump();
            }
            finally {
                Trace.Unindent();
            }
        }

        /// <summary>
        /// Used internally by JDP.  Objective Advantage, Inc. may change these
        /// internally used classes and methods.
        /// </summary>
        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("OutboundHandler");
            return sb.ToString();
        }

        /// <summary>
        /// Used internally by JDP.  Objective Advantage, Inc. may change these
        /// internally used classes and methods.
        /// </summary>
        internal OutboundMessageConfigurationItem Copy(bool readOnly) {
            OutboundMessageConfigurationItem clone = new OutboundMessageConfigurationItem(this, readOnly);
            return clone;
        }
    }
}
