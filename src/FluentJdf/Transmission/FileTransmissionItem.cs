using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentJdf.Encoding;
using System.IO;
using Infrastructure.Core;

namespace FluentJdf.Transmission {

    /// <summary>
    /// An item to be sent by a file transmitter.
    /// </summary>
    public class FileTransmissionItem : IComparable, IDisposable {

        private TempFileStream _stream;
        private Uri _destinationUrl;
        private int _order;
        private ITransmissionPart _part;

        /// <summary>
        /// Constructor by part.
        /// </summary>
        /// <param name="part">TransmissionPart</param>
        /// <param name="destinationUrl">Fully-qualified destination URL.</param>
        /// <param name="order">The order of this item for sending.</param>
        public FileTransmissionItem(ITransmissionPart part, Uri destinationUrl, int order) :
            this(part.CopyOfStream(), destinationUrl, order) {
            _part = part;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="stream">Stream to send.</param>
        /// <param name="destinationUrl">Fully-qualified destination URL.</param>
        /// <param name="order">The order of this item for sending.</param>
        public FileTransmissionItem(Stream stream, Uri destinationUrl, int order) {
            if (stream.CanSeek) {
                stream.Seek(0, SeekOrigin.Begin);
            }
            _stream = new TempFileStream();
            stream.CopyTo(_stream);
            _destinationUrl = destinationUrl;
            _order = order;
        }

        /// <summary>
        /// Gets the TransmissionPart associated with
        /// this item.  May be null.
        /// </summary>
        public ITransmissionPart Part {
            get {
                return _part;
            }
        }

        /// <summary>
        /// Get stream for this item.
        /// </summary>
        public Stream Stream {
            get {
                return _stream;
            }
        }

        /// <summary>
        /// Get destination for this item.
        /// </summary>
        public Uri DestinationUri {
            get {
                return _destinationUrl;
            }
        }

        /// <summary>
        /// Gets the sending order of this item.
        /// </summary>
        public int Order {
            get {
                return _order;
            }
        }

        /// <summary>
        /// Compare the ordering of this item with a given item.
        /// </summary>
        /// <param name="obj">The object to compare to.</param>
        /// <returns>0 if obj is null or not a FileTransmissionItem.  Otherwise 0, -1, 1 for equals, less-than and greater-than.</returns>
        public int CompareTo(object obj) {
            if (obj is FileTransmissionItem) {
                return _order.CompareTo(((FileTransmissionItem)obj).Order);
            }
            else {
                return 0;
            }
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Override this method to change behavior of dispose in child classes.
        /// </summary>
        /// <param name="isDisposing"></param>
        protected virtual void Dispose(bool isDisposing) {
            if (isDisposing) {
                if (_stream != null) {
                    _stream.Dispose();
                    _stream = null;
                }
            }
        }

        /// <summary>
        /// Destructor
        /// </summary>
        ~FileTransmissionItem() {
            Dispose(false);
        }

    }
}
