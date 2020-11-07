using Rhino.DocObjects;
using Rhino.Geometry;
using System;
using System.Collections.Generic;
using System.Text;

namespace RhinoSearch.Library.Calculations
{
    /// <summary>
    /// Static helper class to help handling of area calculations
    /// </summary>
    internal static class AreaCalculation
    {
        /// <summary>
        /// Tries to calculate the Area for a given <see cref="RhinoObject"/>
        /// by casting to known geometry types that an Area can be calculated for
        /// </summary>
        /// <param name="rhObj"></param>
        /// <returns>The calculated area on success, 0.0 on failure</returns>
        internal static double CalculateArea(RhinoObject rhObj)
        {
            var geo = rhObj.Geometry;

            if (geo.ObjectType == ObjectType.Curve)
            {
                var crv = geo as Curve;
                if (crv is null) return 0.0;
                if (!crv.IsClosed | !crv.IsPlanar()) return 0.0;

                return AreaMassProperties.Compute(crv).Area;
            }

            if (geo.ObjectType == ObjectType.Brep)
            {
                var brep = geo as Brep;
                return AreaMassProperties.Compute(brep).Area;
            }

            if (geo.ObjectType == ObjectType.Mesh)
            {
                var mesh = geo as Mesh;
                return AreaMassProperties.Compute(mesh).Area;
            }

            if (geo.ObjectType == ObjectType.Surface)
            {
                var srf = geo as Surface;
                return AreaMassProperties.Compute(srf).Area;
            }

            return 0.0;
        }
    }
}
