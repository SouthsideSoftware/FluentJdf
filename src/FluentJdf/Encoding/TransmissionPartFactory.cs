using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using FluentJdf.Configuration;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.Encoding
{
    /// <summary>
    /// Implementation of transmission part factory.
    /// </summary>
    public class TransmissionPartFactory : ITransmissionPartFactory
    {
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

            ITransmissionPart transmissionPart;
            if (Configuration.FluentJdfLibrary.Settings.TransmissionPartSettings.TransmissionPartsByMimeType.ContainsKey(mimeType))
            {
                transmissionPart = Infrastructure.Core.Configuration.Settings.ServiceLocator.Resolve<ITransmissionPart>(Configuration.FluentJdfLibrary.Settings.TransmissionPartSettings.TransmissionPartsByMimeType[mimeType]);
            }
            else {
                transmissionPart = Infrastructure.Core.Configuration.Settings.ServiceLocator.Resolve<ITransmissionPart>(Configuration.FluentJdfLibrary.Settings.TransmissionPartSettings.DefaultTransmissionPart.FullName);
            }

            transmissionPart.Initialize(name, data, mimeType, id);
            return transmissionPart;
        }
    }
}
