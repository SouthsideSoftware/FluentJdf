
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build NodeInfo
	/// </summary>
	public partial class NodeInfoCommandBuilder : CommandBuilder {
		internal const string IdPrefix = "NI_";

		internal NodeInfoCommandBuilder(JmfNodeBuilder parent)
			: base(parent, Command.NodeInfo, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Add a non JDF Element to the Command.
		/// </summary>
		/// <param name="element">The element to add.</param>
		/// <returns></returns>
		public NodeInfoCommandBuilder AddNode(XElement element) {
			ParameterCheck.ParameterRequired(element, "element");
			ParentJmfNode.Element.Add(element);
			return this;
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public NodeInfoCommandAttributeBuilder With() {
			return new NodeInfoCommandAttributeBuilder(this);
		}
	}
}
