
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build RequestForAuthentication
	/// </summary>
	public class RequestForAuthenticationQueryBuilder : QueryBuilder {
		internal const string IdPrefix = "RFA_";

		internal RequestForAuthenticationQueryBuilder(JmfNodeBuilder parent)
			: base(parent, Query.RequestForAuthentication, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public RequestForAuthenticationQueryAttributeBuilder With() {
			return new RequestForAuthenticationQueryAttributeBuilder(this);
		}
	}
}
