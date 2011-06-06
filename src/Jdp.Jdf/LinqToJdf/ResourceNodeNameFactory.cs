using System.Xml.Linq;
using Onpoint.Commons.Core.CodeContracts;

namespace Jdp.Jdf.LinqToJdf {
    /// <summary>
    /// Factory to create resources.
    /// </summary>
    public class ResourceNodeNameFactory {
        XContainer initiator;
        readonly ResourceUsage usage;

        internal ResourceNodeNameFactory(XContainer initiator, ResourceUsage usage) {
            ParameterCheck.ParameterRequired(initiator, "initiator");

            this.initiator = initiator;
            this.usage = usage;
        }

        /// <summary>
        /// Create a binding intent and return a factory to operate on it.
        /// </summary>
        public ResourceNodeFactory BindingIntent() {
            return new ResourceNodeFactory(initiator, Resource.BindingIntent, usage); 
        }

        /// <summary>
        /// Create a resource with the given name and return a factory to operate in it.
        /// </summary>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        public ResourceNodeFactory ResourceWithName(XName resourceName) {
            ParameterCheck.ParameterRequired(resourceName, "resourceName");

            return new ResourceNodeFactory(initiator, resourceName, usage);
        }
    }
}