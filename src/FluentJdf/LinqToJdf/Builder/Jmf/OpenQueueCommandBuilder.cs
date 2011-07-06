
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build OpenQueue
	/// </summary>
	public partial class OpenQueueCommandBuilder : CommandBuilder {
		internal const string IdPrefix = "OQ_";

		internal OpenQueueCommandBuilder(JmfNodeBuilder parent)
			: base(parent, Command.OpenQueue, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public OpenQueueCommandAttributeBuilder With() {
			return new OpenQueueCommandAttributeBuilder(this);
		}
	}
}
