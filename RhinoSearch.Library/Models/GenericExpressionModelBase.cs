using RhinoSearch.Library.Extensions;
using RhinoSearch.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace RhinoSearch.Library.Data
{
    /// <summary>
    /// A logical query container
    /// </summary>
    public abstract class GenericExpressionModelBase<T> : ExpressionModelBase
    {
        /// <summary>
        /// The right-hand-side value to compare against
        /// </summary>
        public T Rhs { get; set; }

        /// <summary>
        /// The type the property returns, when executed
        /// </summary>
        protected Type PropertyType => typeof(T);

        #region helper methods for expression generation

        protected Expression RhsConstant => Expression.Constant(Rhs);

        #endregion
    }
}
