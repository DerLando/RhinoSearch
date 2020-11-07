using RhinoSearch.Library.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace RhinoSearch.Library.Models
{
    public class QueryGroupModel
    {
        //TODO: Need to store object type for each level, as we can have nested queries for
        // blokcs and groups that ask questions about contained objects or blocks
        // so more flexibility is needed
        // problem: the original parameter needs to be passed all the way down the expression tree
        /// <summary>
        /// The expression the query group implements
        /// </summary>
        public ExpressionModelBase Lhs { get; set; }

        /// <summary>
        /// A infinitely nest-able expression chain to compare against
        /// </summary>
        public QueryGroupModel Rhs { get; set; }

        /// <summary>
        /// The logic gate to use between lhs expression and rhs expression
        /// </summary>
        public LogicGate Gate { get; set; } = LogicGate.Or;

        internal Expression GetExpression(ParameterExpression parameter)
        {
            var lhs = Lhs.GetExpression(parameter);
            if (Rhs is null) return lhs;

            var rhs = Rhs.GetExpression(parameter);
            Expression expression = null;

            switch (Gate)
            {
                case LogicGate.And:
                    expression = Expression.And(lhs, rhs);
                    break;
                case LogicGate.Or:
                    expression = Expression.Or(lhs, rhs);
                    break;
                default:
                    break;
            }

            return expression;
        }
    }
}
