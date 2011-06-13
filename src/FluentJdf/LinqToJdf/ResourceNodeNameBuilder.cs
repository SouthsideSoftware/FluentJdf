using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf {
    /// <summary>
    /// Factory to create resources.
    /// </summary>
    public class ResourceNodeNameBuilder
    {
        internal JdfNodeBuilder ParentJdf;
        readonly ResourceUsage usage;

        internal ResourceNodeNameBuilder(JdfNodeBuilder jdfNodeBuilder, ResourceUsage usage) {
            ParameterCheck.ParameterRequired(jdfNodeBuilder, "jdfNodeBuilder");

            ParentJdf = jdfNodeBuilder;
            this.usage = usage;
        }

        /// <summary>
        /// Create a folding intent and return a builder to operate on it.
        /// </summary>
        public ResourceNodeBuilder BindingIntent(string id = null) {
            return new ResourceNodeBuilder(ParentJdf, Resource.BindingIntent, usage, id); 
        }

        /// <summary>
        /// Create a component and return a builder to operate on it.
        /// </summary>
        public ResourceNodeBuilder Component()
        {
            return new ResourceNodeBuilder(ParentJdf, Resource.Component, usage);
        }

        /// <summary>
        /// Create a folding intent and return a builder to operate on it.
        /// </summary>
        public ResourceNodeBuilder FoldingIntent() {
            return new ResourceNodeBuilder(ParentJdf, Resource.FoldingIntent, usage);
        }

        /// <summary>
        /// Create a media intent and return a builder to operate on it.
        /// </summary>
        public ResourceNodeBuilder MediaIntent()
        {
            return new ResourceNodeBuilder(ParentJdf, Resource.MediaIntent, usage);
        }

        /// <summary>
        /// Create a resource with the given name and return a factory to operate in it.
        /// </summary>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        public ResourceNodeBuilder ResourceWithName(XName resourceName) {
            ParameterCheck.ParameterRequired(resourceName, "resourceName");

            return new ResourceNodeBuilder(ParentJdf, resourceName, usage);
        }
    }
}