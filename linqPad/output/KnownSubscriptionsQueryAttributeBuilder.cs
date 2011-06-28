
using System;
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Build attributes for KnownSubscriptionsQueryBuilder.
	/// </summary>
	public class KnownSubscriptionsQueryAttributeBuilder : JmfAttributeBuilderBase {
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="builder"></param>
		internal KnownSubscriptionsQueryAttributeBuilder(KnownSubscriptionsQueryBuilder builder)
			: base(builder) {
		}

		/// <summary>
		/// Sets any attribute.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public KnownSubscriptionsQueryAttributeBuilder Attribute(XName name, string value) {
			ParameterCheck.ParameterRequired(name, "name");

			Element.SetAttributeValue(name, value);
			return this;
		}

		/// <summary>
		/// Set the id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public KnownSubscriptionsQueryAttributeBuilder Id(string id) {

			ParentJmfNode.Element.SetAttributeValue("ID", id);
			return this;
		}

		/// <summary>
		/// Sets a unique id
		/// </summary>
		/// <returns></returns>
		public KnownSubscriptionsQueryAttributeBuilder UniqueId() {
			return Id(Globals.CreateUniqueId(KnownSubscriptionsQueryBuilder.IdPrefix));
		}
	}
}

