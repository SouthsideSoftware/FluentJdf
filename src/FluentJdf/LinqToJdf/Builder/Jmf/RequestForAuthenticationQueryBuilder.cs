
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build RequestForAuthentication
	/// </summary>
	public partial class RequestForAuthenticationQueryBuilder : QueryBuilder {
		internal const string IdPrefix = "RFA_";

		internal RequestForAuthenticationQueryBuilder(JmfNodeBuilder parent)
			: base(parent, Query.RequestForAuthentication, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Add a non JDF Element to the Command.
		/// </summary>
		/// <param name="element">The element to add.</param>
		/// <returns></returns>
		public RequestForAuthenticationQueryBuilder AddNode(XElement element) {
			ParameterCheck.ParameterRequired(element, "element");
			ParentJmfNode.Element.Add(element);
			return this;
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public RequestForAuthenticationQueryAttributeBuilder With() {
			return new RequestForAuthenticationQueryAttributeBuilder(this);
		}
	}
}
