using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Geometry.Geometry;

namespace RayTracingLib
{
    public class Sphere : ObjectBase
    {
        public Vec3f Center;
        public float Radius;
        public Material Material;

        public Sphere(Vec3f center, float radius, Material material)
        {
            Center = center;
            Radius = radius;
            Material = material;
        }

        /// <summary>
        /// В какой точке луч пересекает сферу
        /// </summary>
        /// <param name="orig"></param>
        /// <param name="dir"></param>
        /// <param name="t0"></param>
        /// <returns></returns>
        public bool RayIntersect(Vec3f orig, Vec3f dir, ref float t0)
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

        public override bool IsRayIntersect(Vec3f orig, Vec3f dir, ref Vec3f hit, ref Vec3f N, ref Material material)
        {
            var spheresDist = float.MaxValue;

            var disti = 0f;

            if (RayIntersect(orig, dir, ref disti) && disti < spheresDist)
            {
                spheresDist = disti;

                hit = orig + dir * disti;

                N = (hit - Center).Normalize();

                material = Material;
            }
            return spheresDist < 1000;
        }
    }
}
