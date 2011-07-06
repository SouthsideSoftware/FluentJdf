
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build SuspendQueueEntry
	/// </summary>
	public partial class SuspendQueueEntryCommandBuilder : CommandBuilder {
		internal const string IdPrefix = "SQE_";

		internal SuspendQueueEntryCommandBuilder(JmfNodeBuilder parent)
			: base(parent, Command.SuspendQueueEntry, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Add a non JDF Element to the Command.
		/// </summary>
		/// <param name="element">The element to add.</param>
		/// <returns></returns>
		public SuspendQueueEntryCommandBuilder AddNode(XElement element) {
			ParameterCheck.ParameterRequired(element, "element");
			ParentJmfNode.Element.Add(element);
			return this;
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public SuspendQueueEntryCommandAttributeBuilder With() {
			return new SuspendQueueEntryCommandAttributeBuilder(this);
		}
	}
}
