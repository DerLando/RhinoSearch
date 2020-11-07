using RhinoSearch.Library.Data;
using RhinoSearch.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace RhinoSearch.Library.Extensions
{
    internal static class EnumExtensions
    {
        internal static Type ToType(this ObjectModelType objectType)
        {
            Type type = null;
            switch (objectType)
            {
                case ObjectModelType.Object:
                    type = typeof(ObjectModel);
                    break;
                case ObjectModelType.Block:
                    type = typeof(BlockInstanceModel);
                    break;
                case ObjectModelType.Group:
                    type = typeof(ObjectGroupModel);
                    break;
                default:
                    break;
            }

            return type;
        }

        internal static ParameterExpression AsParameterExpression(this ObjectModelType objectType)
        {
            return Expression.Parameter(objectType.ToType());
        }
    }
}
