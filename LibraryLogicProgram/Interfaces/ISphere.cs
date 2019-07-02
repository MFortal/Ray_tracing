using static Geometry.Geometry;
namespace RayTracingLib
{
    internal interface ISphere
    {
        Vec3f Center { get; set; }
        float Radius { get; set; }
        Material Material { get; set; }
    }
}