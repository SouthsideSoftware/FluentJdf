
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build ForceGang
	/// </summary>
	public partial class ForceGangQueryBuilder : QueryBuilder {
		internal const string IdPrefix = "FG_";

		internal ForceGangQueryBuilder(JmfNodeBuilder parent)
			: base(parent, Query.ForceGang, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Add a non JDF Element to the Command.
		/// </summary>
		/// <param name="element">The element to add.</param>
		/// <returns></returns>
		public ForceGangQueryBuilder AddNode(XElement element) {
			ParameterCheck.ParameterRequired(element, "element");
			ParentJmfNode.Element.Add(element);
			return this;
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public ForceGangQueryAttributeBuilder With() {
			return new ForceGangQueryAttributeBuilder(this);
		}
	}
}
