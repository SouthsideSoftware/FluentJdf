
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build PipePush
	/// </summary>
	public partial class PipePushCommandBuilder : CommandBuilder {
		internal const string IdPrefix = "PP_";

		internal PipePushCommandBuilder(JmfNodeBuilder parent)
			: base(parent, Command.PipePush, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public PipePushCommandAttributeBuilder With() {
			return new PipePushCommandAttributeBuilder(this);
		}
	}
}
