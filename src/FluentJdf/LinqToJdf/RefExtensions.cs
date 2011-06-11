using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace FluentJdf.LinqToJdf
{
    /// <summary>
    /// Modifies documents containing ref elements
    /// </summary>
    public static class RefExtensions
    {
        /// <summary>
        /// Make inline copies of all referenced elements.
        /// This allows simple XPath expressions to find the referenced elements.
        /// e.g. When DigitalPrintingParams contains a MediaRef with rRef='x,
        /// 'DigitalPrintingParamas/Media will find the Media element with ID='x'
        /// 
        /// The inline copy is identified with attribute normalize='x' so it can be removed later.
        /// A second copy named xxxx_Original is also made so that changes can be detected and
        /// applied to the referenced element when the copy is removed.
        /// </summary>
        /// <param name="source"></param>
        public static void DenormalizeRefElements(this XContainer source)
        {
            foreach (var reference in source.Descendants().Where(e => e.Name.LocalName.EndsWith("Ref") && e.Attribute("rRef") != null))
            {
                var id = reference.GetAttributeValueOrNull("rRef");
                if (id == null) continue;
                var target = source.Descendants().FirstOrDefault(e => e.GetAttributeValueOrEmpty("ID") == id);
                if (target == null) continue;
                var parent = reference.Parent;
                if (parent == null) continue;
                var targetCopy = new XElement(target);
                targetCopy.SetAttributeValue("normalizeID", id);
                targetCopy.SetAttributeValue("ID", null);
                parent.Add(targetCopy);
                var targetOriginal = new XElement(targetCopy);
                targetOriginal.Name = targetOriginal.Name + "_Original";
                parent.Add(targetOriginal);
            }
        }

        /// <summary>
        /// Remove all inline copies of referenced elements, applying changes made in the copy
        /// to the referenced element.
        /// </summary>
        /// <param name="source"></param>
        public static void RenormalizeRefElements(this XContainer source)
        {
            var copies = new List<XElement>(source.Descendants().Where(e => e.Attribute("normalizeID") != null && !e.Name.LocalName.EndsWith("_Original")));
            var originalCopies = new List<XElement>(source.Descendants().Where(e => e.Attribute("normalizeID") != null && e.Name.LocalName.EndsWith("_Original")));
            foreach (var copy in copies)
            {
                var id = copy.GetAttributeValueOrNull("normalizeID");
                var originalCopy = originalCopies.Find(e => e.GetAttributeValueOrEmpty("normalizeID") == id);
                originalCopy.Name = copy.Name;
                if (originalCopy.JdfDifference(copy))
                {
                    var original = source.Descendants().First(e => e.GetAttributeValueOrEmpty("ID") == id);
                    copy.SetAttributeValue("normalizeID", null);
                    copy.SetAttributeValue("ID", id);
                    original.ReplaceAttributes(copy.Attributes().Where(a => a.Name.LocalName != "normalizeID"));
                }
                copy.Remove();
                originalCopy.Remove();
            }
        }
    }
}
