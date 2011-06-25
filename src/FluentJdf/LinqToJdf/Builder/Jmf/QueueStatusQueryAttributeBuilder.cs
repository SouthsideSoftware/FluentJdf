using System;
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
    /// <summary>
    /// Build attributes for QueueStatusQueryBuilder.
    /// </summary>
    public class QueueStatusQueryAttributeBuilder : JmfAttributeBuilderBase {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="builder"></param>
        internal QueueStatusQueryAttributeBuilder(QueueStatusQueryBuilder builder) : base(builder) {
        }

        /// <summary>
        /// Set the id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public QueueStatusQueryAttributeBuilder Id(string id)
        {

            ParentJmfNode.Element.SetAttributeValue("ID", id);
            return this;
        }

        /// <summary>
        /// Sets a unique id
        /// </summary>
        /// <returns></returns>
        public QueueStatusQueryAttributeBuilder UniqueId()
        {
            return Id(Globals.CreateUniqueId(QueueStatusQueryBuilder.IdPrefix));
        }
    }
}