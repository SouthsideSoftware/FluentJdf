
using System;
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Build attributes for QueueEntryStatusQueryBuilder.
	/// </summary>
	public class QueueEntryStatusQueryAttributeBuilder : JmfAttributeBuilderBase {
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="builder"></param>
		internal QueueEntryStatusQueryAttributeBuilder(QueueEntryStatusQueryBuilder builder)
			: base(builder) {
		}

		/// <summary>
		/// Sets any attribute.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public QueueEntryStatusQueryAttributeBuilder Attribute(XName name, string value) {
			ParameterCheck.ParameterRequired(name, "name");

			Element.SetAttributeValue(name, value);
			return this;
		}

		/// <summary>
		/// Set the id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public QueueEntryStatusQueryAttributeBuilder Id(string id) {

			ParentJmfNode.Element.SetAttributeValue("ID", id);
			return this;
		}

		/// <summary>
		/// Sets a unique id
		/// </summary>
		/// <returns></returns>
		public QueueEntryStatusQueryAttributeBuilder UniqueId() {
			return Id(Globals.CreateUniqueId(QueueEntryStatusQueryBuilder.IdPrefix));
		}
	}
}

