using System;
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;
using Infrastructure.Core.Result;
using NUnit.Framework;
using FluentAssertions;

namespace Infrastructure.Core.Tests.Unit.Result
{
    [TestFixture]
    public class ResultBaseTests
    {
        [Test]
        public void Constructor_Default_IsSuccessIsTrue()
        {
            var result = new ResultBase();
            result.IsSuccess.Should().BeTrue();
        }

        [Test]
        public void AddError_AddOne_IsSuccessFalse()
        {
            var result = new ResultBase();
            result.AddMessage(new ResultItemBase(ResultCode.GeneralError, "this is a test"));
            result.IsSuccess.Should().BeFalse();
        }

        [Test]
        public void AddError_AddTwo_HasTwo()
        {
            var result = new ResultBase();
            result.AddMessage(new ResultItemBase(ResultCode.GeneralError, "this is a test"));
            result.AddMessage(new ResultItemBase(ResultCode.UnexpectedException, "this is a test 2"));
            result.Errors.Should().HaveCount(2);
        }

        [Test]
        public void AddError_AddDuplicateWithoutElements_DuplicateIsNotAdded()
        {
            var result = new ResultBase();
            result.AddMessage(new ResultItemBase(ResultCode.GeneralError, "this is a test"));
            result.AddMessage(new ResultItemBase(ResultCode.GeneralError, "this is a test"));
            result.Errors.Should().HaveCount(1);
        }

        [Test]
        public void AddError_AddDuplicateWithElements_DuplicateIsNotAdded()
        {
            var result = new ResultBase();
            var element = new XElement("foo");
            result.AddMessage(new ResultItemBase(ResultCode.GeneralError, "this is a test", element));
            result.AddMessage(new ResultItemBase(ResultCode.GeneralError, "this is a test", element));
            result.Errors.Should().HaveCount(1);
        }

        [Test]
        public void AddError_AddDuplicateCodesAndMessageUniqueElements_IsAdded()
        {
            var result = new ResultBase();
            var element1 = new XElement("foo");
            var element2 = new XElement("bar");
            result.AddMessage(new ResultItemBase(ResultCode.GeneralError, "this is a test", element1));
            result.AddMessage(new ResultItemBase(ResultCode.GeneralError, "this is a test", element2));
            result.Errors.Should().HaveCount(2);
        }

        [Test]
        public void AddError_AddUniqueCodesAndDuplicateMessageDuplicateElements_IsAdded()
        {
            var result = new ResultBase();
            var element = new XElement("foo");
            result.AddMessage(new ResultItemBase(ResultCode.GeneralError, "this is a test", element));
            result.AddMessage(new ResultItemBase(ResultCode.UnexpectedException, "this is a test", element));
            result.Errors.Should().HaveCount(2);
        }

        [Test]
        public void AddWarning_AddOne_IsSuccessTrue()
        {
            var result = new ResultBase();
            result.AddMessage(new ResultItemBase(ResultCode.UnsupportedFeature, "this is a test"));
            result.IsSuccess.Should().BeTrue();
        }

        [Test]
        public void AddWarning_AddTwo_HasTwo()
        {
            var result = new ResultBase();
            result.AddMessage(new ResultItemBase(ResultCode.UnsupportedFeature, "this is a test"));
            result.AddMessage(new ResultItemBase(ResultCode.NoHandlerConfigured, "this is a test 2"));
            result.Warnings.Should().HaveCount(2);
        }

        [Test]
        public void ToString_TwoWarnings_HasBoth()
        {
            var result = new ResultBase();
            result.AddMessage(new ResultItemBase(ResultCode.UnsupportedFeature, "this is a test"));
            result.AddMessage(new ResultItemBase(ResultCode.UnsupportedProcess, "this is a test 2"));
            var stringResult = result.ToString();
            stringResult.Should().Contain("this is a test");
            stringResult.Should().Contain("this is a test 2");
        }

