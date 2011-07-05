using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using FluentJdf.LinqToJdf;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.Messaging
{
    /// <summary>
    /// Notification element.
    /// </summary>
    public class Notification
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="notification"></param>
        public Notification(XElement notification) {
            ParameterCheck.ParameterRequired(notification, "notification");
            Comments = new List<string>();
            Element = notification;
            NotificationClass = NotificationClass.Unknown;

            var c = notification.GetAttributeValueOrNull("Class");
            NotificationClass outNotificationClass;
            if (Enum.TryParse(c, true, out outNotificationClass))
            {
                NotificationClass = outNotificationClass;
            }

            foreach (var comment in notification.Elements(LinqToJdf.Element.Comment)) {
                if (!string.IsNullOrWhiteSpace(comment.Value)) {
                    Comments.Add(comment.Value);
                }
            }
        }
        /// <summary>
        /// Gets the raw xml element.
        /// </summary>
        public XElement Element { get; private set; }
        /// <summary>
        /// Gets the comments
        /// </summary>
        public IList<string> Comments { get; private set; }
          
        /// <summary>
        /// Gets the notification class.
        /// </summary>
        public NotificationClass NotificationClass { get; private set; }
    }
}
