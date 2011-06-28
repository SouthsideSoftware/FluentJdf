
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build PipePause
	/// </summary>
	public class PipePauseCommandBuilder : CommandBuilder {
		internal const string IdPrefix = "PP_";

		internal PipePauseCommandBuilder(JmfNodeBuilder parent)
			: base(parent, Command.PipePause, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public PipePauseCommandAttributeBuilder With() {
			return new PipePauseCommandAttributeBuilder(this);
		}
	}
}
