namespace Infrastructure.Core.Container
{
    /// <summary>
    /// Generic component lifestyle
    /// </summary>
    public enum ComponentLifestyle
    {
        /// <summary>
        /// Singleton
        /// </summary>
        Singleton,
        /// <summary>
        /// New component created for each resolution.
        /// </summary>
        Transient,
        /// <summary>
        /// One component for each thread.
        /// </summary>
        Thread,
        /// <summary>
        /// One instance per web request.
        /// </summary>
        PerWebRequest
    }
}
