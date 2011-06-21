using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf {
    /// <summary>
    /// Used to build submit queue entry
    /// </summary>
    public class JmfSubmitQueueEntryCommandBuilder : JmfCommandBuilder {
        internal const string IdPrefix = "SQE_";

        internal  JmfSubmitQueueEntryCommandBuilder(JmfNodeBuilder parent) : base(parent, Command.SubmitQueueEntry, IdPrefix) {
            ParameterCheck.ParameterRequired(parent, "parent");
        }
    }
}