
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build ModifyNode
	/// </summary>
	public partial class ModifyNodeCommandBuilder : CommandBuilder {
		internal const string IdPrefix = "MN_";

		internal ModifyNodeCommandBuilder(JmfNodeBuilder parent)
			: base(parent, Command.ModifyNode, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Add a non JDF Element to the Command.
		/// </summary>
		/// <param name="element">The element to add.</param>
		/// <returns></returns>
		public ModifyNodeCommandBuilder AddNode(XElement element) {
			ParameterCheck.ParameterRequired(element, "element");
			ParentJmfNode.Element.Add(element);
			return this;
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public ModifyNodeCommandAttributeBuilder With() {
			return new ModifyNodeCommandAttributeBuilder(this);
		}
	}
}
