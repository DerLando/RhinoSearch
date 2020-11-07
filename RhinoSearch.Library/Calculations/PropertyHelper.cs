using RhinoSearch.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RhinoSearch.Library.Calculations
{
    public static class PropertyHelper
    {
        /// <summary>
        /// An enumeration of all property names of <see cref="ObjectModel"/> together with their return types
        /// </summary>
        public static IEnumerable<string> ObjectModelPropertyNames = GetPropertyNames<ObjectModel>();

        /// <summary>
        /// An enumeration of all property names of <see cref="BlockInstanceModel"/> together with their return types
        /// </summary>
        public static IEnumerable<string> BlockInstanceModelPropertyNames = GetPropertyNames<BlockInstanceModel>();
        
        /// <summary>
        /// An enumeration of all property names of <see cref="ObjectGroupModel"/> together with their return types
        /// </summary>
        public static IEnumerable<string> ObjectGroupModelPropertyNames = GetPropertyNames<ObjectGroupModel>();

        private static IEnumerable<PropertyInfo> GetPublicProperties<T>() where T: class
        {
            return typeof(T)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }

        //private static IEnumerable<(string, Type)> GetPropertyTypes<T>() where T: class {
        //    var infos = GetPublicProperties<T>();
        //    return infos.Select(i => (i.Name, i.PropertyType));
        //}

        private static IEnumerable<string> GetPropertyNames<T>() where T: class
        {
            return GetPublicProperties<T>()
                .Select(pi => pi.Name);
        }
    }
}
