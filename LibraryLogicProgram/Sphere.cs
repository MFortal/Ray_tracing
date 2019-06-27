using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingLib
{
    public class Sphere : ObjectBase
    {
        public Geometry.Geometry.Vec3f Center;
        public float Radius;
        public Material Material;

        public Sphere(Geometry.Geometry.Vec3f center, float radius, Material material)
        {
            Center = center;
            Radius = radius;
            Material = material;
        }

        public bool RayIntersect(Geometry.Geometry.Vec3f orig, Geometry.Geometry.Vec3f dir, ref float t0)
        {
            var L = Center - orig;

            var tca = L * dir;

            var d2 = L * L - tca * tca;

            if (d2 > Radius * Radius) return false;

            var thc = (float)Math.Sqrt(Radius * Radius - d2);

            t0 = tca - thc;

            var t1 = tca + thc;

            if (t0 < 0) t0 = t1;

            if (t0 < 0) return false;

            return true;
        }

        public override bool IsRayIntersect(Geometry.Geometry.Vec3f orig, Geometry.Geometry.Vec3f dir, ref Geometry.Geometry.Vec3f hit, ref Geometry.Geometry.Vec3f N, ref Material material)
        {
            var spheresDist = float.MaxValue;
            var checkerboardDist = float.MaxValue;


            var disti = 0f;

            if (RayIntersect(orig, dir, ref disti) && disti < spheresDist)
            {
                spheresDist = disti;

                hit = orig + dir * disti;

                N = (hit - Center).Normalize();

                material = Material;
            }

            return Math.Min(spheresDist, checkerboardDist) < 1000;
        }
    }
}
