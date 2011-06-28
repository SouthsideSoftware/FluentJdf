
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build CloseQueue
	/// </summary>
	public class CloseQueueCommandBuilder : CommandBuilder {
		internal const string IdPrefix = "CQ_";

		internal CloseQueueCommandBuilder(JmfNodeBuilder parent)
			: base(parent, Command.CloseQueue, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public CloseQueueCommandAttributeBuilder With() {
			return new CloseQueueCommandAttributeBuilder(this);
		}
	}
}
