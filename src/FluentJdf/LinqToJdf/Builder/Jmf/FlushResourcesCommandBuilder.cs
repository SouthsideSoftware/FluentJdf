
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build FlushResources
	/// </summary>
	public partial class FlushResourcesCommandBuilder : CommandBuilder {
		internal const string IdPrefix = "FR_";

		internal FlushResourcesCommandBuilder(JmfNodeBuilder parent)
			: base(parent, Command.FlushResources, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public FlushResourcesCommandAttributeBuilder With() {
			return new FlushResourcesCommandAttributeBuilder(this);
		}
	}
}
