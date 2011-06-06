using System.Xml.Linq;
using Onpoint.Commons.Core.CodeContracts;

namespace Jdp.Jdf.LinqToJdf {
    /// <summary>
    /// Set attributes on an intent node.
    /// </summary>
    public class JdfAttributeSetter {
        readonly NodeFactoryBase nodeFactoryBase;

        internal JdfAttributeSetter(NodeFactoryBase nodeFactoryBase) {
            ParameterCheck.ParameterRequired(nodeFactoryBase, "nodeFactoryBase");

            this.nodeFactoryBase = nodeFactoryBase;
        }

        /// <summary>
        /// Gets the intent node.
        /// </summary>
        /// <returns></returns>
        public XElement Node {
            get { return nodeFactoryBase.Node; }
        }

        /// <summary>
        /// Sets the job id.
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public JdfAttributeSetter JobId(string jobId) {
            ParameterCheck.ParameterRequired(jobId, "jobId");

            nodeFactoryBase.Node.SetJobId(jobId);
            return this;
        }

        /// <summary>
        /// Sets the job part id.
        /// </summary>
        /// <param name="jobPartId"></param>
        /// <returns></returns>
        public JdfAttributeSetter JobPartId(string jobPartId) {
            ParameterCheck.ParameterRequired(jobPartId, "jobPartId");

            nodeFactoryBase.Node.SetJobPartId(jobPartId);
            return this;
        }
    }
}