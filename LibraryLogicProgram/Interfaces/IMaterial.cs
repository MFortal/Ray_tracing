using static Geometry.Geometry;
namespace RayTracingLib
{
    public interface IMaterial
    {
        float RefIndex { get; set; }
        Vec3f DiffColor { get; set; }
        float SpecExp { get; set; }
        float[] Albedo { get; set; }
    }
}