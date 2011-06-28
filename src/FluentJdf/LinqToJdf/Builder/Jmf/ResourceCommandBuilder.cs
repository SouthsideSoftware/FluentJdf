
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build Resource
	/// </summary>
	public class ResourceCommandBuilder : CommandBuilder {
		internal const string IdPrefix = "R_";

		internal ResourceCommandBuilder(JmfNodeBuilder parent)
			: base(parent, Command.Resource, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public ResourceCommandAttributeBuilder With() {
			return new ResourceCommandAttributeBuilder(this);
		}
	}
}
