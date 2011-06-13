using System;

namespace Infrastructure.Core.Logging
{
    /// <summary>
    /// ILog implementation that does nothing.
    /// </summary>
    public class NullLog : ILog
    {
        /// <summary>
        /// Gets <see langword="true"/> if error logging is enabled.
        /// </summary>
        public bool IsErrorEnabled {
            get { return false; }
        }

        /// <summary>
        /// Gets <see langword="true"/> if logging is enabled at the fatal level.
        /// </summary>
        public bool IsFatalEnabled {
            get { return false; }
        }

        /// <summary>
        /// Gets <see langword="true"/> if debug level logging is enabled.
        /// </summary>
        public bool IsDebugEnabled {
            get { return false; }
        }

        /// <summary>
        /// Gets <see langword="true"/> if info level logging is enabled.
        /// </summary>
        public bool IsInfoEnabled {
            get { return false; }
        }

        /// <summary>
        /// Gets <see langword="true"/> if warning level logging is enabled.
        /// </summary>
        public bool IsWarnEnabled {
            get { return false; }
        }

        /// <summary>
        /// Log a message at the error level.
        /// </summary>
        /// <param name="message"></param>
        public void Error(object message) {
        }

        /// <summary>
        /// Log a message and exception at the error level.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Error(object message, Exception exception) {
        }

        /// <summary>
        /// Log a message using a format string at the error level.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void ErrorFormat(string format, params object[] args) {
        }

        /// <summary>
        /// Log a message at the fatal level.
        /// </summary>
        /// <param name="message"></param>
        public void Fatal(object message) {
        }

        /// <summary>
        /// Log a message and an exception at the fatal level.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Fatal(object message, Exception exception) {
        }

        /// <summary>
        /// Log a message using a format string at the fatal level.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void FatalFormat(string format, params object[] args) {
        }

        /// <summary>
        /// Log a message at the debug level.
        /// </summary>
        /// <param name="message"></param>
        public void Debug(object message) {
            
        }

        /// <summary>
        /// Log a message and exception at the debug level.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Debug(object message, Exception exception) {
            
        }

        /// <summary>
        /// Log a message using a format string at the debug level.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void DebugFormat(string format, params object[] args) {
            
        }

        /// <summary>
        /// Log a message at the info level.
        /// </summary>
        /// <param name="message"></param>
        public void Info(object message) {
            
        }

        /// <summary>
        /// Log a message and exception at the info level.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Info(object message, Exception exception) {
            
        }

        /// <summary>
        /// Log a message using a format string at the info level.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void InfoFormat(string format, params object[] args) {
            
        }

        /// <summary>
        /// Log a message at the warning level.
        /// </summary>
        /// <param name="message"></param>
        public void Warn(object message) {
            
        }

        /// <summary>
        /// Log a message and exception at the warning level.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Warn(object message, Exception exception) {
            
        }

        /// <summary>
        /// Log a message using a format string at the warning level.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void WarnFormat(string format, params object[] args) {
            
        }
    }
}
