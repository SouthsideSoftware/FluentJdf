
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build Track
	/// </summary>
	public partial class TrackQueryBuilder : QueryBuilder {
		internal const string IdPrefix = "T_";

		internal TrackQueryBuilder(JmfNodeBuilder parent)
			: base(parent, Query.Track, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public TrackQueryAttributeBuilder With() {
			return new TrackQueryAttributeBuilder(this);
		}
	}
}
