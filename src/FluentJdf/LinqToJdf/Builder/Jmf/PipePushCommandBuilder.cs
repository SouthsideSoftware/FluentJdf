
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build PipePush
	/// </summary>
	public partial class PipePushCommandBuilder : CommandBuilder {
		internal const string IdPrefix = "PP_";

		internal PipePushCommandBuilder(JmfNodeBuilder parent)
			: base(parent, Command.PipePush, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Add a non JDF Element to the Command.
		/// </summary>
		/// <param name="element">The element to add.</param>
		/// <returns></returns>
		public PipePushCommandBuilder AddNode(XElement element) {
			ParameterCheck.ParameterRequired(element, "element");
			ParentJmfNode.Element.Add(element);
			return this;
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public PipePushCommandAttributeBuilder With() {
			return new PipePushCommandAttributeBuilder(this);
		}
	}
}
