
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build RepeatMessages
	/// </summary>
	public partial class RepeatMessagesQueryBuilder : QueryBuilder {
		internal const string IdPrefix = "RM_";

		internal RepeatMessagesQueryBuilder(JmfNodeBuilder parent)
			: base(parent, Query.RepeatMessages, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public RepeatMessagesQueryAttributeBuilder With() {
			return new RepeatMessagesQueryAttributeBuilder(this);
		}
	}
}
