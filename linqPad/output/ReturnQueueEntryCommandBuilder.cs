
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build ReturnQueueEntry
	/// </summary>
	public class ReturnQueueEntryCommandBuilder : CommandBuilder {
		internal const string IdPrefix = "RQE_";

		internal ReturnQueueEntryCommandBuilder(JmfNodeBuilder parent)
			: base(parent, Command.ReturnQueueEntry, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public ReturnQueueEntryCommandAttributeBuilder With() {
			return new ReturnQueueEntryCommandAttributeBuilder(this);
		}
	}
}
