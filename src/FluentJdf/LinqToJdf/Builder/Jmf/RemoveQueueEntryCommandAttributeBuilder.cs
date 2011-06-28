
using System;
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Build attributes for RemoveQueueEntryCommandBuilder.
	/// </summary>
	public class RemoveQueueEntryCommandAttributeBuilder : JmfAttributeBuilderBase {
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="builder"></param>
		internal RemoveQueueEntryCommandAttributeBuilder(RemoveQueueEntryCommandBuilder builder)
			: base(builder) {
		}

		/// <summary>
		/// Sets any attribute.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public RemoveQueueEntryCommandAttributeBuilder Attribute(XName name, string value) {
			ParameterCheck.ParameterRequired(name, "name");

			Element.SetAttributeValue(name, value);
			return this;
		}

		/// <summary>
		/// Set the id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public RemoveQueueEntryCommandAttributeBuilder Id(string id) {

			Element.SetAttributeValue("ID", id);
			return this;
		}

		/// <summary>
		/// Sets a unique id
		/// </summary>
		/// <returns></returns>
		public RemoveQueueEntryCommandAttributeBuilder UniqueId() {
			return Id(Globals.CreateUniqueId(RemoveQueueEntryCommandBuilder.IdPrefix));
		}
		
		/// <summary>
		/// Add a JDF that will be sent with this submit queue entry.
		/// </summary>
		/// <param name="ticket"></param>
		/// <returns></returns>
		public RemoveQueueEntryCommandAttributeBuilder Ticket(Ticket ticket) {
			ParameterCheck.ParameterRequired(ticket, "ticket");
		
			ParentJmfNode.Message.AssociatedTicket = ticket;
			return this;
		}
	}
}