        [Test]
        public void AddWarning_AddDuplicate_DuplicateIsNotAdded()
        {
            var result = new ResultBase();
            result.AddMessage(new ResultItemBase(ResultCode.UnsupportedFeature, "this is a test"));
            result.AddMessage(new ResultItemBase(ResultCode.UnsupportedFeature, "this is a test"));
            result.Warnings.Should().HaveCount(1);
        }

        [Test]
        public void AddMessage_PassNull_ThrowsPreconditionException()
        {
            var result = new ResultBase();
            Action act = () => result.AddMessage(null);
            act.ShouldThrow<PreconditionException>().And.Message.Contains("message");
        }

        [Test]
        public void AddErrors_PassNull_ThrowsPreconditionException()
        {
            var result = new ResultBase();
            Action act = () => result.AddMessage(null);
            act.ShouldThrow<PreconditionException>().And.Message.Contains("errors");
        }

        [Test]
        public void AddWarnings_PassTwo_HasTwo()
        {
            var result = new ResultBase();
            var warnings = new System.Collections.Generic.List<ResultItemBase>
                           {
                               new ResultItemBase(ResultCode.UnsupportedFeature, "test2"),
                               new ResultItemBase(ResultCode.NoHandlerConfigured, "test")
                           };
            result.AddMessages(warnings);
            result.Warnings.Should().HaveCount(2);
        }

        [Test]
        public void AddWarnings_PassTwoTheSame_HasOne()
        {
            var result = new ResultBase();
            var warnings = new System.Collections.Generic.List<ResultItemBase>
                           {
                               new ResultItemBase(ResultCode.UnsupportedFeature, "test"),
                               new ResultItemBase(ResultCode.UnsupportedFeature, "test")
                           };
            result.AddMessages(warnings);
            result.Warnings.Should().HaveCount(1);
        }

        [Test]
        public void AddWarnings_PassTwoOneInCollectionDuplicated_HasTwo()
        {
            var result = new ResultBase();
            result.AddMessage(new ResultItemBase(ResultCode.UnsupportedFeature, "test"));
            var warnings = new System.Collections.Generic.List<ResultItemBase>
                           {
                               new ResultItemBase(ResultCode.NoHandlerConfigured, "test2"),
                               new ResultItemBase(ResultCode.UnsupportedFeature, "test")
                           };
            result.AddMessages(warnings);
            result.Warnings.Should().HaveCount(2);
        }


        [Test]
        public void AddErrors_PassTwo_HasTwo()
        {
            var result = new ResultBase();
            var errors = new System.Collections.Generic.List<ResultItemBase>
                           {
                               new ResultItemBase(ResultCode.UnexpectedException, "test2"),
                               new ResultItemBase(ResultCode.GeneralError, "test")
                           };
            result.AddMessages(errors);
            result.Errors.Should().HaveCount(2);
        }

        [Test]
        public void AddErrors_PassTwoTheSame_HasOne()
        {
            var result = new ResultBase();
            var errors = new System.Collections.Generic.List<ResultItemBase>
                           {
                               new ResultItemBase(ResultCode.UnexpectedException, "test"),
                               new ResultItemBase(ResultCode.UnexpectedException, "test")
                           };
            result.AddMessages(errors);
            result.Errors.Should().HaveCount(1);
        }

        [Test]
        public void AddErrors_PassTwoOneInCollectionDuplicated_HasTwo()
        {
            var result = new ResultBase();
            result.AddMessage(new ResultItemBase(ResultCode.UnexpectedException, "test"));
            var errors = new System.Collections.Generic.List<ResultItemBase>
                           {
                               new ResultItemBase(ResultCode.GeneralError, "test2"),
                               new ResultItemBase(ResultCode.UnexpectedException, "test")
                           };
            result.AddMessages(errors);
            result.Errors.Should().HaveCount(2);
        }

