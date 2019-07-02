using static Geometry.Geometry;
namespace Geometry
{
    public interface IGeometry
    {
        float x { get; set; }
        float y { get; set; }
        float z { get; set; }

        float Norm();
        Vec3f Normalize();
    }
}