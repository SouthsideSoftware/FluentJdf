
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build ResubmitQueueEntry
	/// </summary>
	public partial class ResubmitQueueEntryCommandBuilder : CommandBuilder {
		internal const string IdPrefix = "RQE_";

		internal ResubmitQueueEntryCommandBuilder(JmfNodeBuilder parent)
			: base(parent, Command.ResubmitQueueEntry, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Add a non JDF Element to the Command.
		/// </summary>
		/// <param name="element">The element to add.</param>
		/// <returns></returns>
		public ResubmitQueueEntryCommandBuilder AddNode(XElement element) {
			ParameterCheck.ParameterRequired(element, "element");
			ParentJmfNode.Element.Add(element);
			return this;
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public ResubmitQueueEntryCommandAttributeBuilder With() {
			return new ResubmitQueueEntryCommandAttributeBuilder(this);
		}
	}
}
