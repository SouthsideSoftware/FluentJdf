using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentJdf.LinqToJdf;

namespace FluentJdf.Transmission {
    /// <summary>
    /// Summary description for JdpEndpointConfigurationCollection.
    /// </summary>
    public class MessageHandlerConfigurationCollection : IEnumerable<MessageHandlerConfigurationItem> {
        private List<MessageHandlerConfigurationItem> _items = new List<MessageHandlerConfigurationItem>();
        private bool _readOnly = false;

        /// <summary>
        /// Used internally by JDP.  Objective Advantage, Inc. may change these
        /// internally used classes and methods.
        /// </summary>
        public MessageHandlerConfigurationCollection() {
        }

        /// <summary>
        /// Used internally by JDP.  Objective Advantage, Inc. may change these
        /// internally used classes and methods.
        /// </summary>
        public void Add(MessageHandlerConfigurationItem item) {
            if (_readOnly)
                throw new JdfException("Message Handler configuration collection");

            _items.Add(item);
        }

        /// <summary>
        /// Used internally by JDP.  Objective Advantage, Inc. may change these
        /// internally used classes and methods.
        /// </summary>
        public MessageHandlerConfigurationItem this[int index] {
            get {
                return _items[index];
            }
        }

        /// <summary>
        /// Used internally by JDP.  Objective Advantage, Inc. may change these
        /// internally used classes and methods.
        /// </summary>
        public IEnumerator<MessageHandlerConfigurationItem> GetEnumerator() {
            return _items.GetEnumerator();
        }

        /// <summary>
        /// Used internally by JDP.  Objective Advantage, Inc. may change these
        /// internally used classes and methods.
        /// </summary>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return _items.GetEnumerator();
        }

        /// <summary>
        /// Used internally by JDP.  Objective Advantage, Inc. may change these
        /// internally used classes and methods.
        /// </summary>
        public int Count {
            get {
                return _items.Count;
            }
        }

        /// <summary>
        /// Used internally by JDP.  Objective Advantage, Inc. may change these
        /// internally used classes and methods.
        /// </summary>
        public void Append(MessageHandlerConfigurationCollection coll) {
            if (_readOnly)
                throw new JdfException("Message Handler configuration collection");

            if (coll != null) {
                foreach (MessageHandlerConfigurationItem item in coll) {
                    Add(item);
                }
            }
        }

        /// <summary>
        /// Used internally by JDP.  Objective Advantage, Inc. may change these
        /// internally used classes and methods.
        /// </summary>
        public MessageHandlerConfigurationCollection Copy() {
            MessageHandlerConfigurationCollection coll = new MessageHandlerConfigurationCollection();
            foreach (MessageHandlerConfigurationItem item in this) {
                coll.Add(item);
            }
            return coll;
        }

        /// <summary>
        /// Used internally by JDP.  Objective Advantage, Inc. may change these
        /// internally used classes and methods.
        /// </summary>
        internal MessageHandlerConfigurationCollection Copy(bool readOnly) {
            MessageHandlerConfigurationCollection coll = new MessageHandlerConfigurationCollection();
            foreach (MessageHandlerConfigurationItem item in this) {
                coll.Add(item.Copy(readOnly));
            }
            coll._readOnly = readOnly;
            return coll;
        }

        /// <summary>
        /// Used internally by JDP.  Objective Advantage, Inc. may change these
        /// internally used classes and methods.
        /// </summary>
        public void CopyFrom(MessageHandlerConfigurationCollection coll) {
            _items.Clear();
            foreach (MessageHandlerConfigurationItem item in coll) {
                _items.Add(item);
            }

        }

        /// <summary>
        /// Used internally by JDP.  Objective Advantage, Inc. may change these
        /// internally used classes and methods.
        /// </summary>
        public virtual void Dump() {
            foreach (MessageHandlerConfigurationItem item in this) {
                item.Dump();
            }
        }
    }
}
