
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build NodeInfo
	/// </summary>
	public partial class NodeInfoQueryBuilder : QueryBuilder {
		internal const string IdPrefix = "NI_";

		internal NodeInfoQueryBuilder(JmfNodeBuilder parent)
			: base(parent, Query.NodeInfo, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public NodeInfoQueryAttributeBuilder With() {
			return new NodeInfoQueryAttributeBuilder(this);
		}
	}
}
