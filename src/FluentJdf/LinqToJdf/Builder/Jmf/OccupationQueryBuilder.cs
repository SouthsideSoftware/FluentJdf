
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build Occupation
	/// </summary>
	public partial class OccupationQueryBuilder : QueryBuilder {
		internal const string IdPrefix = "O_";

		internal OccupationQueryBuilder(JmfNodeBuilder parent)
			: base(parent, Query.Occupation, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public OccupationQueryAttributeBuilder With() {
			return new OccupationQueryAttributeBuilder(this);
		}
	}
}
