using System.Diagnostics.Contracts;
using System.Xml.Linq;

namespace FluentJdf.LinqToJdf
{
    /// <summary>
    /// Extensions to Xname
    /// </summary>
    public static class XNameExtension
    {
        /// <summary>
        /// Get the link name for a resource name.
        /// </summary>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        public static XName LinkName(this XName resourceName) {
            Contract.Requires(resourceName != null);

            return XName.Get(string.Format("{0}Link", resourceName.LocalName), resourceName.NamespaceName);
        }

        /// <summary>
        /// Get the ref element name for a name.
        /// </summary>
        /// <returns></returns>
        public static XName RefName(this XName elementName)
        {
            Contract.Requires(elementName != null);

            return XName.Get(string.Format("{0}Ref", elementName.LocalName), elementName.NamespaceName);
        }
    }
}
