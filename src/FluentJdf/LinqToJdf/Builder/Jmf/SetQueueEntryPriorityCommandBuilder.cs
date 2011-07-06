
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build SetQueueEntryPriority
	/// </summary>
	public partial class SetQueueEntryPriorityCommandBuilder : CommandBuilder {
		internal const string IdPrefix = "SQEP_";

		internal SetQueueEntryPriorityCommandBuilder(JmfNodeBuilder parent)
			: base(parent, Command.SetQueueEntryPriority, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Add a non JDF Element to the Command.
		/// </summary>
		/// <param name="element">The element to add.</param>
		/// <returns></returns>
		public SetQueueEntryPriorityCommandBuilder AddNode(XElement element) {
			ParameterCheck.ParameterRequired(element, "element");
			ParentJmfNode.Element.Add(element);
			return this;
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public SetQueueEntryPriorityCommandAttributeBuilder With() {
			return new SetQueueEntryPriorityCommandAttributeBuilder(this);
		}
	}
}
