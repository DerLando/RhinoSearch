using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhinoSearch.Library.Data
{
    /// <summary>
    /// The possible Object types to query for
    /// </summary>
    public enum ObjectModelType
    {
        /// <summary>
        /// A <see cref="Rhino.DocObjects.RhinoObject"/>
        /// </summary>
        Object,

        /// <summary>
        /// A <see cref="Rhino.DocObjects.InstanceObject"/>
        /// </summary>
        Block,

        /// <summary>
        /// A <see cref="Rhino.DocObjects.Group"/>
        /// </summary>
        Group
    }
}
