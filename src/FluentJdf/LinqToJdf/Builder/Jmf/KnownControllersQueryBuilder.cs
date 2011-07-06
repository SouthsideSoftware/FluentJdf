
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
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public KnownControllersQueryAttributeBuilder With() {
			return new KnownControllersQueryAttributeBuilder(this);
		}
	}
}
