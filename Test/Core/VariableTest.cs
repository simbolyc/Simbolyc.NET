using System;
using Xunit;

namespace Simbolyc
{
    /// <summary>
    /// Unit tests for <see cref="Variable"/> class.
    /// </summary>
    public sealed class VariableTest
    {
        [Theory]
        [InlineData("x")]
        [InlineData("x1")]
        [InlineData("x_1")]
        [InlineData("?????????????????????????????????????????????????")]
        public void ValidConstruction(string name) => Assert.Equal(name, new Variable(name).Name);

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(" ab")]
        [InlineData("a b")]
        [InlineData("ab ")]
        [InlineData("ab;")]
        [InlineData("a+b")]
        [InlineData("a,b")]
        [InlineData("a, b")]
        [InlineData("0ab")]
        [InlineData("0123")]
        public void InvalidContruction(string name) => Assert.ThrowsAny<ArgumentException>(() => new Variable(name));

        [Fact]
        public void StringConversion() => Assert.Equal("abc", new Variable("abc").ToString());
    }
}
