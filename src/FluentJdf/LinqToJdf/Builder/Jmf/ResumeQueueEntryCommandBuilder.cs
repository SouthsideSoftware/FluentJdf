
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build ResumeQueueEntry
	/// </summary>
	public class ResumeQueueEntryCommandBuilder : CommandBuilder {
		internal const string IdPrefix = "RQE_";

		internal ResumeQueueEntryCommandBuilder(JmfNodeBuilder parent)
			: base(parent, Command.ResumeQueueEntry, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public ResumeQueueEntryCommandAttributeBuilder With() {
			return new ResumeQueueEntryCommandAttributeBuilder(this);
		}
	}
}
