namespace Infrastructure.Core.Result
{
    /// <summary>
    /// Result codes
    /// </summary>
    public enum ResultCode
    {
        /// <summary>
        /// Indicates a general error occured.
        /// </summary>
        GeneralError = -1,
        /// <summary>
        /// Indicates an unexpected exception was thrown by some process.  The message
        /// associated with this error should contain stack dump information.
        /// </summary>
        UnexpectedException = -2,
        /// <summary>
        /// The intent parser requires a root JDF intent
        /// </summary>
        RootJdfRequired = -102,
        /// <summary>
        /// The JMF response had an error notification.
        /// </summary>
        JmfResponseError = -900,
        /// <summary>
        /// The JMF response has a fatal notification.
        /// </summary>
        JmfResponseFatal = -901,
        /// <summary>
        /// The JMF response indicates an error code but no error or fatal notifications
        /// were provided.
        /// </summary>
        JmfResponseErrorWithNoNotification,
        /// <summary>
        /// A warning of an unspecified nature.  See message for 
        /// more information.
        /// </summary>
        GeneralWarning = 1,
        /// <summary>
        /// An attribute device capabilities says is required was not replaced with a value from intent mapping process
        /// </summary>
        RequiredAttributeNotFilled = 100,
        /// <summary>
        /// The JMF response had a warning notification.
        /// </summary>
        JmfResponseWarning = 900,
        /// <summary>
        /// Receiced a JMF response without a ReturnCode
        /// so we cannot tell if it is a success or failure.
        /// </summary>
        JmfResponseWithoutReturnCode = 901,
        /// <summary>
        /// There is no handler configured.
        /// </summary>
        NoHandlerConfigured = 1000,
        /// <summary>
        /// Not supported.
        /// </summary>
        UnsupportedProcess = 1001,
        /// <summary>
        /// Feature not supported.
        /// </summary>
        UnsupportedFeature = 1100,
 
    }
}