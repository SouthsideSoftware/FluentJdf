
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build QueueStatus
	/// </summary>
	public partial class QueueStatusQueryBuilder : QueryBuilder {
		internal const string IdPrefix = "QS_";

		internal QueueStatusQueryBuilder(JmfNodeBuilder parent)
			: base(parent, Query.QueueStatus, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Add a non JDF Element to the Command.
		/// </summary>
		/// <param name="element">The element to add.</param>
		/// <returns></returns>
		public QueueStatusQueryBuilder AddNode(XElement element) {
			ParameterCheck.ParameterRequired(element, "element");
			ParentJmfNode.Element.Add(element);
			return this;
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public QueueStatusQueryAttributeBuilder With() {
			return new QueueStatusQueryAttributeBuilder(this);
		}
	}
}
