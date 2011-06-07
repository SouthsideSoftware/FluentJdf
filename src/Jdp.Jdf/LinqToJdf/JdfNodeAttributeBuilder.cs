using System.Xml.Linq;
using Onpoint.Commons.Core.CodeContracts;

namespace Jdp.Jdf.LinqToJdf {
    /// <summary>
    /// Set attributes on a JDF node.
    /// </summary>
    public class JdfNodeAttributeBuilder : NodeAttributeBuilderBase {
        internal JdfNodeAttributeBuilder(NodeBuilderBase nodeBuilderBase) : base(nodeBuilderBase) {
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
    }
}