
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build KnownDevices
	/// </summary>
	public partial class KnownDevicesQueryBuilder : QueryBuilder {
		internal const string IdPrefix = "KD_";

		internal KnownDevicesQueryBuilder(JmfNodeBuilder parent)
			: base(parent, Query.KnownDevices, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public KnownDevicesQueryAttributeBuilder With() {
			return new KnownDevicesQueryAttributeBuilder(this);
		}
	}
}
