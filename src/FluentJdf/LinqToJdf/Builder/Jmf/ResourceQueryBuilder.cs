
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build Resource
	/// </summary>
	public partial class ResourceQueryBuilder : QueryBuilder {
		internal const string IdPrefix = "R_";

		internal ResourceQueryBuilder(JmfNodeBuilder parent)
			: base(parent, Query.Resource, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public ResourceQueryAttributeBuilder With() {
			return new ResourceQueryAttributeBuilder(this);
		}
	}
}
