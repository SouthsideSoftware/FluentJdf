using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentJdf.LinqToJdf
{
    /// <summary>
    /// Command names
    /// </summary>
    public static class Command
    {
#pragma warning disable 1591

        public static string SubmitQueueEntry = "SubmitQueueEntry";

#pragma warning restore 1591

        /// <summary>
        /// Gets the xsi type for the command.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static string XsiTypeOfCommand(string command) {
            return string.Format("Command{0}", command);
        }
    }
}
