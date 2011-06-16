using System;
using System.Collections.Generic;
using FluentJdf.Encoding;
using FluentJdf.Resources;
using Infrastructure.Core.CodeContracts;
using Infrastructure.Core.Container;
using Infrastructure.Core.Helpers;

namespace FluentJdf.Configuration {
    /// <summary>
    /// Settings for transmission parts.
    /// </summary>
    public class TransmissionPartSettings {
        Type defaultTransmissionPart;

        /// <summary>
        /// Constructor.
        /// </summary>
        public TransmissionPartSettings() {
            TransmissionPartsByMimeType = new Dictionary<string, string>();
        }

        /// <summary>
        /// Gets dictionary of transmission part settings by mime type.
        /// </summary>
        public Dictionary<string, string> TransmissionPartsByMimeType { get; private set; }

        /// <summary>
        /// Gets the default transmission part
        /// </summary>
        public Type DefaultTransmissionPart
        {
            get { return defaultTransmissionPart; }
            internal set
            {
                ParameterCheck.ParameterRequired(value, "value");
                ThrowExceptionIfTypeIsNotITransmissionPart(value);
                RegisterTransmissionPartIfRequired(value);
                defaultTransmissionPart = value;
            }
        }

        /// <summary>
        /// Register a transmission part for a mime type.
        /// </summary>
        /// <param name="mimeType"></param>
        /// <param name="value"></param>
        public void RegisterTransmissionPartForMimeType(string mimeType, Type value) {
            ParameterCheck.StringRequiredAndNotWhitespace(mimeType, "mimeType");
            ParameterCheck.ParameterRequired(value, "value");
            ThrowExceptionIfTypeIsNotITransmissionPart(value);

            RegisterTransmissionPartIfRequired(value);
            TransmissionPartsByMimeType[mimeType] = value.FullName;
        }

        void ThrowExceptionIfTypeIsNotITransmissionPart(Type value) {
            if (!typeof (ITransmissionPart).IsAssignableFrom(value)) {
                throw new ArgumentException(Messages.TransmissionPartSettings_ThrowExceptionIfTypeIsNotITransmissionPart);
            }
        }

        /// <summary>
        /// Reset to defaults.
        /// </summary>
        /// <returns></returns>
        public TransmissionPartSettings ResetToDefault() {
            TransmissionPartsByMimeType.Clear();
            DefaultTransmissionPart = typeof (TransmissionPart);
            RegisterTransmissionPartForMimeType(MimeTypeHelper.XmlMimeType, typeof(XmlTransmissionPart));
            RegisterTransmissionPartForMimeType(MimeTypeHelper.JdfMimeType, typeof(XmlTransmissionPart));
            RegisterTransmissionPartForMimeType(MimeTypeHelper.JmfMimeType, typeof(XmlTransmissionPart));
            return this;
        }

        void RegisterTransmissionPartIfRequired(Type transmissionPart) {
            if (!Infrastructure.Core.Configuration.Settings.ServiceLocator.CanResolve(typeof (ITransmissionPart), transmissionPart.FullName)) {
                Infrastructure.Core.Configuration.Settings.ServiceLocator.Register(typeof (ITransmissionPart), transmissionPart, ComponentLifestyle.TransientNoTracking);
            }
        }
    }
}