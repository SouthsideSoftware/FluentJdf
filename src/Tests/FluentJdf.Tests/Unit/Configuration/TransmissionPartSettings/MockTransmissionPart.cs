using System;
using System.IO;
using FluentJdf.Encoding;

namespace FluentJdf.Tests.Unit.Configuration.TransmissionPartSettings {
    public class MockTransmissionPart : ITransmissionPart {
        string id = Guid.NewGuid().ToString();

        public void Dispose() {
            throw new NotImplementedException();
        }

        public Stream CopyOfStream() {
            throw new NotImplementedException();
        }

        public string Name {
            get { throw new NotImplementedException(); }
        }

        public string Id {
            get { return id; }
        }

        public string MimeType {
            get { throw new NotImplementedException(); }
        }

        public void Initialize(string name, Stream stream, string mimeType, string id) {
            throw new NotImplementedException();
        }
    }
}