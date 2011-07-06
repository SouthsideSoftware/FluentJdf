
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build ShutDown
	/// </summary>
	public partial class ShutDownCommandBuilder : CommandBuilder {
		internal const string IdPrefix = "SD_";

		internal ShutDownCommandBuilder(JmfNodeBuilder parent)
			: base(parent, Command.ShutDown, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Add a non JDF Element to the Command.
		/// </summary>
		/// <param name="element">The element to add.</param>
		/// <returns></returns>
		public ShutDownCommandBuilder AddNode(XElement element) {
			ParameterCheck.ParameterRequired(element, "element");
			ParentJmfNode.Element.Add(element);
			return this;
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public ShutDownCommandAttributeBuilder With() {
			return new ShutDownCommandAttributeBuilder(this);
		}
	}
}
