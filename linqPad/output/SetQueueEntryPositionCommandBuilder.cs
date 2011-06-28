
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build SetQueueEntryPosition
	/// </summary>
	public class SetQueueEntryPositionCommandBuilder : CommandBuilder {
		internal const string IdPrefix = "SQEP_";

		internal SetQueueEntryPositionCommandBuilder(JmfNodeBuilder parent)
			: base(parent, Command.SetQueueEntryPosition, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public SetQueueEntryPositionCommandAttributeBuilder With() {
			return new SetQueueEntryPositionCommandAttributeBuilder(this);
		}
	}
}
