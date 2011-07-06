
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build SetQueueEntryPosition
	/// </summary>
	public partial class SetQueueEntryPositionCommandBuilder : CommandBuilder {
		internal const string IdPrefix = "SQEP_";

		internal SetQueueEntryPositionCommandBuilder(JmfNodeBuilder parent)
			: base(parent, Command.SetQueueEntryPosition, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Add a non JDF Element to the Command.
		/// </summary>
		/// <param name="element">The element to add.</param>
		/// <returns></returns>
		public SetQueueEntryPositionCommandBuilder AddNode(XElement element) {
			ParameterCheck.ParameterRequired(element, "element");
			ParentJmfNode.Element.Add(element);
			return this;
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public SetQueueEntryPositionCommandAttributeBuilder With() {
			return new SetQueueEntryPositionCommandAttributeBuilder(this);
		}
	}
}
