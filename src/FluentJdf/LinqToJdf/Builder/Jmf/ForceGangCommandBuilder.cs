
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build ForceGang
	/// </summary>
	public class ForceGangCommandBuilder : CommandBuilder {
		internal const string IdPrefix = "FG_";

		internal ForceGangCommandBuilder(JmfNodeBuilder parent)
			: base(parent, Command.ForceGang, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public ForceGangCommandAttributeBuilder With() {
			return new ForceGangCommandAttributeBuilder(this);
		}
	}
}
