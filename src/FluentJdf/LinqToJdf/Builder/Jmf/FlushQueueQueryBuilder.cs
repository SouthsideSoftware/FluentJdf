
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build FlushQueue
	/// </summary>
	public partial class FlushQueueQueryBuilder : QueryBuilder {
		internal const string IdPrefix = "FQ_";

		internal FlushQueueQueryBuilder(JmfNodeBuilder parent)
			: base(parent, Query.FlushQueue, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Add a non JDF Element to the Command.
		/// </summary>
		/// <param name="element">The element to add.</param>
		/// <returns></returns>
		public FlushQueueQueryBuilder AddNode(XElement element) {
			ParameterCheck.ParameterRequired(element, "element");
			ParentJmfNode.Element.Add(element);
			return this;
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public FlushQueueQueryAttributeBuilder With() {
			return new FlushQueueQueryAttributeBuilder(this);
		}
	}
}
