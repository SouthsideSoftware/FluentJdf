using System.Xml.Linq;

namespace FluentJdf.LinqToJdf {
    /// <summary>
    /// Name helper for JDF element type
    /// </summary>
    public static class JdfElementType
    {
#pragma warning disable 1591

        public static string Combined = "Combined";
        public static string Intent = "Product";
        public static string ProcessGroup = "ProcessGroup";

#pragma warning restore 1591

        /// <summary>
        /// Gets the fully qualified name of a JDF type attribute in the JDF namespace.
        /// </summary>
        /// <param name="jdfElementType"></param>
        /// <returns></returns>
        public static XName XsiJdfElementType(string jdfElementType) {
            return Globals.JdfNamespace.GetName(jdfElementType);
        }

    }
}