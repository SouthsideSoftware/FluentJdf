
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build HoldQueue
	/// </summary>
	public partial class HoldQueueCommandBuilder : CommandBuilder {
		internal const string IdPrefix = "HQ_";

		internal HoldQueueCommandBuilder(JmfNodeBuilder parent)
			: base(parent, Command.HoldQueue, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Add a non JDF Element to the Command.
		/// </summary>
		/// <param name="element">The element to add.</param>
		/// <returns></returns>
		public HoldQueueCommandBuilder AddNode(XElement element) {
			ParameterCheck.ParameterRequired(element, "element");
			ParentJmfNode.Element.Add(element);
			return this;
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public HoldQueueCommandAttributeBuilder With() {
			return new HoldQueueCommandAttributeBuilder(this);
		}
	}
}
