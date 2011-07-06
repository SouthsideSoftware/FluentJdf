
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build PipePull
	/// </summary>
	public partial class PipePullCommandBuilder : CommandBuilder {
		internal const string IdPrefix = "PP_";

		internal PipePullCommandBuilder(JmfNodeBuilder parent)
			: base(parent, Command.PipePull, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Add a non JDF Element to the Command.
		/// </summary>
		/// <param name="element">The element to add.</param>
		/// <returns></returns>
		public PipePullCommandBuilder AddNode(XElement element) {
			ParameterCheck.ParameterRequired(element, "element");
			ParentJmfNode.Element.Add(element);
			return this;
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public PipePullCommandAttributeBuilder With() {
			return new PipePullCommandAttributeBuilder(this);
		}
	}
}
