
using System;
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Build attributes for RepeatMessagesQueryBuilder.
	/// </summary>
	public class RepeatMessagesQueryAttributeBuilder : JmfAttributeBuilderBase {
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="builder"></param>
		internal RepeatMessagesQueryAttributeBuilder(RepeatMessagesQueryBuilder builder)
			: base(builder) {
		}

		/// <summary>
		/// Sets any attribute.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public RepeatMessagesQueryAttributeBuilder Attribute(XName name, string value) {
			ParameterCheck.ParameterRequired(name, "name");

			Element.SetAttributeValue(name, value);
			return this;
		}

		/// <summary>
		/// Set the id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public RepeatMessagesQueryAttributeBuilder Id(string id) {

			ParentJmfNode.Element.SetAttributeValue("ID", id);
			return this;
		}

		/// <summary>
		/// Sets a unique id
		/// </summary>
		/// <returns></returns>
		public RepeatMessagesQueryAttributeBuilder UniqueId() {
			return Id(Globals.CreateUniqueId(RepeatMessagesQueryBuilder.IdPrefix));
		}
	}
}

