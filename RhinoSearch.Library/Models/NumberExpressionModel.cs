using RhinoSearch.Library.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace RhinoSearch.Library.Models
{
    public class NumberExpressionModel : GenericExpressionModelBase<double>
    {
        public NumberOperator Operator { get; set; }

        public override Expression GetExpression(ParameterExpression parameter)
        {
            var rhs = this.RhsConstant;
            var property = Expression.PropertyOrField(parameter, PropertyName);

            Expression expression = null;
            switch (Operator)
            {
                case NumberOperator.Less:
                    expression = Expression.LessThan(property, rhs);
                    break;
                case NumberOperator.LessEqual:
                    expression = Expression.LessThanOrEqual(property, rhs);
                    break;
                case NumberOperator.Equal:
                    expression = Expression.Equal(property, rhs);
                    break;
                case NumberOperator.MoreEqual:
                    expression = Expression.GreaterThanOrEqual(property, rhs);
                    break;
                case NumberOperator.More:
                    expression = Expression.GreaterThan(property, rhs);
                    break;
                default:
                    break;
            }

            return expression;
        }
    }
}
