using System;
using Xunit;

namespace Simbolyc
{
    /// <summary>
    /// Unit tests for <see cref="Variable"/> class.
    /// </summary>
    public sealed class VariableTest
    {
        [Fact]
        public void ValidConstruction()
        {
            Variable x = new Variable("x");
            Assert.Equal("x", x.Name);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(" ab")]
        [InlineData("a b")]
        [InlineData("ab ")]
        public void InvalidContruction(string name)
        {
            // Assert exception
            ArgumentException e = Assert.ThrowsAny<ArgumentException>(() => new Variable(name));

            // Assert excepton has a valid message
            Assert.False(string.IsNullOrWhiteSpace(e.Message));
        }

        [Fact]
        public void StringConversion()
        {
            Variable abc = new Variable("abc");
            Assert.Equal("abc", abc.ToString());
        }
    }
}
