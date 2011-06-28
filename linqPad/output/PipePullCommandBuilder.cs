
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build PipePull
	/// </summary>
	public class PipePullCommandBuilder : CommandBuilder {
		internal const string IdPrefix = "PP_";

		internal PipePullCommandBuilder(JmfNodeBuilder parent)
			: base(parent, Command.PipePull, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public PipePullCommandAttributeBuilder With() {
			return new PipePullCommandAttributeBuilder(this);
		}
	}
}
