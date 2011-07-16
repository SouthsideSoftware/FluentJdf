using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.Transmission {

    /// <summary>
    /// Configuration of a file transmitter encoder
    /// </summary>
    [Serializable]
    public class FileTransmitterEncoderConfigurationItem {
        private string _id, _urlBase;
        private bool _useMime = false;
        private FileTransmitterFolderInfoConfigurationCollection _folderInfoConfigurationCollection;
        private IDictionary<string, string> _nameValues;

        /// <summary>
        /// Constructior.
        /// </summary>
        /// <param name="id">Unique identifier.</param>
        /// <param name="type">.NET type which implements IFileTransmitterEncoder</param>
        /// <param name="uriBase">URIs that begin with this string will be processed by this encoder.</param>
        /// <param name="useMime">True to encode the entire transmission as a mime file.</param>
        /// <param name="folderInfoConfigurationCollection">Folder info associatred with this item.</param>
        /// <param name="nameValues">Additional configuration information in name/value pairs.</param>
        public FileTransmitterEncoderConfigurationItem(string id, string type, string uriBase, bool useMime,
            FileTransmitterFolderInfoConfigurationCollection folderInfoConfigurationCollection, IDictionary<string, string> nameValues) {

            ParameterCheck.ParameterRequired(id, "id");
            ParameterCheck.ParameterRequired(uriBase, "uriBase");

            _id = id;
            _urlBase = uriBase;
            if (!_urlBase.EndsWith("\\")) {
                _urlBase = _urlBase + "\\";
            }
            _useMime = useMime;
            _nameValues = nameValues ?? new Dictionary<string, string>();
            _folderInfoConfigurationCollection = folderInfoConfigurationCollection ?? new FileTransmitterFolderInfoConfigurationCollection();
        }

        /// <summary>
        /// Gets the unique ID
        /// </summary>
        public string Id {
            get {
                return _id;
            }
        }

        /// <summary>
        /// Gets the URI base of this item.
        /// </summary>
        public string UrlBase {
            get {
                return _urlBase;
            }
        }

        /// <summary>
        /// Gets true if this encoder should use mime to package the parts
        /// </summary>
        public bool UseMime {
            get {
                return _useMime;
            }
        }

        /// <summary>
        /// Gets the folder info associated with this configuration item
        /// </summary>
        public FileTransmitterFolderInfoConfigurationCollection FolderInfoConfigurationCollection {
            get {
                return _folderInfoConfigurationCollection;
            }
        }

        /// <summary>
        /// Get a string representation of this object.
        /// </summary>
        /// <returns>A string with information about the object.</returns>
        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Id: {0} Url Base: {1} Use Mime: {2}",
                _id, _urlBase, _useMime);
            return sb.ToString();
        }

        /// <summary>
        /// Dump diagnostic information to the attached trace listeners.
        /// </summary>
        public void Dump() {
            Trace.WriteLine("FileTransmitterConfigurationItem" + ToString());
            Trace.Indent();
            try {
                _folderInfoConfigurationCollection.Dump();
                Trace.WriteLine("Name Values");
                Trace.Indent();
                try {
                    foreach (string key in _nameValues.Keys) {
                        Trace.WriteLine(string.Format("{0}={1}", key, _nameValues[key]));
                    }
                }
                finally {
                    Trace.Unindent();
                }
            }
            finally {
                Trace.Unindent();
            }
        }
    }
}
