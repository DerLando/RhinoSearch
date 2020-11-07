using Rhino.DocObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace RhinoSearch.Library.Calculations
{
    internal static class LayerCalculation
    {
        private static Layer GetLayer(RhinoObject rhObj)
        {
            var doc = rhObj.Document;
            return doc.Layers.FindIndex(rhObj.Attributes.LayerIndex);
        }

        internal static string CalculateLayerName(RhinoObject rhObj)
        {
            return GetLayer(rhObj).Name;
        }
    }
}
