using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Jdp.Jdf.LinqToJdf
{
    /// <summary>
    /// Starting point for creating JDF tickets.
    /// </summary>
    public static class Ticket
    {
        /// <summary>
        /// Create a new JDF ticket
        /// </summary>
        /// <returns></returns>
        public static XDocument Create() {
            return new XDocument();
        }
    }
}
