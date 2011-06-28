
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build HoldQueueEntry
	/// </summary>
	public class HoldQueueEntryCommandBuilder : CommandBuilder {
		internal const string IdPrefix = "HQE_";

		internal HoldQueueEntryCommandBuilder(JmfNodeBuilder parent)
			: base(parent, Command.HoldQueueEntry, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public HoldQueueEntryCommandAttributeBuilder With() {
			return new HoldQueueEntryCommandAttributeBuilder(this);
		}
	}
}
