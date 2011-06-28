
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build NodeInfo
	/// </summary>
	public class NodeInfoCommandBuilder : CommandBuilder {
		internal const string IdPrefix = "NI_";

		internal NodeInfoCommandBuilder(JmfNodeBuilder parent)
			: base(parent, Command.NodeInfo, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public NodeInfoCommandAttributeBuilder With() {
			return new NodeInfoCommandAttributeBuilder(this);
		}
	}
}
