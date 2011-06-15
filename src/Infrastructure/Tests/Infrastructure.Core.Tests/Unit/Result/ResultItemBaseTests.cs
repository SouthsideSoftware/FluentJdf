using System;
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;
using Infrastructure.Core.Result;
using NUnit.Framework;
using FluentAssertions;

namespace Infrastructure.Core.Tests.Unit.Result
{
    [TestFixture]
    public class ResultItemBaseTests
    {
        [Test]
        public void Constructor_NonZeroCodeAndMessageWithContent_DoesNotThrowException()
        {
            Action act = () => new ResultItemBase(ResultCode.UnexpectedException, "this is a test");
            act.ShouldNotThrow();
        }

        [Test]
        public void Constructor_NonZeroCodeAndMessageWithEmptyContent_ThrowsPreconditionExceptionContainsParameterName()
        {
            Action act = () => new ResultItemBase(ResultCode.UnexpectedException, "");
            act.ShouldThrow<PreconditionException>().And.Message.Contains("message");
        }

        [Test]
        public void Constructor_NonZeroCodeAndMessageWithWhitespaceContent_ThrowsPreconditionExceptionContainsParameterName()
        {
            Action act = () => new ResultItemBase(ResultCode.UnexpectedException, " \t ");
            act.ShouldThrow<PreconditionException>().And.Message.Contains("message");
        }

        [Test]
        public void ToString_Instance_ReturnsExpectedText()
        {
            var item = new ResultItemBase(ResultCode.UnexpectedException, "test message");
            item.ToString().Should().Be("-2 - test message");
        }

        [Test]
        public void Equals_CompareTwoRefsToSameInstance_ReturnsTrue()
        {
            var item = new ResultItemBase(ResultCode.UnexpectedException, "test message");
            var item2 = item;
            item.Equals(item2).Should().BeTrue();
        }

        [Test]
        public void Equals_CompareTwoInstanceSameContents_ReturnsTrue()
        {
            var item = new ResultItemBase(ResultCode.UnexpectedException, "test message");
            var item2 = new ResultItemBase(ResultCode.UnexpectedException, "test message");
            item.Equals(item2).Should().BeTrue();
        }

        [Test]
        public void Equals_CompareTwoInstanceSameContentsWithSameElement_ReturnsTrue()
        {
            var element = new XElement("foo");
            var item = new ResultItemBase(ResultCode.UnexpectedException, "test message", element);
            var item2 = new ResultItemBase(ResultCode.UnexpectedException, "test message", element);
            item.Equals(item2).Should().BeTrue();
        }

        [Test]
        public void Equals_CompareTwoInstanceDifferingResultCodes_ReturnsFalse()
        {
            var item = new ResultItemBase(ResultCode.NoHandlerConfigured, "test message");
            var item2 = new ResultItemBase(ResultCode.UnexpectedException, "test message");
            item.Equals(item2).Should().BeFalse();
        }

        [Test]
        public void Equals_CompareTwoInstanceSameContentsWithDifferingElements_ReturnsFalse()
        {
            var element1 = new XElement("foo");
            var element2 = new XElement("bar");
            var item = new ResultItemBase(ResultCode.UnexpectedException, "test message", element1);
            var item2 = new ResultItemBase(ResultCode.UnexpectedException, "test message", element2);
            item.Equals(item2).Should().BeFalse();
        }

        [Test]
        public void Equals_CompareTwoInstanceSameContentsWithDifferingElementsWithSameName_ReturnsFalse()
        {
            var element1 = new XElement("foo");
            var element2 = new XElement("foo");
            var item = new ResultItemBase(ResultCode.UnexpectedException, "test message", element1);
            var item2 = new ResultItemBase(ResultCode.UnexpectedException, "test message", element2);
            item.Equals(item2).Should().BeFalse();
        }

        [Test]
        public void Equals_CompareTwoInstanceSameContentsWithSameElementsDifferingErrorCodes_ReturnsFalse()
        {
            var element = new XElement("foo");
            var item = new ResultItemBase(ResultCode.RootJdfRequired, "test message", element);
            var item2 = new ResultItemBase(ResultCode.UnexpectedException, "test message", element);
            item.Equals(item2).Should().BeFalse();
        }

        [Test]
        public void Equals_CompareTwoInstanceSameContentsWithOneWithNoElement_ReturnsFalse()
        {
            var element = new XElement("foo");
            var item = new ResultItemBase(ResultCode.UnexpectedException, "test message", element);
            var item2 = new ResultItemBase(ResultCode.UnexpectedException, "test message");
            item.Equals(item2).Should().BeFalse();
        }

        [Test]
        public void Equals_CompareTwoInstanceDifferingMessage_ReturnsFalse()
        {
            var item = new ResultItemBase(ResultCode.UnexpectedException, "test message1");
            var item2 = new ResultItemBase(ResultCode.UnexpectedException, "test message2");
            item.Equals(item2).Should().BeFalse();
        }

        [Test]
        public void Equals_CompareInstanceToNull_ReturnsFalse()
        {
            var item = new ResultItemBase(ResultCode.UnexpectedException, "test message1");
            item.Equals(null).Should().BeFalse();
        }

        [Test]
        public void Constructor_EnumValueLessThanZero_IsErrorType()
        {
            var item = new ResultItemBase(ResultCode.GeneralError, "message");
            item.Type.Should().Be(ResultItemType.Error);
        }

        [Test]
        public void Constructor_EnumValueGreaterThanZero_IsWarningType()
        {
            var item = new ResultItemBase(ResultCode.UnsupportedFeature, "message");
            item.Type.Should().Be(ResultItemType.Warning);
        }


    }
}
