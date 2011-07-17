//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace FluentJdf.Transmission {
//    /// <summary>
//    /// Provides methods for converting old URLs in file specs to new URLs based on some rule.
//    /// </summary>
//    public class FileSpecUrlMangler {

//        /// <summary>
//        /// Given a HybridDictionary of mappings between old and new URLs, converts the URL
//        /// in every FileSpec in the JdfTree to the appropriate new URL.
//        /// </summary>
//        /// <param name="jdfTree">The JdfTree to process</param>
//        /// <param name="urlMapping">A HybridDictionary keyed by existing URLs mapping to new System.Uri</param>
//        /// <param name="mustMapCIDs">If <i>true</i> throws an exception if an existing URL starts with CID and
//        /// no mapping has been provided for that CID.</param>
//        /// <exception cref="NoUrlMappingException">Thrown if mustMapCIDs is true and no mapping was supplied for a CID-based URL.</exception>
//        public static void MapFileSpecUrls(JdfTree jdfTree, IDictionary<string,string> urlMapping, bool mustMapCIDs) {
//            ElementList fileSpecs = jdfTree.Root.GetElementsByName("FileSpec");

//            foreach (Element fileSpec in fileSpecs) {
//                //HACK: CIP4 messed up the case of CID so I'm ToLower()ing everything.
//                if (fileSpec.Attributes.IsAttributeNonNull("URL")) {
//                    string oldUrl = fileSpec.Attributes["URL"].ToString().ToLower();
//                    if (urlMapping.Contains(oldUrl)) {
//                        jdp.jdf.Attribute urlAttribute = fileSpec.Attributes["URL"];
//                        urlAttribute.SetValue(((Uri)urlMapping[oldUrl]).AbsoluteUri);
//                    }
//                    else {
//                        if (oldUrl.ToLower().StartsWith("cid:") && mustMapCIDs) {
//                            OAIException.Throw(new NoUrlMappingException("mustMapCIDs is true and no mapping supplied for URL " + oldUrl));
//                        }
//                    }
//                }
//            }
//        }

//        /// <summary>
//        /// Given a HybridDictionary of mappings between old and new URLs, converts the URL
//        /// in every Preview in the JdfTree to the appropriate new URL.
//        /// </summary>
//        /// <param name="jdfTree">The JdfTree to process</param>
//        /// <param name="urlMapping">A HybridDictionary keyed by existing URLs mapping to new System.Uri</param>
//        /// <param name="mustMapCIDs">If <i>true</i> throws an exception if an existing URL starts with CID and
//        /// no mapping has been provided for that CID.</param>
//        /// <exception cref="NoUrlMappingException">Thrown if mustMapCIDs is true and no mapping was supplied for a CID-based URL.</exception>
//        public static void MapPreviewUrls(JdfTree jdfTree, IDictionary<string, string> urlMapping, bool mustMapCIDs) {
//            ElementList previews = jdfTree.Root.GetElementsByName("Preview");

//            foreach (Element preview in previews) {
//                if (preview.Attributes.IsAttributeNonNull("URL")) {
//                    string oldUrl = preview.Attributes["URL"].ToString().ToLower();
//                    if (urlMapping.Contains(oldUrl)) {
//                        jdp.jdf.Attribute urlAttribute = preview.Attributes["URL"];
//                        urlAttribute.SetValue(((Uri)urlMapping[oldUrl]).AbsoluteUri);
//                    }
//                    else {
//                        if (oldUrl.ToLower().StartsWith("cid:") && mustMapCIDs) {
//                            OAIException.Throw(new NoUrlMappingException("mustMapCIDs is true and no mapping supplied for URL " + oldUrl));
//                        }
//                    }
//                }
//            }
//        }
//    }
//}
