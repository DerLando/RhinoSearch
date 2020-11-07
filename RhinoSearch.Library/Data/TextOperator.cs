using System;
using System.Collections.Generic;
using System.Text;

namespace RhinoSearch.Library.Data
{
    /// <summary>
    /// The possible text operations
    /// </summary>
    public enum TextOperator
    {
        /// <summary>
        /// Test if a substring is contained, case insensitive
        /// </summary>
        Contains,

        /// <summary>
        /// Test if two pieces of text are equal, case insensitive
        /// </summary>
        Equals,
    }
}
