using System;
using System.Threading;

namespace FluentJdf.Utility {
    /// <summary>
    /// Used to generate unique ids.
    /// </summary>
    public class UniqueGenerator {
        static int sequence;

        /// <summary>
        /// Function used to make a unique id from a GUID.
        /// </summary>
        public static Func<string> MakeUnique = MakeUniqueFromGuid;

        /// <summary>
        /// Resets the sequence used for generating pure integer unique ids.
        /// </summary>
        public static void Reset() {
            Interlocked.Exchange(ref sequence, 0);
        }

        /// <summary>
        /// Create a unique string from the first 5 of a guid.
        /// </summary>
        public static string MakeUniqueFromGuid() {
            return Guid.NewGuid().ToString().Truncate(5);
        }

        /// <summary>
        /// Returns the next unique integer id.
        /// </summary>
        public static string MakeUniqueFromSequence() {
            return Interlocked.Increment(ref sequence).ToString();
        }
    }
}