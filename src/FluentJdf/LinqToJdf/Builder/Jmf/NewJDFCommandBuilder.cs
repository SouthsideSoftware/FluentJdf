
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build NewJDF
	/// </summary>
	public partial class NewJDFCommandBuilder : CommandBuilder {
		internal const string IdPrefix = "NJDF_";

		internal NewJDFCommandBuilder(JmfNodeBuilder parent)
			: base(parent, Command.NewJDF, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Add a non JDF Element to the Command.
		/// </summary>
		/// <param name="element">The element to add.</param>
		/// <returns></returns>
		public NewJDFCommandBuilder AddNode(XElement element) {
			ParameterCheck.ParameterRequired(element, "element");
			ParentJmfNode.Element.Add(element);
			return this;
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public NewJDFCommandAttributeBuilder With() {
			return new NewJDFCommandAttributeBuilder(this);
		}
	}
}
