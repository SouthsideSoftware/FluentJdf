namespace FluentJdf.Transmission.Logging {
    /// <summary>
    /// Logs transmissions.
    /// </summary>
    public interface ITransmissionLogger {
        /// <summary>
        /// Log the given data.
        /// </summary>
        /// <param name="transmissionData"></param>
        /// <remarks>Logs the stream inline if it does not exceed
        /// the configured inline stream limit.  If the limit is exceeded,
        /// it is logged in an external file and referenced inline.</remarks>
        void Log(TransmissionData transmissionData);
    }
}