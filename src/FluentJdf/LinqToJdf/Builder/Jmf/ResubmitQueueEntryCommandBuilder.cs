
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build ResubmitQueueEntry
	/// </summary>
	public partial class ResubmitQueueEntryCommandBuilder : CommandBuilder {
		internal const string IdPrefix = "RQE_";

		internal ResubmitQueueEntryCommandBuilder(JmfNodeBuilder parent)
			: base(parent, Command.ResubmitQueueEntry, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public ResubmitQueueEntryCommandAttributeBuilder With() {
			return new ResubmitQueueEntryCommandAttributeBuilder(this);
		}
	}
}
