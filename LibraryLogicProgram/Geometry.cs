using System;
using System.Drawing;
using Geometry;

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

            public float norm()
            {
                return (float)Math.Sqrt(x * x + y * y + z * z);
            }

            public Vec3f normalize()
            {
                return this / norm();
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
        public Geometry.Vec3f Center;
        public float Radius;
        public Color Color;
        public Material Material;

        public Sphere(Geometry.Vec3f center, float radius, Color color, Material material)
        {
            Center = center;
            Radius = radius;
            Material = material;
        }

        public bool RayIntersect(Geometry.Vec3f orig, Geometry.Vec3f dir, ref float t0)
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

        public bool IsSphereIntersect(Geometry.Vec3f orig, Geometry.Vec3f dir, Sphere sphere, Material material)
        {
            var spheresDist = float.MaxValue;
            var disti = 0f;

            if (sphere.RayIntersect(orig, dir, ref disti) && disti < spheresDist)
            {
                spheresDist = disti;
                material = sphere.Material;
            }
            return spheresDist < 1000;
        }
    }
    public class Light
    {
        public Geometry.Vec3f position;
        public float intensity;

        public Light(Geometry.Vec3f position, float intensity)
        {
            this.position = position;
            this.intensity = intensity;
        }
    }
    public class Material
    {
        public float RefIndex;
        public Geometry.Vec3f DiffColor;
        public float SpecExp;
        public float[] Albedo;

        public Material(float refIndex, float[] albedo, Color diffColor, float specExp)
        {
            RefIndex = refIndex;
            Albedo = albedo;
            DiffColor = new Geometry.Vec3f(diffColor.R, diffColor.G, diffColor.B);
            SpecExp = specExp;
        }

        public Material()
        {
            RefIndex = 1;
            SpecExp = 0;
            Albedo = new[] { 1f, 0f, 0f, 0f };

            DiffColor = new Geometry.Vec3f();
        }
    }
}

 
