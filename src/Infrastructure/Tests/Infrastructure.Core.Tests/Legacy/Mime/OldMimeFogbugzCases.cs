using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Infrastructure.Testing;
using NUnit.Framework;
using FluentAssertions;

namespace Infrastructure.Core.Tests.Legacy.Mime
{
    /// <summary>
    /// These are tests taken from the old fogbugz case tests
    /// in JDP.  Test names explain the original case as 
    /// best as could be reconstructed.
    /// </summary>
    [TestFixture]
    public class OldMimeFogbugzCases
    {
        [Test]
        public void mime_with_whitespace_before_boundary_works_properly() {
            var mm = new Core.Mime.Mime(TestDataHelper.Instance.PathToTestFile("Case16992.mim"));
            Assert.IsTrue(mm.Boundary == "__=_Part_Boundary_928390645_338731487", "Boundary can be parsed");
            Assert.IsTrue(mm.HasParts, "The mime has parts");
            Assert.IsTrue(mm.NumParts == 1, "There is exactly one part");
            Assert.IsTrue(mm.GetPart(0).GetText().StartsWith("<?xml version=\"1.0\" encoding=\"UTF-8\"?>"), "Part starts with correct text");

            var tree = XDocument.Parse(mm.GetPart(0).GetText());
            tree.Root.Name.LocalName.Should().Be("JMF");
        }
    }
}
