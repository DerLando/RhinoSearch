using Rhino;
using Rhino.DocObjects;
using RhinoSearch.Library.Data;
using RhinoSearch.Library.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RhinoSearch.Library.Models
{
    public class ObjectTable
    {
        public static IEnumerable<RhinoObject> ExecuteQuery(RhinoDoc doc, QueryGroupModel query, ObjectModelType objectType)
        {
            // get typed collections from rhino doc, not all might be needed
            // but because we get them as IEnumerables, the performance cost should be close to none
            var objectModels = GetObjectModels(doc);
            //var blockInstanceModels = GetBlockInstanceModels(doc);
            //var objectGroupModels = GetObjectGroupModels(doc);

            switch (objectType)
            {
                case ObjectModelType.Object:
                    var parameter = ObjectModelType.Object.AsParameterExpression();
                    var expression = query.GetExpression(parameter);
                    var lambda = Expression.Lambda<Func<ObjectModel, bool>>(expression, parameter);
                    var objectQueryFn = lambda.Compile();
                    return objectModels.Where(o => objectQueryFn(o)).Select(o => o.BaseObject);
                case ObjectModelType.Block:
                    break;
                case ObjectModelType.Group:
                    break;
                default:
                    break;
            }

            return null;
        }

        private static IEnumerable<ObjectModel> GetObjectModels(RhinoDoc doc)
        {
            return doc.Objects.Select(o => new ObjectModel(o));
        }

        private static IEnumerable<BlockInstanceModel> GetBlockInstanceModels(RhinoDoc doc)
        {
            throw new NotImplementedException();
        }

        private static IEnumerable<ObjectGroupModel> GetObjectGroupModels(RhinoDoc doc)
        {
            throw new NotImplementedException();
        }
    }
}
