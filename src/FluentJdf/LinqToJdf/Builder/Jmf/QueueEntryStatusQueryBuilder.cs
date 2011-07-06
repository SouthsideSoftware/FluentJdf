
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
		/// Add a non JDF Element to the Command.
		/// </summary>
		/// <param name="element">The element to add.</param>
		/// <returns></returns>
		public QueueEntryStatusQueryBuilder AddNode(XElement element) {
			ParameterCheck.ParameterRequired(element, "element");
			ParentJmfNode.Element.Add(element);
			return this;
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
