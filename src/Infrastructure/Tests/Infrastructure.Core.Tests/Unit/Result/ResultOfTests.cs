using FluentAssertions;
using Infrastructure.Core.Result;
using NUnit.Framework;

namespace Infrastructure.Core.Tests.Unit.Result
{
    [TestFixture] public class ResultOfTests
    {
        [Test]
        public void HasValue_WhenValueProvided_IsTrue()
        {
            new ResultOf<string>("stuff").HasValue.Should().BeTrue();
        }

        [Test]
        public void HasValue_WhenNoValueProvided_IsFalse()
        {
            new ResultOf<string>().HasValue.Should().BeFalse();
        }

        [Test]
        public void HasValue_WhenValueProvidedAndHasError_IsTrue()
        {
            var messages = new ResultBase();
            messages.AddMessage(new ResultItemBase(ResultCode.UnexpectedException, "bad"));
            new ResultOf<string>("Stuff", messages).HasValue.Should().BeTrue();
        }

        [Test]
        public void HasValue_WhenValueProvidedAndHasWarning_IsTrue()
        {
            var messages = new ResultBase();
            messages.AddMessage(new ResultItemBase(ResultCode.RequiredAttributeNotFilled, "warning"));
            new ResultOf<string>("Stuff", messages).HasValue.Should().BeTrue();
        }
    }
}
