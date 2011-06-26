using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace FluentJdf.Messaging
{
    /// <summary>
    /// Notification element.
    /// </summary>
    public class Notification
    {
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
