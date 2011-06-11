using System.Xml.Linq;

namespace FluentJdf.LinqToJdf {
    /// <summary>
    /// Name helpers for JDF
    /// </summary>
    public static class Audit
    {
#pragma warning disable 1591

        public static XName Created = Globals.JdfName("Created");
        public static XName Deleted = Globals.JdfName("Deleted");
        public static XName Merged = Globals.JdfName("Merged");
        public static XName Modified = Globals.JdfName("Modified");
        public static XName Notification = Globals.JdfName("Notification");
        public static XName PhaseTime = Globals.JdfName("PhaseTime");
        public static XName ProcessRun = Globals.JdfName("ProcessRun");
        public static XName ResourceAudit = Globals.JdfName("ResourceAudit");
        public static XName Spawned = Globals.JdfName("Spawned");

#pragma warning restore 1591

    }
}