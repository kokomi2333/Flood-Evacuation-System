using ESRI.ArcGIS.Geometry;

namespace EngineWindowsApplication1
{
    internal interface ISpatialReferenceTransform
    {
        IGeometry Transform2D(IGeometry geometry);
        IPoint TransformPoint(IPoint point);
    }
}