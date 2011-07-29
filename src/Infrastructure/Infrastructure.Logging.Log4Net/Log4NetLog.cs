using System;
using System.Diagnostics.Contracts;
using Infrastructure.Core.CodeContracts;
using Infrastructure.Core.Logging;

namespace Infrastructure.Logging.Log4Net
{
    /// <summary>
    /// Implementation of commons ILog for log4net.
    /// </summary>
    public class Log4NetLog : ILog
    {
        readonly log4net.ILog log4NetLog;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="log4netLog"></param>
        public Log4NetLog(log4net.ILog log4netLog) {
            ParameterCheck.ParameterRequired(log4netLog, "log4netLog");

            log4NetLog = log4netLog;
        }

        /// <summary>
        /// Gets <see langword="true"/> if error logging is enabled.
        /// </summary>
        public bool IsErrorEnabled {
            get { return log4NetLog.IsErrorEnabled; }
        }

        /// <summary>
        /// Gets <see langword="true"/> if logging is enabled at the fatal level.
        /// </summary>
        public bool IsFatalEnabled {
            get { return log4NetLog.IsFatalEnabled; }
        }

        /// <summary>
        /// Gets <see langword="true"/> if debug level logging is enabled.
        /// </summary>
        public bool IsDebugEnabled {
            get { return log4NetLog.IsDebugEnabled; }
        }

        /// <summary>
        /// Gets <see langword="true"/> if info level logging is enabled.
        /// </summary>
        public bool IsInfoEnabled {
            get { return log4NetLog.IsInfoEnabled; }
        }

        /// <summary>
        /// Gets <see langword="true"/> if warning level logging is enabled.
        /// </summary>
        public bool IsWarnEnabled {
            get { return log4NetLog.IsWarnEnabled; }
        }

        /// <summary>
        /// Log a message at the error level.
        /// </summary>
        /// <param name="message"></param>
        public void Error(object message) {
            log4NetLog.Error(message);
        }

        /// <summary>
        /// Log a message and exception at the error level.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Error(object message, Exception exception) {
            log4NetLog.Error(message, exception);
        }

        /// <summary>
        /// Log a message using a format string at the error level.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void ErrorFormat(string format, params object[] args) {
            log4NetLog.ErrorFormat(format, args);
        }

        /// <summary>
        /// Log a message at the fatal level.
        /// </summary>
        /// <param name="message"></param>
        public void Fatal(object message) {
            log4NetLog.Fatal(message);
        }

        /// <summary>
        /// Log a message and an exception at the fatal level.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Fatal(object message, Exception exception) {
            log4NetLog.Fatal(message, exception);
        }

        /// <summary>
        /// Log a message using a format string at the fatal level.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void FatalFormat(string format, params object[] args) {
            log4NetLog.FatalFormat(format, args);
        }

        /// <summary>
        /// Log a message at the debug level.
        /// </summary>
        /// <param name="message"></param>
        public void Debug(object message) {
            log4NetLog.Debug(message);
        }

        /// <summary>
        /// Log a message and exception at the debug level.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Debug(object message, Exception exception) {
            log4NetLog.Debug(message, exception);
        }

        /// <summary>
        /// Log a message using a format string at the debug level.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void DebugFormat(string format, params object[] args) {
            log4NetLog.DebugFormat(format, args);
        }

        /// <summary>
        /// Log a message at the info level.
        /// </summary>
        /// <param name="message"></param>
        public void Info(object message) {
            log4NetLog.Info(message);
        }

        /// <summary>
        /// Log a message and exception at the info level.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Info(object message, Exception exception) {
            log4NetLog.Info(message, exception);
        }

        /// <summary>
        /// Log a message using a format string at the info level.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void InfoFormat(string format, params object[] args) {
            log4NetLog.InfoFormat(format, args);
        }

        /// <summary>
        /// Log a message at the warning level.
        /// </summary>
        /// <param name="message"></param>
        public void Warn(object message) {
            log4NetLog.Warn(message);
        }

        /// <summary>
        /// Log a message and exception at the warning level.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Warn(object message, Exception exception) {
            log4NetLog.Warn(message, exception);
        }

        /// <summary>
        /// Log a message using a format string at the warning level.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void WarnFormat(string format, params object[] args) {
            log4NetLog.WarnFormat(format, args);
        }
    }
}
