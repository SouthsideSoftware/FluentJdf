using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentJdf.Transmission {

    /// <summary>
    /// Type of folder for this configuration
    /// </summary>
    public enum FolderInfoTypeEnum {
        /// <summary>
        /// A generic attachment (default)
        /// </summary>
        Attachment,
        /// <summary>
        /// JDF
        /// </summary>
        Jdf,
        /// <summary>
        /// JMF
        /// </summary>
        Jmf,
    }
}
