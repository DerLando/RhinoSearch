using RhinoSearch.Library.Data;
using RhinoSearch.Library.Extensions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace RhinoSearch.Library.Models
{
    public abstract class ExpressionModelBase
    {
        /// <summary>
        /// The name of the property to call
        /// </summary>
        public string PropertyName { get; set; } = "";

        /// <summary>
        /// The type of object to execute the query on
        /// </summary>
        //public ObjectModelType ObjectType { get; set; } = ObjectModelType.Object;

        /// <summary>
        /// derived classes need to define a way to build an expression
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public abstract Expression GetExpression(ParameterExpression parameter);

    }
}
