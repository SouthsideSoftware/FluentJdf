
using System;
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Build attributes for ResumeQueueCommandBuilder.
	/// </summary>
	public partial class ResumeQueueCommandAttributeBuilder : JmfAttributeBuilderBase {
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="builder"></param>
		internal ResumeQueueCommandAttributeBuilder(ResumeQueueCommandBuilder builder)
			: base(builder) {
		}

		/// <summary>
		/// Sets any attribute.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public ResumeQueueCommandAttributeBuilder Attribute(XName name, string value) {
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
		public ResumeQueueCommandAttributeBuilder AddAttribute(string name, string value) {
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
		public ResumeQueueCommandAttributeBuilder Id(string id) {

			Element.SetAttributeValue("ID", id);
			return this;
		}

		/// <summary>
		/// Sets a unique id
		/// </summary>
		/// <returns></returns>
		public ResumeQueueCommandAttributeBuilder UniqueId() {
			return Id(Globals.CreateUniqueId(ResumeQueueCommandBuilder.IdPrefix));
		}

		/// <summary>
		/// Sets the version of this JMF node.
		/// </summary>
		/// <param name="jdfVersion"></param>
		/// <returns></returns>
		public ResumeQueueCommandAttributeBuilder JdfVersion(string jdfVersion) {
			ParameterCheck.StringRequiredAndNotWhitespace(jdfVersion, "jdfVersion");

			Element.SetVersion(jdfVersion);
			return this;
		}		
	}
}

