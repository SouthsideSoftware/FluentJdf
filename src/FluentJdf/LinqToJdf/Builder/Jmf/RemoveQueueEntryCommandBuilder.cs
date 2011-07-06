
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build RemoveQueueEntry
	/// </summary>
	public partial class RemoveQueueEntryCommandBuilder : CommandBuilder {
		internal const string IdPrefix = "RQE_";

		internal RemoveQueueEntryCommandBuilder(JmfNodeBuilder parent)
			: base(parent, Command.RemoveQueueEntry, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Add a non JDF Element to the Command.
		/// </summary>
		/// <param name="element">The element to add.</param>
		/// <returns></returns>
		public RemoveQueueEntryCommandBuilder AddNode(XElement element) {
			ParameterCheck.ParameterRequired(element, "element");
			ParentJmfNode.Element.Add(element);
			return this;
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public RemoveQueueEntryCommandAttributeBuilder With() {
			return new RemoveQueueEntryCommandAttributeBuilder(this);
		}
	}
}
