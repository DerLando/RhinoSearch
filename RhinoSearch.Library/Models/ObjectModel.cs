using Rhino.DocObjects;
using Rhino.Geometry;
using RhinoSearch.Library.Calculations;
using System;
using System.Collections.Generic;
using System.Text;

namespace RhinoSearch.Library.Models
{
    public class ObjectModel : ObjectModelBase
    {
        #region private properties

        /// <summary>
        /// Since all properties are calculated on-demand
        /// its better to keep a reference to a base-object
        /// </summary>
        RhinoObject _baseObject;

        #endregion

        public ObjectModel(RhinoObject rhObj)
        {
            _baseObject = rhObj;
        }

        #region public properties

        public override string Name => _baseObject.Name;

        public string Layer => LayerCalculation.CalculateLayerName(_baseObject);
        public double Area => AreaCalculation.CalculateArea(_baseObject);
        public double Volume => VolumeCalculation.CalculateVolume(_baseObject);

        public RhinoObject BaseObject => _baseObject;

        #endregion

        #region property helper methods


        #endregion

    }
}
