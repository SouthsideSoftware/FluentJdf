
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build SetQueueEntryPriority
	/// </summary>
	public class SetQueueEntryPriorityCommandBuilder : CommandBuilder {
		internal const string IdPrefix = "SQEP_";

		internal SetQueueEntryPriorityCommandBuilder(JmfNodeBuilder parent)
			: base(parent, Command.SetQueueEntryPriority, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public SetQueueEntryPriorityCommandAttributeBuilder With() {
			return new SetQueueEntryPriorityCommandAttributeBuilder(this);
		}
	}
}
