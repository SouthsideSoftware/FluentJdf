namespace FluentJdf.LinqToJdf {
    /// <summary>
    /// Query message names
    /// </summary>
    public static class Query
    {
#pragma warning disable 1591

        public static string QueueStatus = "QueueStatus";

#pragma warning restore 1591

        /// <summary>
        /// Gets the xsi type for the query.
        /// </summary>
        /// <returns></returns>
        public static string XsiType(string query) {
            return string.Format("Query{0}", query);
        }
    }
}