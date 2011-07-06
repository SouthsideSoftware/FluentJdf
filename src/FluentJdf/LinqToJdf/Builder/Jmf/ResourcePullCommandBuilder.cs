
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
		/// Add a non JDF Element to the Command.
		/// </summary>
		/// <param name="element">The element to add.</param>
		/// <returns></returns>
		public ResourcePullCommandBuilder AddNode(XElement element) {
			ParameterCheck.ParameterRequired(element, "element");
			ParentJmfNode.Element.Add(element);
			return this;
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
