
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build Events
	/// </summary>
	public partial class EventsQueryBuilder : QueryBuilder {
		internal const string IdPrefix = "E_";

		internal EventsQueryBuilder(JmfNodeBuilder parent)
			: base(parent, Query.Events, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public EventsQueryAttributeBuilder With() {
			return new EventsQueryAttributeBuilder(this);
		}
	}
}
