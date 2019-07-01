using static Geometry.Geometry;
namespace RayTracingLib
{
    internal interface ISphere
    {
        Vec3f Center { get; set; }
        float Radius { get; set; }
        Material Material { get; set; }
        bool IsRayIntersect(Vec3f orig, Vec3f dir, ref Vec3f hit, ref Vec3f N, ref Material material);
    }
}