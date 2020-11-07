using RhinoSearch.Library.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace RhinoSearch.Library.Models
{
    public class TextExpressionModel : GenericExpressionModelBase<string>
    {
        public TextOperator Operator { get; set; }

        public override Expression GetExpression(ParameterExpression parameter)
        {
            var rhs = this.RhsConstant;
            var property = Expression.PropertyOrField(parameter, PropertyName);

            Expression expression = null;
            switch (Operator)
            {
                case TextOperator.Contains:
                    expression = Expression.Call(property, typeof(string).GetMethod(nameof(string.Contains)), rhs);
                    break;
                case TextOperator.Equals:
                    expression = Expression.Equal(property, rhs);
                    break;
                default:
                    break;
            }

            return expression;
        }
    }
}
