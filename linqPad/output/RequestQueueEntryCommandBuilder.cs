
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build RequestQueueEntry
	/// </summary>
	public class RequestQueueEntryCommandBuilder : CommandBuilder {
		internal const string IdPrefix = "RQE_";

		internal RequestQueueEntryCommandBuilder(JmfNodeBuilder parent)
			: base(parent, Command.RequestQueueEntry, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public RequestQueueEntryCommandAttributeBuilder With() {
			return new RequestQueueEntryCommandAttributeBuilder(this);
		}
	}
}
