
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
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public AbortQueueEntryCommandAttributeBuilder With() {
			return new AbortQueueEntryCommandAttributeBuilder(this);
		}
	}
}
