using ESRI.ArcGIS.Geometry;

namespace EngineWindowsApplication1
{
    internal interface ISpatialReferenceTransformFactory
    {
        ISpatialReferenceTransform CreateTransform(ISpatialReference sourceSrs, ISpatialReference targetSrs);
    }
}