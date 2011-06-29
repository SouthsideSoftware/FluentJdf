
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build Status
	/// </summary>
	public partial class StatusQueryBuilder : QueryBuilder {
		internal const string IdPrefix = "S_";

		internal StatusQueryBuilder(JmfNodeBuilder parent)
			: base(parent, Query.Status, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public StatusQueryAttributeBuilder With() {
			return new StatusQueryAttributeBuilder(this);
		}
	}
}
