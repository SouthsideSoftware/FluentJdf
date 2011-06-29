
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build HoldQueue
	/// </summary>
	public partial class HoldQueueCommandBuilder : CommandBuilder {
		internal const string IdPrefix = "HQ_";

		internal HoldQueueCommandBuilder(JmfNodeBuilder parent)
			: base(parent, Command.HoldQueue, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public HoldQueueCommandAttributeBuilder With() {
			return new HoldQueueCommandAttributeBuilder(this);
		}
	}
}
