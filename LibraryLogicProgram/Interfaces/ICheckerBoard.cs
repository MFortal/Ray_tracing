namespace RayTracingLib
{
    internal interface ICheckerBoard
    {
        bool IsRayIntersect(Geometry.Geometry.Vec3f orig, Geometry.Geometry.Vec3f dir, ref Geometry.Geometry.Vec3f hit,
            ref Geometry.Geometry.Vec3f N, ref Material material);
    }
}