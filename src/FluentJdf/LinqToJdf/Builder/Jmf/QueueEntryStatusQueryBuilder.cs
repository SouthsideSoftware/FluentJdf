
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build QueueEntryStatus
	/// </summary>
	public partial class QueueEntryStatusQueryBuilder : QueryBuilder {
		internal const string IdPrefix = "QES_";

		internal QueueEntryStatusQueryBuilder(JmfNodeBuilder parent)
			: base(parent, Query.QueueEntryStatus, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public QueueEntryStatusQueryAttributeBuilder With() {
			return new QueueEntryStatusQueryAttributeBuilder(this);
		}
	}
}
