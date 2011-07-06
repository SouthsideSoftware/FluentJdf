
using System.Xml.Linq;
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
		/// Add a non JDF Element to the Command.
		/// </summary>
		/// <param name="element">The element to add.</param>
		/// <returns></returns>
		public KnownDevicesQueryBuilder AddNode(XElement element) {
			ParameterCheck.ParameterRequired(element, "element");
			ParentJmfNode.Element.Add(element);
			return this;
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
