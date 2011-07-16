using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace FluentJdf.Transmission {
    /// <summary>
    /// A collection of FileTransmissionItem objects.
    /// </summary>
    public class FileTransmissionItemCollection : IEnumerable<FileTransmissionItem>, IDisposable {
        private List<FileTransmissionItem> _list = new List<FileTransmissionItem>();

        /// <summary>
        /// Constructor.
        /// </summary>
        public FileTransmissionItemCollection() {

        }

        /// <summary>
        /// Gets the number of items in the collection.
        /// </summary>
        public int Count {
            get {
                return _list.Count;
            }
        }

        /// <summary>
        /// Adds a FileTransmissionItem.
        /// </summary>
        /// <param name="item">The item to add.</param>
        public void Add(FileTransmissionItem item) {
            _list.Add(item);
            _list.Sort();
        }

        /// <summary>
        /// Gets an enumerator over the FileTransmissionItem objects in the collection.
        /// </summary>
        /// <returns>Enumerator over FileTransmissionitem objects.</returns>
        IEnumerator<FileTransmissionItem> IEnumerable<FileTransmissionItem>.GetEnumerator() {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return _list.GetEnumerator();
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Override this method to change behavior of dispose
        /// </summary>
        /// <param name="isDisposing"></param>
        protected virtual void Dispose(bool isDisposing) {
            if (isDisposing) {
                if (_list != null) {
                    foreach (FileTransmissionItem item in this) {
                        item.Dispose();
                    }
                }
            }
        }

        /// <summary>
        /// Destructor
        /// </summary>
        ~FileTransmissionItemCollection() {
            Dispose(false);
        }

    }
}
