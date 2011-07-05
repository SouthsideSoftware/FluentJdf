using System;
using System.Collections.Generic;
using System.Xml.Linq;
using FluentJdf.LinqToJdf;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.Messaging {
    /// <summary>
    /// Details of a result.
    /// </summary>
    public class JmfResultDetail : IJmfResultDetail {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="responseElement"></param>
        public JmfResultDetail(XElement responseElement) {
            ParameterCheck.ParameterRequired(responseElement, "responseElement");

            ReturnCode = ReturnCode.Unknown;
            RawReturnCode = (int)ReturnCode;
            Notifications = new List<Notification>();
 
            int? returnCode = responseElement.GetAttributeValueAsIntOrNull("ReturnCode");
            if (returnCode != null) {
                RawReturnCode = returnCode.Value;
                ReturnCode outReturnCode;
                if (Enum.TryParse(responseElement.GetAttributeValueOrNull("ReturnCode"), true, out outReturnCode)) {
                    ReturnCode = outReturnCode;
                }
            }

            foreach (var notification in responseElement.Elements(Element.Notification)) {
                Notifications.Add(new Notification(notification));
            }
        }

        /// <summary>
        /// Gets the raw return code.
        /// </summary>
        public int RawReturnCode { get; private set; }

        /// <summary>
        /// Gets the return code.
        /// </summary>
        public ReturnCode ReturnCode { get; private set; }

        /// <summary>
        /// Gets the notifications if any.
        /// </summary>
        public IList<Notification> Notifications { get; private set; }

        /// <summary>
        /// Gets <see langword="true"/> on success.
        /// </summary>
        public bool IsSuccess
        {
            get { return ReturnCode == ReturnCode.Success; }
        }
    }
}