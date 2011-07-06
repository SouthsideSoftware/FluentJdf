
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build ResourcePull
	/// </summary>
	public partial class ResourcePullCommandBuilder : CommandBuilder {
		internal const string IdPrefix = "RP_";

		internal ResourcePullCommandBuilder(JmfNodeBuilder parent)
			: base(parent, Command.ResourcePull, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public ResourcePullCommandAttributeBuilder With() {
			return new ResourcePullCommandAttributeBuilder(this);
		}
	}
}
