
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build ResumeQueue
	/// </summary>
	public partial class ResumeQueueCommandBuilder : CommandBuilder {
		internal const string IdPrefix = "RQ_";

		internal ResumeQueueCommandBuilder(JmfNodeBuilder parent)
			: base(parent, Command.ResumeQueue, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public ResumeQueueCommandAttributeBuilder With() {
			return new ResumeQueueCommandAttributeBuilder(this);
		}
	}
}
