
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build NewJDF
	/// </summary>
	public class NewJDFCommandBuilder : CommandBuilder {
		internal const string IdPrefix = "NJDF_";

		internal NewJDFCommandBuilder(JmfNodeBuilder parent)
			: base(parent, Command.NewJDF, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public NewJDFCommandAttributeBuilder With() {
			return new NewJDFCommandAttributeBuilder(this);
		}
	}
}
