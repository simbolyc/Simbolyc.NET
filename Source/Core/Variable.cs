using System;

namespace Simbolyc
{
    /// <summary>
    /// An immutable symbolic variable.
    /// </summary>
    public sealed class Variable : Expression
    {
        private const string NUMBERS = @"0123456789";
        private const string INVALID = " +-*/,.;`~!@#$%^&()=:\\\"'";


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
        /// <exception cref="ArgumentException">If name is empty or has invalid characters</exception>
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

            if (NUMBERS.IndexOf(name[0]) >= 0)
            {
                throw new ArgumentException("Name starts with a number");
            }

            if (name.IndexOfAny(INVALID.ToCharArray()) >= 0)
            {
                throw new ArgumentException("Name contains invalid character");
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
