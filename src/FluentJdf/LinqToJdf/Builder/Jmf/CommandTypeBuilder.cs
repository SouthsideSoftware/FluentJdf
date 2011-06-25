using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf
{
    /// <summary>
    /// Create commands of various types
    /// </summary>
    public class CommandTypeBuilder {
        readonly JmfNodeBuilder parentJmf;

        internal CommandTypeBuilder(JmfNodeBuilder jmfNodeBuilder) {
            ParameterCheck.ParameterRequired(jmfNodeBuilder, "jmfNodeBuilder");

            parentJmf = jmfNodeBuilder;
        }

        /// <summary>
        /// Create a submit queue entry command.
        /// </summary>
        /// <returns></returns>
        public SubmitQueueEntryCommandBuilder SubmitQueueEntry() {
            return new SubmitQueueEntryCommandBuilder(parentJmf);
        }

        /// <summary>
        /// Create a queue status query
        /// </summary>
        /// <returns></returns>
        public QueueStatusQueryBuilder QueueStatus()
        {
            return new QueueStatusQueryBuilder(parentJmf);
        }
    }
}
