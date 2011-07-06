
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build HoldQueueEntry
	/// </summary>
	public partial class HoldQueueEntryCommandBuilder : CommandBuilder {
		internal const string IdPrefix = "HQE_";

		internal HoldQueueEntryCommandBuilder(JmfNodeBuilder parent)
			: base(parent, Command.HoldQueueEntry, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Add a non JDF Element to the Command.
		/// </summary>
		/// <param name="element">The element to add.</param>
		/// <returns></returns>
		public HoldQueueEntryCommandBuilder AddNode(XElement element) {
			ParameterCheck.ParameterRequired(element, "element");
			ParentJmfNode.Element.Add(element);
			return this;
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public HoldQueueEntryCommandAttributeBuilder With() {
			return new HoldQueueEntryCommandAttributeBuilder(this);
		}
	}
}
