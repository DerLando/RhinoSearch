using System;
using System.Collections.Generic;
using System.Text;

namespace RhinoSearch.Library.Data
{
    /// <summary>
    /// Base enum for all operations, man c# sucks for this :/
    /// </summary>
    public enum LogicOparator
    {
        /// <summary>
        /// Test if a substring is contained, case insensitive
        /// </summary>
        Contains,

        /// <summary>
        /// Test if two pieces of text are equal, case insensitive
        /// </summary>
        Equals,

        Less,
        LessEqual,
        Equal,
        MoreEqual,
        More
    }
}
