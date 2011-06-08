using System.Xml.Linq;
using Onpoint.Commons.Core.CodeContracts;

namespace Jdp.Jdf.LinqToJdf {
    /// <summary>
    /// Set attributes on a JDF node.
    /// </summary>
    public class JdfNodeAttributeBuilder : NodeAttributeBuilderBase {
        internal JdfNodeAttributeBuilder(JdfNodeBuilder nodeBuilder) : base(nodeBuilder) {
        }

        /// <summary>
        /// Gets the JDF node builder for this attribute builder.
        /// </summary>
        /// <returns></returns>
        public JdfNodeBuilder Node() {
            return (NodeBuilderBase as JdfNodeBuilder);
        }
        /// <summary>
        /// Sets the job id.
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public JdfNodeAttributeBuilder JobId(string jobId)
        {
            ParameterCheck.ParameterRequired(jobId, "jobId");

            Element.SetJobId(jobId);
            return this;
        }

        /// <summary>
        /// Sets the job part id.
        /// </summary>
        /// <returns></returns>
        public JdfNodeAttributeBuilder JobPartId(string jobPartId) {
            ParameterCheck.ParameterRequired(jobPartId, "jobPartId");

            Element.SetJobPartId(jobPartId);
            return this;
        }

        /// <summary>
        /// Create an input
        /// </summary>>
        public ResourceNodeNameBuilder WithInput() { return new ResourceNodeNameBuilder((NodeBuilderBase as JdfNodeBuilder), ResourceUsage.Input); }

        /// <summary>
        /// Creates an output.
        /// </summary>
        public ResourceNodeNameBuilder WithOutput() { return new ResourceNodeNameBuilder((NodeBuilderBase as JdfNodeBuilder), ResourceUsage.Output); }
    }
}