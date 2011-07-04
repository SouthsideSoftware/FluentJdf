using System;
using System.IO;
using System.Xml.Linq;
using FluentJdf.Configuration;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.Encoding {
    /// <summary>
    /// Implementation of transmission part factory.
    /// </summary>
    public class TransmissionPartFactory : ITransmissionPartFactory {
        #region ITransmissionPartFactory Members

        /// <summary>
        /// Create a transmission part.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="data"></param>
        /// <param name="mimeType"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public ITransmissionPart CreateTransmissionPart(string name, Stream data, string mimeType, string id = null) {
            ParameterCheck.StringRequiredAndNotWhitespace(name, "name");
            ParameterCheck.ParameterRequired(data, "data");
            ParameterCheck.StringRequiredAndNotWhitespace(mimeType, "mimeType");

            //todo: detect actual mime type if document is xml

            ITransmissionPart transmissionPart;
            if (FluentJdfLibrary.Settings.TransmissionPartSettings.TransmissionPartsByMimeType.ContainsKey(mimeType)) {
                transmissionPart =
                    Infrastructure.Core.Configuration.Settings.ServiceLocator.Resolve<ITransmissionPart>(
                        FluentJdfLibrary.Settings.TransmissionPartSettings.TransmissionPartsByMimeType[mimeType].FullName);
            }
            else {
                transmissionPart =
                    Infrastructure.Core.Configuration.Settings.ServiceLocator.Resolve<ITransmissionPart>(
                        FluentJdfLibrary.Settings.TransmissionPartSettings.DefaultTransmissionPart.FullName);
            }

            transmissionPart.Initialize(name, data, mimeType, id);
            return transmissionPart;
        }

        /// <summary>
        /// Creates a transmission part based on an <see cref="XDocument"/>.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="doc"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <remarks>If the root is JDF, the part type registered for the JDF mime type is used.
        /// If the root is JMF, the part type registered for the JMF mime type is used.
        /// Otherwise, the part type registered for the generic xml mime type is used.</remarks>
        public ITransmissionPart CreateTransmissionPart(string name, XDocument doc, string id) {
            //todo: implement and use
            throw new NotImplementedException();
        }

        #endregion
    }
}