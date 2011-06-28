namespace FluentJdf.LinqToJdf {
    /// <summary>
    /// Query message names
    /// </summary>
    public static class Query
    {
#pragma warning disable 1591

        public static string Events = "Events";
        public static string FlushQueue = "FlushQueue";
        public static string ForceGang = "ForceGang";
        public static string KnownControllers = "KnownControllers";
        public static string KnownDevices = "KnownDevices";
        public static string KnownJDFServices = "KnownJDFServices";
        public static string KnownMessages = "KnownMessages";
        public static string KnownSubscriptions = "KnownSubscriptions";
        public static string NewJDF = "NewJDF";
        public static string NodeInfo = "NodeInfo";
        public static string Occupation = "Occupation";
        public static string QueueEntryStatus = "QueueEntryStatus";
        public static string QueueStatus = "QueueStatus";
        public static string RepeatMessages = "RepeatMessages";
        public static string RequestForAuthentication = "RequestForAuthentication";
        public static string Resource = "Resource";
        public static string Status = "Status";
        public static string SubmissionMethods = "SubmissionMethods";
        public static string Track = "Track";

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