
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build ModifyNode
	/// </summary>
	public class ModifyNodeCommandBuilder : CommandBuilder {
		internal const string IdPrefix = "MN_";

		internal ModifyNodeCommandBuilder(JmfNodeBuilder parent)
			: base(parent, Command.ModifyNode, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public ModifyNodeCommandAttributeBuilder With() {
			return new ModifyNodeCommandAttributeBuilder(this);
		}
	}
}
