using System;
using System.Collections.Generic;
using FluentJdf.Encoding;
using FluentJdf.Resources;
using Infrastructure.Core.CodeContracts;
using Infrastructure.Core.Container;
using Infrastructure.Core.Helpers;
using Infrastructure.Core;

namespace FluentJdf.Configuration {
    /// <summary>
    /// Settings for transmission parts.
    /// </summary>
    public class TransmissionPartSettings {
        Type defaultTransmissionPart;
        IDictionary<string, Type> transmissionPartsByMimeType;

        /// <summary>
        /// Constructor.
        /// </summary>
        public TransmissionPartSettings() {
            transmissionPartsByMimeType = new Dictionary<string, Type>();
            TransmissionPartsByMimeType = new ReadOnlyDictionary<string, Type>(transmissionPartsByMimeType);
        }

        /// <summary>
        /// Gets dictionary of transmission part settings by mime type.
        /// </summary>
        public ReadOnlyDictionary<string, Type> TransmissionPartsByMimeType {
            get;
            private set;
        }

        /// <summary>
        /// Gets the default transmission part
        /// </summary>
        public Type DefaultTransmissionPart {
            get {
                return defaultTransmissionPart;
            }
        }

        internal void SetDefaultTransmissionPart<T>() where T : ITransmissionPart {
            RegisterTransmissionPartIfRequired<T>();
            defaultTransmissionPart = typeof(T);
        }

        /// <summary>
        /// Register a transmission part for a mime type.
        /// </summary>
        /// <param name="mimeType"></param>
        public void RegisterTransmissionPartForMimeType<T>(string mimeType) where T : ITransmissionPart {
            ParameterCheck.StringRequiredAndNotWhitespace(mimeType, "mimeType");

            RegisterTransmissionPartIfRequired<T>();
            transmissionPartsByMimeType[mimeType] = typeof(T);
        }

        /// <summary>
        /// Reset to defaults.
        /// </summary>
        /// <returns></returns>
        public TransmissionPartSettings ResetToDefaults() {
            transmissionPartsByMimeType.Clear();
            SetDefaultTransmissionPart<TransmissionPart>();
            RegisterTransmissionPartForMimeType<XmlTransmissionPart>(MimeTypeHelper.XmlMimeType);
            RegisterTransmissionPartForMimeType<TicketTransmissionPart>(MimeTypeHelper.JdfMimeType);
            RegisterTransmissionPartForMimeType<MessageTransmissionPart>(MimeTypeHelper.JmfMimeType);
            return this;
        }

        void RegisterTransmissionPartIfRequired<T>() where T : ITransmissionPart {
            var transmissionPartType = typeof(T);
            if (!Infrastructure.Core.Configuration.Settings.ServiceLocator.CanResolve(typeof(ITransmissionPart), transmissionPartType.FullName)) {
                Infrastructure.Core.Configuration.Settings.ServiceLocator.Register(typeof(ITransmissionPart), transmissionPartType, ComponentLifestyle.TransientNoTracking);
            }
        }
    }
}