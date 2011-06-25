using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf
{
    /// <summary>
    /// Create commands of various types
    /// </summary>
    public class CommandTypeBuilder : MessageTypeBuilder {
        internal CommandTypeBuilder(JmfNodeBuilder jmfBuilder) : base(jmfBuilder) {}

        /// <summary>
        /// Create a submit queue entry command.
        /// </summary>
        /// <returns></returns>
        public SubmitQueueEntryCommandBuilder SubmitQueueEntry() {
            return new SubmitQueueEntryCommandBuilder(ParentJmf);
        }
    }
}
