using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace FluentJdf.LinqToJdf
{
    /// <summary>
    /// 
    /// </summary>
    public static class JdfDifferenceExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool JdfDifference(this XElement actual, XElement expected, IJdfDifferenceListener listener = null)
        {
            var difference = new Difference(listener);
            difference.CompareElement(actual, expected);
            return difference.Result;
        }

        private class Difference
        {
            private readonly IJdfDifferenceListener _listener;
            public bool Result { get; private set; }

            public Difference(IJdfDifferenceListener listener)
            {
                _listener = listener;
            }

            public void CompareElement(XElement actual, XElement expected)
            {
                CompareNames(actual, expected);
                CompareAttributes(actual, expected);
                CompareElements(actual.Elements(), expected.Elements());
            }

            private void CompareNames(XElement actual, XElement expected)
            {
                if (actual.Name != expected.Name)
                {
                    Notify(l => l.ElementNameDifference(string.Format("Element name {0} is different from {1}", actual.Name, expected.Name)));
                }

            }

            private void CompareAttributes(XElement actualElement, XElement expectedElement)
            {
                var actualAttributes = new List<XAttribute>(actualElement.Attributes());
                var expectedAttributes = new List<XAttribute>(expectedElement.Attributes());
                for (int i1 = actualAttributes.Count - 1; i1 >= 0; i1--)
                {
                    for (int i2 = expectedAttributes.Count - 1; i2 >= 0; i2--)
                    {
                        if (actualAttributes[i1].Name == expectedAttributes[i2].Name)
                        {
                            if (actualAttributes[i1].Value != expectedAttributes[i2].Value)
                            {
                                var message = string.Format("Attribute '{0}' actual value '{1}' expected value '{2}'",
                                        actualAttributes[i1].LocalAttributeXPath(), actualAttributes[i1].Value, expectedAttributes[i2].Value);
                                Notify(l => l.DifferentAttributes(message));
                            }
                            actualAttributes.RemoveAt(i1);
                            expectedAttributes.RemoveAt(i2);
                            break;
                        }
                    }
                }

                foreach (var attribute in actualAttributes)
                {
                    var message = string.Format("Attribute '{0}' is only in the actual tree", attribute.LocalAttributeXPath());
                    Notify(l => l.DifferentAttributes(message));
                }

                foreach (var attribute in expectedAttributes)
                {
                    var message = string.Format("Attribute '{0}' is only in the expected tree", attribute.LocalAttributeXPath());
                    Notify(l => l.DifferentAttributes(message));
                }
            }

            private void CompareElements(IEnumerable<XElement> actualElements, IEnumerable<XElement> expectedElements)
            {
                var actualList = new List<XElement>(actualElements);
                var expectedList = new List<XElement>(expectedElements);

                for (int i1 = actualList.Count - 1; i1 >= 0; i1--)
                {
                    for (int i2 = expectedList.Count - 1; i2 >= 0; i2--)
                    {
                        if (actualList[i1].Name != expectedList[i2].Name) continue;
                        CompareElement(actualList[i1], expectedList[i2]);
                        actualList.RemoveAt(i1);
                        expectedList.RemoveAt(i2);
                        break;
                    }
                }

                foreach (var element in actualList)
                {
                    var message = string.Format("Element '{0}' is only in the actual tree", element.LocalElementXPath());
                    Notify(l => l.DifferentElements(message));
                }

                foreach (var element in expectedList)
                {
                    var message = string.Format("Element '{0}' is only in the expected tree", element.LocalElementXPath());
                    Notify(l => l.DifferentElements(message));
                }
            }

            private void Notify(Action<IJdfDifferenceListener> action)
            {
                if (_listener != null) action(_listener);
                Result = true;
            }
        }
    }
}
