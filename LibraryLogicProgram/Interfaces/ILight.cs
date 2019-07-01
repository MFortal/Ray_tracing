using static Geometry.Geometry;
namespace RayTracingLib
{
    public interface ILight
    {
        Vec3f position { get; set; }
        float intensity { get; set; }
    }
}