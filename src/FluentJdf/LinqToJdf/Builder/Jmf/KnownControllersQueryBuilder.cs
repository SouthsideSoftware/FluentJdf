
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build KnownControllers
	/// </summary>
	public partial class KnownControllersQueryBuilder : QueryBuilder {
		internal const string IdPrefix = "KC_";

		internal KnownControllersQueryBuilder(JmfNodeBuilder parent)
			: base(parent, Query.KnownControllers, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Add a non JDF Element to the Command.
		/// </summary>
		/// <param name="element">The element to add.</param>
		/// <returns></returns>
		public KnownControllersQueryBuilder AddNode(XElement element) {
			ParameterCheck.ParameterRequired(element, "element");
			ParentJmfNode.Element.Add(element);
			return this;
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public KnownControllersQueryAttributeBuilder With() {
			return new KnownControllersQueryAttributeBuilder(this);
		}
	}
}
