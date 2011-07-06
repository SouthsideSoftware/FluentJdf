
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build AbortQueueEntry
	/// </summary>
	public partial class AbortQueueEntryCommandBuilder : CommandBuilder {
		internal const string IdPrefix = "AQE_";

		internal AbortQueueEntryCommandBuilder(JmfNodeBuilder parent)
			: base(parent, Command.AbortQueueEntry, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Add a non JDF Element to the Command.
		/// </summary>
		/// <param name="element">The element to add.</param>
		/// <returns></returns>
		public AbortQueueEntryCommandBuilder AddNode(XElement element) {
			ParameterCheck.ParameterRequired(element, "element");
			ParentJmfNode.Element.Add(element);
			return this;
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public AbortQueueEntryCommandAttributeBuilder With() {
			return new AbortQueueEntryCommandAttributeBuilder(this);
		}
	}
}
