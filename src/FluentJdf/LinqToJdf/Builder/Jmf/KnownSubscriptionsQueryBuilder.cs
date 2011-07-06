
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build KnownSubscriptions
	/// </summary>
	public partial class KnownSubscriptionsQueryBuilder : QueryBuilder {
		internal const string IdPrefix = "KS_";

		internal KnownSubscriptionsQueryBuilder(JmfNodeBuilder parent)
			: base(parent, Query.KnownSubscriptions, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Add a non JDF Element to the Command.
		/// </summary>
		/// <param name="element">The element to add.</param>
		/// <returns></returns>
		public KnownSubscriptionsQueryBuilder AddNode(XElement element) {
			ParameterCheck.ParameterRequired(element, "element");
			ParentJmfNode.Element.Add(element);
			return this;
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public KnownSubscriptionsQueryAttributeBuilder With() {
			return new KnownSubscriptionsQueryAttributeBuilder(this);
		}
	}
}
