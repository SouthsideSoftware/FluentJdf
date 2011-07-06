
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build FlushQueue
	/// </summary>
	public partial class FlushQueueCommandBuilder : CommandBuilder {
		internal const string IdPrefix = "FQ_";

		internal FlushQueueCommandBuilder(JmfNodeBuilder parent)
			: base(parent, Command.FlushQueue, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public FlushQueueCommandAttributeBuilder With() {
			return new FlushQueueCommandAttributeBuilder(this);
		}
	}
}
