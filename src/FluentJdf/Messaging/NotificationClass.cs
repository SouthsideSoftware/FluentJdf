using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentJdf.Messaging
{
    /// <summary>
    /// Values for Notification/@Class as described
    /// in table 3-38 of the JDF standard.
    /// </summary>
    public enum NotificationClass
    {
        /// <summary>
        /// An eevent.
        /// </summary>
        Event,
        /// <summary>
        /// Informational message.
        /// </summary>
        INformation,
        /// <summary>
        /// A warning.  Usually a minor
        /// error that was automatically resolved.
        /// </summary>
        Warning,
        /// <summary>
        /// An error likely requiring user intervention.
        /// </summary>
        Error,
        /// <summary>
        /// An absolutely fatal error.
        /// </summary>
        Fatal
    }
}
