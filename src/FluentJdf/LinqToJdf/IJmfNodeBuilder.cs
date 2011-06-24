namespace FluentJdf.LinqToJdf {
    /// <summary>
    /// Interface for building JMF nodes.
    /// </summary>
    public interface IJmfNodeBuilder : IJmfNodeBuilderBase {
        /// <summary>
        /// Add a command.
        /// </summary>
        /// <returns></returns>
        JmfCommandTypeBuilder AddCommand();
    }
}