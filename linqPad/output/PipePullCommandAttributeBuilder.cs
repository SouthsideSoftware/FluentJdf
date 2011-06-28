
using System;
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Build attributes for PipePullCommandBuilder.
	/// </summary>
	public class PipePullCommandAttributeBuilder : JmfAttributeBuilderBase {
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="builder"></param>
		internal PipePullCommandAttributeBuilder(PipePullCommandBuilder builder)
			: base(builder) {
		}

		/// <summary>
		/// Sets any attribute.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public PipePullCommandAttributeBuilder Attribute(XName name, string value) {
			ParameterCheck.ParameterRequired(name, "name");

			Element.SetAttributeValue(name, value);
			return this;
		}

		/// <summary>
		/// Set the id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public PipePullCommandAttributeBuilder Id(string id) {

			Element.SetAttributeValue("ID", id);
			return this;
		}

		/// <summary>
		/// Sets a unique id
		/// </summary>
		/// <returns></returns>
		public PipePullCommandAttributeBuilder UniqueId() {
			return Id(Globals.CreateUniqueId(PipePullCommandBuilder.IdPrefix));
		}
		
		/// <summary>
		/// Add a JDF that will be sent with this submit queue entry.
		/// </summary>
		/// <param name="ticket"></param>
		/// <returns></returns>
		public PipePullCommandAttributeBuilder Ticket(Ticket ticket) {
			ParameterCheck.ParameterRequired(ticket, "ticket");
		
			ParentJmfNode.Message.AssociatedTicket = ticket;
			return this;
		}
	}
}

