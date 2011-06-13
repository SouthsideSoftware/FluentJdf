using System;

namespace Infrastructure.Core.Logging
{
    /// <summary>
    /// Common logging interface.
    /// </summary>
    public interface ILog
    {
        /// <summary>
        /// Gets <see langword="true"/> if error logging is enabled.
        /// </summary>
        bool IsErrorEnabled { get; }

        /// <summary>
        /// Gets <see langword="true"/> if logging is enabled at the fatal level.
        /// </summary>
        bool IsFatalEnabled { get; }

        /// <summary>
        /// Gets <see langword="true"/> if debug level logging is enabled.
        /// </summary>
        bool IsDebugEnabled { get; }

        /// <summary>
        /// Gets <see langword="true"/> if info level logging is enabled.
        /// </summary>
        bool IsInfoEnabled { get; }

        /// <summary>
        /// Gets <see langword="true"/> if warning level logging is enabled.
        /// </summary>
        bool IsWarnEnabled { get; }

        /// <summary>
        /// Log a message at the error level.
        /// </summary>
        /// <param name="message"></param>
        void Error(object message);

        /// <summary>
        /// Log a message and exception at the error level.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        void Error(object message, Exception exception);

        /// <summary>
        /// Log a message using a format string at the error level.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        void ErrorFormat(string format, params object[] args);

        /// <summary>
        /// Log a message at the fatal level.
        /// </summary>
        /// <param name="message"></param>
        void Fatal(object message);

        /// <summary>
        /// Log a message and an exception at the fatal level.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        void Fatal(object message, Exception exception);

        /// <summary>
        /// Log a message using a format string at the fatal level.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        void FatalFormat(string format, params object[] args);

        /// <summary>
        /// Log a message at the debug level.
        /// </summary>
        /// <param name="message"></param>
        void Debug(object message);

        /// <summary>
        /// Log a message and exception at the debug level.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        void Debug(object message, Exception exception);

        /// <summary>
        /// Log a message using a format string at the debug level.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        void DebugFormat(string format, params object[] args);

        /// <summary>
        /// Log a message at the info level.
        /// </summary>
        /// <param name="message"></param>
        void Info(object message);

        /// <summary>
        /// Log a message and exception at the info level.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        void Info(object message, Exception exception);

        /// <summary>
        /// Log a message using a format string at the info level.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        void InfoFormat(string format, params object[] args);

        /// <summary>
        /// Log a message at the warning level.
        /// </summary>
        /// <param name="message"></param>
        void Warn(object message);

        /// <summary>
        /// Log a message and exception at the warning level.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        void Warn(object message, Exception exception);

        /// <summary>
        /// Log a message using a format string at the warning level.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        void WarnFormat(string format, params object[] args);
    }
}
