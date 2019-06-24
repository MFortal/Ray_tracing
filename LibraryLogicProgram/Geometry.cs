using System;
using System.Drawing;
using RayTracingLib;
using static Geometry.Geometry;

namespace Geometry
{
    public class Geometry
    {
        public class Vec3f
        {
            public float x;
            public float y;
            public float z;

            public Vec3f(float x, float y, float z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }

            public Vec3f()
            {
            }

            public float this[int i]
            {
                get { return i <= 0 ? x : (i == 1 ? y : z); }
            }

            public float Norm()
            {
                return (float)Math.Sqrt(x * x + y * y + z * z);
            }

            public Vec3f Normalize()
            {
                return this / Norm();
            }

            public float[] ToArray()
            {
                return new[] { x, y, z };
            }

            public static Vec3f operator +(Vec3f self, Vec3f other)
            {
                return new Vec3f(self.x + other.x, self.y + other.y, self.z + other.z);
            }

            public static Vec3f operator -(Vec3f self, Vec3f other)
            {
                return new Vec3f(self.x - other.x, self.y - other.y, self.z - other.z);
            }

            public static float operator *(Vec3f self, Vec3f other)
            {
                return self.x * other.x + self.y * other.y + self.z * other.z;
            }

            public static Vec3f operator *(Vec3f self, float value)
            {
                return new Vec3f(self.x * value, self.y * value, self.z * value);
            }

            public static Vec3f operator /(Vec3f self, float value)
            {
                return self * (1f / value);
            }

            public static Vec3f operator -(Vec3f self)
            {
                return self * -1f;
            }
        }
    }
    public class Sphere
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

        public bool IsSphereIntersect(Vec3f orig, Vec3f dir, Sphere sphere, ref Vec3f hit, ref Vec3f N, ref Material material)
        {
            var spheresDist = float.MaxValue;
            var disti = 0f;

            if (sphere.RayIntersect(orig, dir, ref disti) && disti < spheresDist)
            {
                spheresDist = disti;

                hit = orig + dir * disti;

                N = (hit - sphere.Center).Normalize();

                material = sphere.Material;
            }
            return spheresDist < 1000;
        }
    }
}


