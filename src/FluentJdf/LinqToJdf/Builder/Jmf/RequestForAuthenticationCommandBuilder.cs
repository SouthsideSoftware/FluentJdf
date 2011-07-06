
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
		/// Add a non JDF Element to the Command.
		/// </summary>
		/// <param name="element">The element to add.</param>
		/// <returns></returns>
		public RequestForAuthenticationCommandBuilder AddNode(XElement element) {
			ParameterCheck.ParameterRequired(element, "element");
			ParentJmfNode.Element.Add(element);
			return this;
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
