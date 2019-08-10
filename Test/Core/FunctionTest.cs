using Xunit;
using System.Linq;
using System.Collections.Generic;

namespace Simbolyc
{
    /// <summary>
    /// Unit tests for <see cref="AbstractFunction"/> class.
    /// </summary>
    public sealed class FunctionTest
    {
        /// <summary>
        /// Test implementation of <see cref="AbstractFunction"/>.
        /// </summary>
        private class TestFunction : AbstractFunction
        {
            public TestFunction() : base() { }

            public TestFunction(Expression argument) : base(argument) { }

            public TestFunction(Expression first, Expression second)
                : base(first, second) { }

            public TestFunction(Expression first, Expression second, Expression third)
                : base(first, second, third) { }

            public TestFunction(Expression first, Expression second, Expression third, Expression fourth)
                : base(first, second, third, fourth) { }

            public TestFunction(IEnumerable<Expression> arguments) : base(arguments) { }
        }

        [Fact]
        public void Nullivariate() => Assert.Empty(new TestFunction().Arguments);

        [Fact]
        public void Univariate()
        {
            Variable x = new Variable("x");
            Function func = new TestFunction(x);

            Assert.Single(func.Arguments, x);
            Assert.Same(x, func.Arguments[0]);
        }

        [Fact]
        public void Bivariate()
        {
            Variable x = new Variable("x");
            Variable y = new Variable("y");
            Function func = new TestFunction(x, y);

            Assert.Equal(2, func.Arguments.Count);
            Assert.Same(x, func.Arguments[0]);
            Assert.Same(y, func.Arguments[1]);
        }

        [Fact]
        public void Trivariate()
        {
            Variable x = new Variable("x");
            Variable y = new Variable("y");
            Variable z = new Variable("z");
            Function func = new TestFunction(x, y, z);

            Assert.Equal(3, func.Arguments.Count);
            Assert.Same(x, func.Arguments[0]);
            Assert.Same(y, func.Arguments[1]);
            Assert.Same(z, func.Arguments[2]);
        }

        [Fact]
        public void Quadivariate()
        {
            Variable x = new Variable("x");
            Variable y = new Variable("y");
            Variable z = new Variable("z");
            Variable t = new Variable("t");
            Function func = new TestFunction(x, y, z, t);

            Assert.Equal(4, func.Arguments.Count);
            Assert.Same(x, func.Arguments[0]);
            Assert.Same(y, func.Arguments[1]);
            Assert.Same(z, func.Arguments[2]);
            Assert.Same(t, func.Arguments[3]);
        }

        [Fact]
        public void MultivariateArray()
        {
            Variable[] args = Enumerable.Repeat(new Variable("x"), 100).ToArray();
            Function func = new TestFunction(args);

            Assert.NotSame(args, func.Arguments);
            Assert.Equal(args, func.Arguments);
        }

        [Fact]
        public void MultivariateList()
        {
            List<Variable> args = Enumerable.Repeat(new Variable("x"), 100).ToList();
            Function func = new TestFunction(args);

            Assert.NotSame(args, func.Arguments);
            Assert.Equal(args, func.Arguments);
        }

        [Fact]
        public void ImmutableArguments()
        {
            Variable x = new Variable("x");
            Variable y = new Variable("y");
            Variable z = new Variable("z");

            Variable[] args = new Variable[] { x, y };
            Function func = new TestFunction(args);
            args[0] = z; // Modify input array

            Assert.Same(x, func.Arguments[0]);
            Assert.Same(y, func.Arguments[1]);
        }

        [Fact]
        public void StringConversion()
        {
            Function func = new TestFunction(new Variable("x"), new Variable("y"));
            string expected = "TestFunction(x, y)";
            Assert.Equal(expected, func.ToString());
        }
    }
}
