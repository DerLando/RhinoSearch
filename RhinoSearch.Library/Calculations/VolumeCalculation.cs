using Rhino.DocObjects;
using Rhino.Geometry;
using System;
using System.Collections.Generic;
using System.Text;

namespace RhinoSearch.Library.Calculations
{
    internal static class VolumeCalculation
    {
        internal static double CalculateVolume(RhinoObject rhObj)
        {
            var geo = rhObj.Geometry;

            var vmp = VolumeMassProperties.Compute(new[] { geo });

            // TODO: Check if this trivial implementation actually works
            if (vmp is null) return 0.0;
            else return vmp.Volume;
        }
    }
}
