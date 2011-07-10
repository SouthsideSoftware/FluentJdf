using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.Utility {

    /// <summary>
    /// Extension methods that may need a new home
    /// </summary>
    public static class XContainerExtensionMethods {

        /// <summary>
        /// Determine if two containers are the same (used for testing for now). Does not check namespace for now
        /// </summary>
        /// <param name="original"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static bool SameNodeStructure(this XElement original, XElement other) {
            ParameterCheck.ParameterRequired(original, "original");
            ParameterCheck.ParameterRequired(other, "other");

            if (original.Name != other.Name) {
                return false;
            }
            
            if (original.Elements().Count() != other.Elements().Count()) {
                return false;
            }

            if (original.Attributes().Count() != other.Attributes().Count()) {
                return false;
            }

            foreach (var origAtt in original.Attributes()) {
                var otherAtt = other.Attribute(origAtt.Name);
                if (otherAtt == null) {
                    return false;
                }
            }

            foreach (var origElement in original.Elements()) {
                var otherElement = other.Element(origElement.Name);
                if (otherElement == null) {
                    return false;
                }
                var equal = SameNodeStructure(origElement, otherElement);
                if (!equal) {
                    return false;
                }
            }

            return true;
        }
    
    }
}
