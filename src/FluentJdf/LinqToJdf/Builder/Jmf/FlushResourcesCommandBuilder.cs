
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
		/// Add a non JDF Element to the Command.
		/// </summary>
		/// <param name="element">The element to add.</param>
		/// <returns></returns>
		public FlushResourcesCommandBuilder AddNode(XElement element) {
			ParameterCheck.ParameterRequired(element, "element");
			ParentJmfNode.Element.Add(element);
			return this;
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
