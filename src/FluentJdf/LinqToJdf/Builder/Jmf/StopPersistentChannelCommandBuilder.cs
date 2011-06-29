
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build StopPersistentChannel
	/// </summary>
	public partial class StopPersistentChannelCommandBuilder : CommandBuilder {
		internal const string IdPrefix = "SPC_";

		internal StopPersistentChannelCommandBuilder(JmfNodeBuilder parent)
			: base(parent, Command.StopPersistentChannel, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public StopPersistentChannelCommandAttributeBuilder With() {
			return new StopPersistentChannelCommandAttributeBuilder(this);
		}
	}
}
