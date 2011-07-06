
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build KnownJDFServices
	/// </summary>
	public partial class KnownJDFServicesQueryBuilder : QueryBuilder {
		internal const string IdPrefix = "KJDFS_";

		internal KnownJDFServicesQueryBuilder(JmfNodeBuilder parent)
			: base(parent, Query.KnownJDFServices, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Add a non JDF Element to the Command.
		/// </summary>
		/// <param name="element">The element to add.</param>
		/// <returns></returns>
		public KnownJDFServicesQueryBuilder AddNode(XElement element) {
			ParameterCheck.ParameterRequired(element, "element");
			ParentJmfNode.Element.Add(element);
			return this;
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public KnownJDFServicesQueryAttributeBuilder With() {
			return new KnownJDFServicesQueryAttributeBuilder(this);
		}
	}
}