        [Test]
        public void AppendResult_AppendResultWithTwoWarnings_HasTwo()
        {
            var result = new ResultBase();
            var otherResult = new ResultBase();
            var warnings = new System.Collections.Generic.List<ResultItemBase>
                           {
                               new ResultItemBase(ResultCode.UnsupportedFeature, "test2"),
                               new ResultItemBase(ResultCode.NoHandlerConfigured, "test")
                           };
            otherResult.AddMessages(warnings);
            result.AppendResult(otherResult);
            result.Warnings.Should().HaveCount(2);
        }

        [Test]
        public void AppendResult_AppendResultWithTwoWarningsTwoResultWithOneWarning_HasThree()
        {
            var result = new ResultBase();
            result.AddMessage(new ResultItemBase(ResultCode.RequiredAttributeNotFilled, "arghhhhh"));

            var otherResult = new ResultBase();
            var warnings = new System.Collections.Generic.List<ResultItemBase>
                           {
                               new ResultItemBase(ResultCode.UnsupportedFeature, "test2"),
                               new ResultItemBase(ResultCode.NoHandlerConfigured, "test")
                           };
            otherResult.AddMessages(warnings);
            result.AppendResult(otherResult);
            result.Warnings.Should().HaveCount(3);
        }

        [Test]
        public void AppendResult_AppendResultWithTwoErrors_HasTwo()
        {
            var result = new ResultBase();
            var otherResult = new ResultBase();
            var errors = new System.Collections.Generic.List<ResultItemBase>
                           {
                               new ResultItemBase(ResultCode.UnexpectedException, "test2"),
                               new ResultItemBase(ResultCode.GeneralError, "test")
                           };
            otherResult.AddMessages(errors);
            result.AppendResult(otherResult);
            result.Errors.Should().HaveCount(2);
        }

        [Test]
        public void AppendResult_AppendResultWithTwoErrorsTwoResultWithOneError_HasThree()
        {
            var result = new ResultBase();
            result.AddMessage(new ResultItemBase(ResultCode.RootJdfRequired, "arghhhhh"));

            var otherResult = new ResultBase();
            var errors = new System.Collections.Generic.List<ResultItemBase>
                           {
                               new ResultItemBase(ResultCode.UnexpectedException, "test2"),
                               new ResultItemBase(ResultCode.GeneralError, "test")
                           };
            otherResult.AddMessages(errors);
            result.AppendResult(otherResult);
            result.Errors.Should().HaveCount(3);
        }

        [Test]
        public void AddMessageCodeAndStringSignature_PassingData_CreateResultItemBaseInMessages()
        {
            var result = new ResultBase();
            result.AddMessage(ResultCode.UnexpectedException, "this is the message");
            result.IsSuccess.Should().BeFalse();
            result.Errors.Should().HaveCount(1);
        }

        [Test]
        public void ToString_TwoMessages_HasCorrectData()
        {
            var result = new ResultBase();
            result.AddMessage(ResultCode.UnexpectedException, "this is the error");
            result.AddMessage(ResultCode.GeneralWarning, "this is the warning");
            result.ToString().Should().Be("IsSuccess = False Messages: -2 - this is the error, 1 - this is the warning");
        }

        [Test]
        public void ToStringWithLineBreaks_TwoMessages_HasCorrectData()
        {
            var result = new ResultBase();
            result.AddMessage(ResultCode.UnexpectedException, "this is the error");
            result.AddMessage(ResultCode.GeneralWarning, "this is the warning");
            result.ToStringWithLineBreaks().Should().Be("IsSuccess = False Messages:\n-2 - this is the error\n1 - this is the warning");
        }

        [Test]
        public void AddMessageFormat_FormatStringAddMarms_FormatsTheMessage()
        {
            var result = new ResultBase();
            result.AddMessageFormat(ResultCode.UnexpectedException, "This {0} a {1}", "is", "test");
            result.Messages[0].Message.Should().Be("This is a test");
        }
    }
}
