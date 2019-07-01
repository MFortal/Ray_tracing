using static Geometry.Geometry;

namespace RayTracingLib
{
    public class ObjectBase : IObjectBase
    {
        public virtual bool IsRayIntersect(Vec3f orig, Vec3f dir, ref Vec3f hit, ref Vec3f N,
               ref Material material)
        {
            return false;
        }
    }
}
