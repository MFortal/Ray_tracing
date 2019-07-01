namespace RayTracingLib
{
    public interface IObjectBase
    {
       bool IsRayIntersect(Geometry.Geometry.Vec3f orig, Geometry.Geometry.Vec3f dir, ref Geometry.Geometry.Vec3f hit, ref Geometry.Geometry.Vec3f N, ref Material material);
    }
}