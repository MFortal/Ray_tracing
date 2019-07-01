using System;
using static Geometry.Geometry;

namespace RayTracingLib
{
    public class Sphere : ObjectBase, ISphere
    {
        public Vec3f Center { get; set; }
        public float Radius { get; set; }
        public Material Material { get; set; }

        public Sphere(Vec3f center, float radius, Material material)
        {
            Center = center;
            Radius = radius;
            Material = material;
        }

        private bool RayIntersect(Vec3f orig, Vec3f dir, ref float t0)
        {
            var L = Center - orig;

            var tca = L * dir;

            var d2 = L * L - tca * tca;

            if (d2 > Radius * Radius) return false;

            var thc = (float)Math.Sqrt(Radius * Radius - d2);

            t0 = tca - thc;

            var t1 = tca + thc;

            if (t0 < 0) t0 = t1;

            return true;
        }

        public override bool IsRayIntersect(Vec3f orig, Vec3f dir, ref Vec3f hit, ref Vec3f N, ref Material material)
        {
            var spheresDist = float.MaxValue;
            var MaxDist = float.MaxValue;

            var disti = 0f;

            if (RayIntersect(orig, dir, ref disti) && disti < spheresDist)
            {
                spheresDist = disti;

                hit = orig + dir * disti;

                N = (hit - Center).Normalize();

                material = Material;
            }
            return spheresDist < MaxDist;
        }
    }
}
