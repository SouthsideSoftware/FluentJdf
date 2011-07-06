
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build ForceGang
	/// </summary>
	public partial class ForceGangCommandBuilder : CommandBuilder {
		internal const string IdPrefix = "FG_";

		internal ForceGangCommandBuilder(JmfNodeBuilder parent)
			: base(parent, Command.ForceGang, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Add a non JDF Element to the Command.
		/// </summary>
		/// <param name="element">The element to add.</param>
		/// <returns></returns>
		public ForceGangCommandBuilder AddNode(XElement element) {
			ParameterCheck.ParameterRequired(element, "element");
			ParentJmfNode.Element.Add(element);
			return this;
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public ForceGangCommandAttributeBuilder With() {
			return new ForceGangCommandAttributeBuilder(this);
		}
	}
}
