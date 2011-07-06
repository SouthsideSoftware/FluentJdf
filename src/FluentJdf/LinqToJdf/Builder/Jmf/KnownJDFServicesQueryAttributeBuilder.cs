
using System;
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Build attributes for KnownJDFServicesQueryBuilder.
	/// </summary>
	public partial class KnownJDFServicesQueryAttributeBuilder : JmfAttributeBuilderBase {
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="builder"></param>
		internal KnownJDFServicesQueryAttributeBuilder(KnownJDFServicesQueryBuilder builder)
			: base(builder) {
		}

		/// <summary>
		/// Sets any attribute.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public KnownJDFServicesQueryAttributeBuilder Attribute(XName name, string value) {
			ParameterCheck.ParameterRequired(name, "name");

			Element.SetAttributeValue(name, value);
			return this;
		}
		
		/// <summary>
		/// Add a non JDF Attribute to the Command.
		/// </summary>
		/// <param name="name">The attribute to add.</param>
		/// <param name="value">The value of the attribute</param>
		/// <returns></returns>
		public KnownJDFServicesQueryAttributeBuilder AddAttribute(string name, string value) {
			ParameterCheck.ParameterRequired(name, "name");
			ParameterCheck.ParameterRequired(value, "value");

			Element.SetAttributeValue(name, value);
			return this;
		}

		/// <summary>
		/// Set the id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public KnownJDFServicesQueryAttributeBuilder Id(string id) {

			Element.SetAttributeValue("ID", id);
			return this;
		}

		/// <summary>
		/// Sets a unique id
		/// </summary>
		/// <returns></returns>
		public KnownJDFServicesQueryAttributeBuilder UniqueId() {
			return Id(Globals.CreateUniqueId(KnownJDFServicesQueryBuilder.IdPrefix));
		}

		/// <summary>
		/// Sets the version of this JMF node.
		/// </summary>
		/// <param name="jdfVersion"></param>
		/// <returns></returns>
		public KnownJDFServicesQueryAttributeBuilder JdfVersion(string jdfVersion) {
			ParameterCheck.StringRequiredAndNotWhitespace(jdfVersion, "jdfVersion");

			Element.SetVersion(jdfVersion);
			return this;
		}		
	}
}

