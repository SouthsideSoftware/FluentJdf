using System.IO;
using Machine.Specifications;

namespace Infrastructure.Testing {
    /// <summary>
    /// Extension methods and helpers
    /// </summary>
    public static class ExtensionMethodsAndHelpers {

        public static bool SameBytes(this Stream one, Stream two) {

            if (one.Length != two.Length) {
                throw new SpecificationException(string.Format("Should be same length but is {0} at byte {1}", one.Length, two.Length));
            }

            int byteCount = 0;

            while (true) {
                int oneByte = one.ReadByte();
                if (oneByte == -1) {
                    break;
                }
                int twoByte = two.ReadByte();
                if (oneByte != twoByte) {
                    throw new SpecificationException(string.Format("Should be {0} but is {1} at byte {2}", oneByte, twoByte, byteCount));
                }
                byteCount++;
            }
            return true;
        }
    }
}
