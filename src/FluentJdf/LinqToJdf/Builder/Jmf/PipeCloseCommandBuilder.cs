
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build PipeClose
	/// </summary>
	public partial class PipeCloseCommandBuilder : CommandBuilder {
		internal const string IdPrefix = "PC_";

		internal PipeCloseCommandBuilder(JmfNodeBuilder parent)
			: base(parent, Command.PipeClose, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Add a non JDF Element to the Command.
		/// </summary>
		/// <param name="element">The element to add.</param>
		/// <returns></returns>
		public PipeCloseCommandBuilder AddNode(XElement element) {
			ParameterCheck.ParameterRequired(element, "element");
			ParentJmfNode.Element.Add(element);
			return this;
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public PipeCloseCommandAttributeBuilder With() {
			return new PipeCloseCommandAttributeBuilder(this);
		}
	}
}
