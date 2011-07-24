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
    public class FileTransmissionItem : ITransmissionPart, IComparable, IDisposable {

        private TempFileStream stream;
        private Uri destinationUrl;
        private int order;
        private ITransmissionPart part;
        private string mimeType;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="part">The original part.</param>
        /// <param name="stream">Stream to send.</param>
        /// <param name="destinationUrl">Fully-qualified destination URL.</param>
        /// <param name="mimeType">The mimeType</param>
        /// <param name="order">The order of this item for sending.</param>
        public FileTransmissionItem(ITransmissionPart part, Stream stream, Uri destinationUrl, string mimeType, int order) {
            this.part = part;
            if (stream.CanSeek) {
                stream.Seek(0, SeekOrigin.Begin);
            }
            this.stream = new TempFileStream();
            stream.CopyTo(this.stream);
            this.destinationUrl = destinationUrl;
            this.mimeType = mimeType;
            this.order = order;
        }

        /// <summary>
        /// Gets the TransmissionPart associated with
        /// this item.  May be null.
        /// </summary>
        public ITransmissionPart Part {
            get {
                return part;
            }
        }

        /// <summary>
        /// Get stream for this item.
        /// </summary>
        public Stream Stream {
            get {
                return stream;
            }
        }

        /// <summary>
        /// Get destination for this item.
        /// </summary>
        public Uri DestinationUri {
            get {
                return destinationUrl;
            }
        }

        /// <summary>
        /// Gets the sending order of this item.
        /// </summary>
        public int Order {
            get {
                return order;
            }
        }

        /// <summary>
        /// Compare the ordering of this item with a given item.
        /// </summary>
        /// <param name="obj">The object to compare to.</param>
        /// <returns>0 if obj is null or not a FileTransmissionItem.  Otherwise 0, -1, 1 for equals, less-than and greater-than.</returns>
        public int CompareTo(object obj) {
            if (obj is FileTransmissionItem) {
                return order.CompareTo(((FileTransmissionItem)obj).Order);
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
                if (stream != null) {
                    stream.Dispose();
                    stream = null;
                }
            }
        }

        /// <summary>
        /// Destructor
        /// </summary>
        ~FileTransmissionItem() {
            Dispose(false);
        }

        /// <summary>
        /// CopyOfStream
        /// </summary>
        /// <returns></returns>
        public Stream CopyOfStream() {
            return Stream;
        }

        /// <summary>
        /// Name
        /// </summary>
        public string Name {
            get {
                return DestinationUri.ToString();
            }
        }

        /// <summary>
        /// Id
        /// </summary>
        public string Id {
            get {
                return Order.ToString();
            }
        }

        /// <summary>
        /// MimeType
        /// </summary>
        public string MimeType {
            get {
                return mimeType;
            }
        }

        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="name"></param>
        /// <param name="stream"></param>
        /// <param name="mimeType"></param>
        /// <param name="id"></param>
        public void Initialize(string name, Stream stream, string mimeType, string id = null) {
            //do nothing
        }
    }
}
