namespace Infrastructure.Core.Result
{
    /// <summary>
    /// Identifies the severity of a result item.
    /// </summary>
    public enum ResultItemType
    {
        /// <summary>
        /// Process was aborted because a required condition was not met.
        /// </summary>
        Error,
        /// <summary>
        /// Process continbued but result may be less than complete.
        /// </summary>
        Warning
    }
}
