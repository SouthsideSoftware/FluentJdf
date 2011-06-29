
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build SubmitQueueEntry
	/// </summary>
	public partial class SubmitQueueEntryCommandBuilder : CommandBuilder {
		internal const string IdPrefix = "SQE_";

		internal SubmitQueueEntryCommandBuilder(JmfNodeBuilder parent)
			: base(parent, Command.SubmitQueueEntry, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public SubmitQueueEntryCommandAttributeBuilder With() {
			return new SubmitQueueEntryCommandAttributeBuilder(this);
		}
	}
}
