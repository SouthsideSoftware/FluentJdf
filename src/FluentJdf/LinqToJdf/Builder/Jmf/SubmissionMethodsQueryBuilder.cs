
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build SubmissionMethods
	/// </summary>
	public partial class SubmissionMethodsQueryBuilder : QueryBuilder {
		internal const string IdPrefix = "SM_";

		internal SubmissionMethodsQueryBuilder(JmfNodeBuilder parent)
			: base(parent, Query.SubmissionMethods, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public SubmissionMethodsQueryAttributeBuilder With() {
			return new SubmissionMethodsQueryAttributeBuilder(this);
		}
	}
}
