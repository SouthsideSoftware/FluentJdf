using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using FluentJdf.LinqToJdf;

namespace FluentJdf.Transmission {

    /// <summary>
    /// Collection of FileTransmitterEncoderConfigurationItem objects.
    /// </summary>
    [Serializable]
    public class FileTransmitterEncoderConfigurationCollection : IEnumerable<FileTransmitterEncoderConfigurationItem> {

        private Dictionary<string, FileTransmitterEncoderConfigurationItem> _items
            = new Dictionary<string, FileTransmitterEncoderConfigurationItem>(StringComparer.OrdinalIgnoreCase);
        private Dictionary<string, FileTransmitterEncoderConfigurationItem> _itemsByUrlBase
            = new Dictionary<string, FileTransmitterEncoderConfigurationItem>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Constructor.
        /// </summary>
        public FileTransmitterEncoderConfigurationCollection() {

        }

        /// <summary>
        /// Gets the number of members.
        /// </summary>
        public int Count {
            get {
                return _items.Count;
            }
        }

        /// <summary>
        /// Add a member.
        /// </summary>
        /// <param name="item">Member to add.</param>
        public void Add(FileTransmitterEncoderConfigurationItem item) {
            Uri uri = new Uri(item.UrlBase);
            string itemPath = Path.GetDirectoryName(uri.LocalPath);
            //itemPath will be null if the Url points at the root of a drive.  Use the Uri local path in that case.
            if (itemPath == null) {
                itemPath = uri.LocalPath;
            }
            if (_items.ContainsKey(item.Id)) {
                throw new JdfException(string.Format("Collection already contains a FileTransmitterEncoderConfigurationItem with ID={0}", item.Id));
            }
            else if (_itemsByUrlBase.ContainsKey(itemPath)) {
                throw new JdfException(string.Format("Collection already contains a FileTransmitterEncoderConfigurationItem with BaseUrl={0}", item.UrlBase));
            }
            else {
                _items.Add(item.Id, item);
                _itemsByUrlBase.Add(itemPath, item);
            }
        }

        /// <summary>
        /// Gets configuration item for URI (strips off name before search)
        /// </summary>
        public FileTransmitterEncoderConfigurationItem this[Uri uri] {
            get {
                FileTransmitterEncoderConfigurationItem retVal = null;
                _itemsByUrlBase.TryGetValue(Path.GetDirectoryName(uri.LocalPath), out retVal);
                return retVal;
            }
        }

        /// <summary>
        /// Gets the FileTransmitterEncoderConfigurationItem with the given id.
        /// Returns null if no item with that id is in the collection.
        /// </summary>
        public FileTransmitterEncoderConfigurationItem this[string id] {
            get {
                FileTransmitterEncoderConfigurationItem retVal = null;
                _items.TryGetValue(id, out retVal);
                return retVal;
            }
        }

        /// <summary>
        /// Gets an enumerator over the FileTransmitterEncoderConfigurationItem objects
        /// in the collection.
        /// </summary>
        /// <returns>An enumerator over FileTransmitterEncoderConfigurationItem objects</returns>
        public IEnumerator<FileTransmitterEncoderConfigurationItem> GetEnumerator() {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets an enumerator over the FileTransmitterEncoderConfigurationItem objects
        /// in the collection.
        /// </summary>
        /// <returns>An enumerator over FileTransmitterEncoderConfigurationItem objects</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            throw new NotImplementedException();
        }

        internal void Dump() {
            Trace.WriteLine("*********** FileTransmitterEncoderConfigurationCollection *************");
            Trace.Indent();
            try {
                foreach (FileTransmitterEncoderConfigurationItem item in this) {
                    item.Dump();
                }
            }
            finally {
                Trace.Unindent();
            }
        }
    }
}
