using System.Xml.Linq;
using Onpoint.Commons.Core.CodeContracts;

namespace Jdp.Jdf.LinqToJdf {
    /// <summary>
    /// Set attributes on an intent node.
    /// </summary>
    public class JdfAttributeSetter {
        readonly NodeBuilderBase _nodeBuilderBase;

        internal JdfAttributeSetter(NodeBuilderBase _nodeBuilderBase) {
            ParameterCheck.ParameterRequired(_nodeBuilderBase, "NodeBuilderBase");

            this._nodeBuilderBase = _nodeBuilderBase;
        }

        /// <summary>
        /// Gets the intent node.
        /// </summary>
        /// <returns></returns>
        public XElement Node {
            get { return _nodeBuilderBase.Node; }
        }

        /// <summary>
        /// Sets the job id.
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public JdfAttributeSetter JobId(string jobId) {
            ParameterCheck.ParameterRequired(jobId, "jobId");

            _nodeBuilderBase.Node.SetJobId(jobId);
            return this;
        }

        /// <summary>
        /// Sets the job part id.
        /// </summary>
        /// <param name="jobPartId"></param>
        /// <returns></returns>
        public JdfAttributeSetter JobPartId(string jobPartId) {
            ParameterCheck.ParameterRequired(jobPartId, "jobPartId");

            _nodeBuilderBase.Node.SetJobPartId(jobPartId);
            return this;
        }
    }
}