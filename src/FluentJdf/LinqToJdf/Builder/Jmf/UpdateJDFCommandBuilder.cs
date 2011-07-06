
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build UpdateJDF
	/// </summary>
	public partial class UpdateJDFCommandBuilder : CommandBuilder {
		internal const string IdPrefix = "UJDF_";

		internal UpdateJDFCommandBuilder(JmfNodeBuilder parent)
			: base(parent, Command.UpdateJDF, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public UpdateJDFCommandAttributeBuilder With() {
			return new UpdateJDFCommandAttributeBuilder(this);
		}
	}
}
