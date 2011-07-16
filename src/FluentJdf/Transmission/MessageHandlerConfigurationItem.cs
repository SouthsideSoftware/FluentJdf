using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using FluentJdf.LinqToJdf;

namespace FluentJdf.Transmission {

    /// <summary>
    /// Used internally by JDP.  Objective Advantage, Inc. may change these
    /// internally used classes and methods.
    /// </summary>
    public class MessageHandlerConfigurationItem : JdpTypeHoldingConfigurationItem {
        private bool _isHandler;
        private bool _isFilter;
        private Dictionary<string,string> _nameValues;

        /// <summary>
        /// Used internally by JDP.  Objective Advantage, Inc. may change these
        /// internally used classes and methods.
        /// </summary>
        public MessageHandlerConfigurationItem(bool isHandler, bool isFilter, string type, Dictionary<string, string> nameValues)
            : base(type) {
            if (isHandler == false && isFilter == false) {
                throw new JdfException("Handler configuration item must have at least handler=\"true\" or filter=\"true\".");
            }

            _isHandler = isHandler;
            _isFilter = isFilter;
            _nameValues = new Dictionary<string,string>();
            //do replacement on name values 
            foreach (string key in nameValues.Keys) {
                _nameValues.Add(key, FileTransmissionConfig.FixupConfigItemPath(nameValues[key]));
            }
        }

        /// <summary>
        /// Used internally by JDP.  Objective Advantage, Inc. may change these
        /// internally used classes and methods.
        /// </summary>
        private MessageHandlerConfigurationItem(MessageHandlerConfigurationItem original, bool readOnly) :
            this(original.IsHandler, original.IsFilter, String.Copy(original.TypeName), new Dictionary<string, string>(original.NameValues)) {
            _readOnly = readOnly;
        }

        /// <summary>
        /// Used internally by JDP.  Objective Advantage, Inc. may change these
        /// internally used classes and methods.
        /// </summary>
        public bool IsHandler {
            get {
                return _isHandler;
            }
        }

        /// <summary>
        /// Used internally by JDP.  Objective Advantage, Inc. may change these
        /// internally used classes and methods.
        /// </summary>
        public bool IsFilter {
            get {
                return _isFilter;
            }
        }

        /// <summary>
        /// Used internally by JDP.  Objective Advantage, Inc. may change these
        /// internally used classes and methods.
        /// </summary>
        public Dictionary<string, string> NameValues {
            get {
                return _nameValues;
            }
        }

        /// <summary>
        /// Used internally by JDP.  Objective Advantage, Inc. may change these
        /// internally used classes and methods.
        /// </summary>
        public override void Dump() {
            Trace.Indent();
            Trace.WriteLine(ToString());
            Trace.Unindent();
        }

        /// <summary>
        /// Used internally by JDP.  Objective Advantage, Inc. may change these
        /// internally used classes and methods.
        /// </summary>
        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Handler Class: {0} Assembly {1} IsFilter = {2} IsHandler = {3} NameValues {4}",
                _className, _assemblyName, _isFilter.ToString(), _isHandler.ToString(), NameValuesToString());
            return sb.ToString();
        }

        /// <summary>
        /// Used internally by JDP.  Objective Advantage, Inc. may change these
        /// internally used classes and methods.
        /// </summary>
        public string NameValuesToString() {
            StringBuilder sb = new StringBuilder();
            if (_nameValues == null || _nameValues.Count == 0) {
                sb.Append("[NULL]");
            }
            else {
                foreach (string key in _nameValues.Keys) {
                    sb.AppendFormat("{0}={1} ", key, _nameValues[key]);
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Used internally by JDP.  Objective Advantage, Inc. may change these
        /// internally used classes and methods.
        /// </summary>
        internal MessageHandlerConfigurationItem Copy(bool readOnly) {
            MessageHandlerConfigurationItem clone = new MessageHandlerConfigurationItem(this, readOnly);
            return clone;
        }
    }
}
