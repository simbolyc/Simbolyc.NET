using System.Collections.Generic;
using System.Collections.Immutable;

namespace Simbolyc
{
    /// <summary>
    /// A mathematical function.
    /// A function transforms a list of expressions into another expression.
    /// </summary>
    public interface Function : Expression
    {
        /// <summary>
        /// Gets the arguments of the function.
        /// </summary>
        IReadOnlyList<Expression> Arguments { get; }
    }


    /// <summary>
    /// An abstract immutable function.
    /// </summary>
    public abstract class AbstractFunction : Function
    {
        /// <summary>
        /// Gets the arguments of the function.
        /// </summary>
        public IReadOnlyList<Expression> Arguments { get; }

        /// <summary>
        /// Returns the string representation of the function.
        /// </summary>
        /// <returns>String representation</returns>
        public override string ToString() => GetType().Name + "(" + string.Join(", ", Arguments) + ")";


        #region Constructors

        /// <summary>
        /// Private constructor to assign <see cref="Arguments"/>.
        /// </summary>
        /// <param name="arguments">Reference to argument list</param>
        private AbstractFunction(IReadOnlyList<Expression> arguments)
        {
            // ImmutableArray(struct) is boxed when assigned to IReadOnlyList(interface)
            Arguments = arguments;
        }

        /// <summary>
        /// Creates a function with no arguments.
        /// </summary>
        protected AbstractFunction() : this(ImmutableArray.Create<Expression>()) { }

        /// <summary>
        /// Creates a function with a single argument.
        /// </summary>
        /// <param name="argument">Function argument</param>
        protected AbstractFunction(Expression argument) : this(ImmutableArray.Create(argument)) { }

        /// <summary>
        /// Creates a function with two arguments.
        /// </summary>
        /// <param name="first">First function argument</param>
        /// <param name="second">Second function argument</param>
        protected AbstractFunction(Expression first, Expression second)
            : this(ImmutableArray.Create(first, second)) { }

        /// <summary>
        /// Creates a function with three arguments.
        /// </summary>
        /// <param name="first">First function argument</param>
        /// <param name="second">Second function argument</param>
        /// <param name="third">Third function argument</param>
        protected AbstractFunction(Expression first, Expression second, Expression third)
            : this(ImmutableArray.Create(first, second, third)) { }

        /// <summary>
        /// Creates a function with four arguments.
        /// </summary>
        /// <param name="first">First function argument</param>
        /// <param name="second">Second function argument</param>
        /// <param name="third">Third function argument</param>
        /// <param name="fourth">Fourth function argument</param>
        protected AbstractFunction(Expression first, Expression second, Expression third, Expression fourth)
           : this(ImmutableArray.Create(first, second, third, fourth)) { }

        /// <summary>
        /// Creates a function from a sequence of arguments.
        /// </summary>
        /// <param name="arguments">Sequence of arguments</param>
        protected AbstractFunction(IEnumerable<Expression> arguments) : this(arguments.ToImmutableArray()) { }

        #endregion
    }
}
