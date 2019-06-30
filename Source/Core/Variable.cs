using System;

namespace Simbolyc
{
    /// <summary>
    /// An immutable symbolic variable.
    /// </summary>
    public sealed class Variable : Expression
    {
        /// <summary>
        /// Gets the name of the variable.
        /// </summary>
        /// <value>Variable name</value>
        public string Name { get; }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="name">Variable name</param>
        /// <exception cref="ArgumentNullException">If name is null</exception>
        /// <exception cref="ArgumentException">If name is empty or has whitespace</exception>
        public Variable(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (name.Length == 0)
            {
                throw new ArgumentException("Name is empty.");
            }

            if (name.Contains(" "))
            {
                throw new ArgumentException("Name contains whitespace.");
            }

            // Assign to property
            Name = name;
        }

        /// <summary>
        /// Returns the variable <see cref="Name"/>.
        /// </summary>
        /// <returns>Variable name</returns>
        public override string ToString() => Name;
    }
}
