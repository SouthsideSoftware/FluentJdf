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
        internal JmfNodeBuilder ParentJmf;

        internal JmfCommandTypeBuilder(JmfNodeBuilder jmfNodeBuilder) {
            ParameterCheck.ParameterRequired(jmfNodeBuilder, "jmfNodeBuilder");

            ParentJmf = jmfNodeBuilder;
        }

        /// <summary>
        /// Create a submit queue entry command.
        /// </summary>
        /// <returns></returns>
        public JmfCommandBuilder SubmitQueueEntry() {
            return new JmfCommandBuilder(ParentJmf, Command.SubmitQueueEntry);
        }
    }
}
