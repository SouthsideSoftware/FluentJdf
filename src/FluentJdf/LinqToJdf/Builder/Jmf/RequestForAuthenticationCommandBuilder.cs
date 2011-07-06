
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build RequestForAuthentication
	/// </summary>
	public partial class RequestForAuthenticationCommandBuilder : CommandBuilder {
		internal const string IdPrefix = "RFA_";

		internal RequestForAuthenticationCommandBuilder(JmfNodeBuilder parent)
			: base(parent, Command.RequestForAuthentication, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public RequestForAuthenticationCommandAttributeBuilder With() {
			return new RequestForAuthenticationCommandAttributeBuilder(this);
		}
	}
}
