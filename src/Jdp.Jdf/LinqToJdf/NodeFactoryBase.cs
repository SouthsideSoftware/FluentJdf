using System.Xml.Linq;
using Onpoint.Commons.Core.CodeContracts;

namespace Jdp.Jdf.LinqToJdf
{
    /// <summary>
    /// Base class for node factories.
    /// </summary>
    public abstract class NodeFactoryBase
    {
        internal NodeFactoryBase(XContainer initiator)
        {
            ParameterCheck.ParameterRequired(initiator, "initiator");

            if (initiator is XElement) {
                Initiator = initiator as XElement;
            }
        }

        /// <summary>
        /// Gets the Node and allows set for inheritors.
        /// </summary>
        public XElement Node { get; protected set; }

        /// <summary>
        /// Gets the container node from where the action was initiated.
        /// </summary>
        public XElement Initiator { get; protected set; }
    }
}