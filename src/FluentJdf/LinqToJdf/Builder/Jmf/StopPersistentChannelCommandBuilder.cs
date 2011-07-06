
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build StopPersistentChannel
	/// </summary>
	public partial class StopPersistentChannelCommandBuilder : CommandBuilder {
		internal const string IdPrefix = "SPC_";

		internal StopPersistentChannelCommandBuilder(JmfNodeBuilder parent)
			: base(parent, Command.StopPersistentChannel, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Add a non JDF Element to the Command.
		/// </summary>
		/// <param name="element">The element to add.</param>
		/// <returns></returns>
		public StopPersistentChannelCommandBuilder AddNode(XElement element) {
			ParameterCheck.ParameterRequired(element, "element");
			ParentJmfNode.Element.Add(element);
			return this;
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public StopPersistentChannelCommandAttributeBuilder With() {
			return new StopPersistentChannelCommandAttributeBuilder(this);
		}
	}
}
