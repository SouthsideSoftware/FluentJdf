using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace FluentJdf.LinqToJdf {
    
    /// <summary>
    /// Helper class designed to ensure we always return the document to a non normalized state
    /// for things like xPath navigation.
    /// </summary>
    public class RefExtensionsNormalizer : IDisposable {

        /// <summary>
        /// The <see cref="XContainer"/> that is being normalized
        /// </summary>
        public XContainer Node {
            get;
            private set;
        }

        /// <summary>
        /// Create a new instance and normalize the container.
        /// </summary>
        /// <param name="container">the container we wish to normalize</param>
        public RefExtensionsNormalizer(XContainer container) {
            this.Node = container;
            RefExtensions.DenormalizeRefElements(this.Node);
        }
        
        /// <summary>
        /// Cleanup the Denormalization
        /// </summary>
        public void Dispose() {
            RefExtensions.RenormalizeRefElements(this.Node);
        }
    }
}
