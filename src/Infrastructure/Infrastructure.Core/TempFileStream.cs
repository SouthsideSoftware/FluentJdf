using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Infrastructure.Core
{
    /// <summary>
    /// A stream backed by a temp file that will be deleted on close.
    /// </summary>
    public class TempFileStream : FileStream {
        /// <summary>
        /// Gets and sets the buffer size.  Default is 8kb (same as .NET framework uses for all file streams)
        /// </summary>
        public static int BufferSize = 8192;
        /// <summary>
        /// Constructor.
        /// </summary>
        public TempFileStream()
            : base(Path.GetTempFileName(), FileMode.Create, FileAccess.ReadWrite, FileShare.Read, BufferSize, FileOptions.DeleteOnClose) { }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="access"></param>
        public TempFileStream(FileAccess access)
            : base(Path.GetTempFileName(), FileMode.Create, access, FileShare.Read, BufferSize, FileOptions.DeleteOnClose) { }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="access"></param>
        /// <param name="share"></param>
        public TempFileStream(FileAccess access, FileShare share)
            : base(Path.GetTempFileName(), FileMode.Create, access, share, BufferSize, FileOptions.DeleteOnClose) { }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="access"></param>
        /// <param name="share"></param>
        /// <param name="bufferSize"></param>
        public TempFileStream(FileAccess access, FileShare share, int bufferSize)
            : base(Path.GetTempFileName(), FileMode.Create, access, share, bufferSize, FileOptions.DeleteOnClose) { }
    }
}
