namespace FluentJdf.LinqToJdf.Builder.Jmf {
    /// <summary>
    /// Create commands of various types
    /// </summary>
    public class QueryTypeBuilder : MessageTypeBuilder {
        internal QueryTypeBuilder(JmfNodeBuilder jmfBuilder) : base(jmfBuilder) {}

        /// <summary>
        /// Create a queue status query
        /// </summary>
        /// <returns></returns>
        public QueueStatusQueryBuilder QueueStatus()
        {
            return new QueueStatusQueryBuilder(ParentJmf);
        }
    }
}