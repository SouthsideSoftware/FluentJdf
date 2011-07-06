
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build NewJDF
	/// </summary>
	public partial class NewJDFQueryBuilder : QueryBuilder {
		internal const string IdPrefix = "NJDF_";

		internal NewJDFQueryBuilder(JmfNodeBuilder parent)
			: base(parent, Query.NewJDF, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Add a non JDF Element to the Command.
		/// </summary>
		/// <param name="element">The element to add.</param>
		/// <returns></returns>
		public NewJDFQueryBuilder AddNode(XElement element) {
			ParameterCheck.ParameterRequired(element, "element");
			ParentJmfNode.Element.Add(element);
			return this;
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public NewJDFQueryAttributeBuilder With() {
			return new NewJDFQueryAttributeBuilder(this);
		}
	}
}
