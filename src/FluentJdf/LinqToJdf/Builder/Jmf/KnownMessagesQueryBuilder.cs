
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build KnownMessages
	/// </summary>
	public partial class KnownMessagesQueryBuilder : QueryBuilder {
		internal const string IdPrefix = "KM_";

		internal KnownMessagesQueryBuilder(JmfNodeBuilder parent)
			: base(parent, Query.KnownMessages, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public KnownMessagesQueryAttributeBuilder With() {
			return new KnownMessagesQueryAttributeBuilder(this);
		}
	}
}
