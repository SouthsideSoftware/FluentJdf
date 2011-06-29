
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build WakeUp
	/// </summary>
	public partial class WakeUpCommandBuilder : CommandBuilder {
		internal const string IdPrefix = "WU_";

		internal WakeUpCommandBuilder(JmfNodeBuilder parent)
			: base(parent, Command.WakeUp, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public WakeUpCommandAttributeBuilder With() {
			return new WakeUpCommandAttributeBuilder(this);
		}
	}
}
