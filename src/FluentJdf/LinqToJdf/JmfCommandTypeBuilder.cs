using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf
{
    /// <summary>
    /// Create commands of various types
    /// </summary>
    public class JmfCommandTypeBuilder {
        readonly JmfNodeBuilder parentJmf;

        internal JmfCommandTypeBuilder(JmfNodeBuilder jmfNodeBuilder) {
            ParameterCheck.ParameterRequired(jmfNodeBuilder, "jmfNodeBuilder");

            parentJmf = jmfNodeBuilder;
        }

        /// <summary>
        /// Create a submit queue entry command.
        /// </summary>
        /// <returns></returns>
        public JmfSubmitQueueEntryCommandBuilder SubmitQueueEntry() {
            return new JmfSubmitQueueEntryCommandBuilder(parentJmf);
        }
    }
}
