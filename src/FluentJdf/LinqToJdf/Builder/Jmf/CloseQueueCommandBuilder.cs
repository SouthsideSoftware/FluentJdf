
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build CloseQueue
	/// </summary>
	public partial class CloseQueueCommandBuilder : CommandBuilder {
		internal const string IdPrefix = "CQ_";

		internal CloseQueueCommandBuilder(JmfNodeBuilder parent)
			: base(parent, Command.CloseQueue, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Add a non JDF Element to the Command.
		/// </summary>
		/// <param name="element">The element to add.</param>
		/// <returns></returns>
		public CloseQueueCommandBuilder AddNode(XElement element) {
			ParameterCheck.ParameterRequired(element, "element");
			ParentJmfNode.Element.Add(element);
			return this;
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public CloseQueueCommandAttributeBuilder With() {
			return new CloseQueueCommandAttributeBuilder(this);
		}
	}
}
