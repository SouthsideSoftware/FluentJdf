using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentJdf.LinqToJdf;
using System.Xml.Linq;

namespace FluentJdf.Transmission {
    /// <summary>
    /// Provides methods for converting old URLs in file specs to new URLs based on some rule.
    /// </summary>
    public class FileSpecUrlMangler {

        /// <summary>
        /// Given a HybridDictionary of mappings between old and new URLs, converts the URL
        /// in every FileSpec in the JdfTree to the appropriate new URL.
        /// </summary>
        /// <param name="ticket">The Ticket to process</param>
        /// <param name="urlMapping">A IDictionary keyed by existing URLs mapping to new System.Uri</param>
        /// <param name="mustMapCIDs">If <i>true</i> throws an exception if an existing URL starts with CID and
        /// no mapping has been provided for that CID.</param>
        /// <exception cref="JdfException">Thrown if mustMapCIDs is true and no mapping was supplied for a CID-based URL.</exception>
        public static void MapFileSpecUrls(Ticket ticket, IDictionary<string, string> urlMapping, bool mustMapCIDs) {

            var fileSpecs = ticket.Root.SelectJDFDescendants(Element.FileSpec);

            foreach (var fileSpec in fileSpecs) {
                var urlValue = fileSpec.GetAttributeValueOrNull("URL");
                if (urlValue != null) {
                    string newUrl = urlMapping.FirstOrDefault(item => item.Key.Equals(urlValue, StringComparison.OrdinalIgnoreCase)).Value;
                    if (newUrl != null) {
                        fileSpec.AddOrReplaceAttribute(new XAttribute("URL", (new Uri(newUrl)).AbsoluteUri));
                    }
                    else {
                        if (urlValue.StartsWith("cid:", StringComparison.OrdinalIgnoreCase) && mustMapCIDs) {
                            throw new JdfException("mustMapCIDs is true and no mapping supplied for URL: " + urlValue);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Given an IDictionary of mappings between old and new URLs, converts the URL
        /// in every Preview in the JdfTree to the appropriate new URL.
        /// </summary>
        /// <param name="ticket">The Ticket to process</param>
        /// <param name="urlMapping">A IDictionary keyed by existing URLs mapping to new System.Uri</param>
        /// <param name="mustMapCIDs">If <i>true</i> throws an exception if an existing URL starts with CID and
        /// no mapping has been provided for that CID.</param>
        /// <exception cref="JdfException">Thrown if mustMapCIDs is true and no mapping was supplied for a CID-based URL.</exception>
        public static void MapPreviewUrls(Ticket ticket, IDictionary<string, string> urlMapping, bool mustMapCIDs) {

            var previews = ticket.Root.SelectJDFDescendants(Element.Preview);

            foreach (var preview in previews) {
                var urlValue = preview.GetAttributeValueOrNull("URL");
                if (urlValue != null) {
                    string newUrl = urlMapping.FirstOrDefault(item => item.Key.Equals(urlValue, StringComparison.OrdinalIgnoreCase)).Value;
                    if (newUrl != null) {
                        preview.AddOrReplaceAttribute(new XAttribute("URL", (new Uri(newUrl)).AbsoluteUri));
                    }
                    else {
                        if (urlValue.StartsWith("cid:", StringComparison.OrdinalIgnoreCase) && mustMapCIDs) {
                            throw new JdfException("mustMapCIDs is true and no mapping supplied for URL: " + urlValue);
                        }
                    }
                }
            }
        }
    }
}
