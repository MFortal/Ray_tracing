using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Geometry.Geometry;

namespace RayTracingLib
{
    public class Cube : ObjectBase
    {
        public List<Vec3f> verts = new List<Vec3f>();
        public List<Vec3f> faces = new List<Vec3f>();
        public Cube(string filename)
        {
            foreach (var line in File.ReadAllLines(filename))
            {
                if (line.StartsWith("v "))
                {
                    var currentVerts = line.Replace(".", ",").Split(' ');
                    verts.Add(new Vec3f(float.Parse(currentVerts[1]),
                        float.Parse(currentVerts[2]) ,
                        float.Parse(currentVerts[3])
                    ));
                }
                if (line.StartsWith("f "))
                {
                    var currentFaces = line.Split(' ');
                    faces.Add(new Vec3f(float.Parse(currentFaces[1].Split('/').First()),
                        float.Parse(currentFaces[2].Split('/').First()),
                        float.Parse(currentFaces[3].Split('/').First())
                    ));
                }
            }
        }

        public override bool IsRayIntersect(Vec3f orig, Vec3f dir, ref Vec3f hit, ref Vec3f N, ref Material material, Vec3f v0, Vec3f v1, Vec3f v2)
        {
            var MaxDisctance = float.MaxValue;
            var e1 = v1 - v0;
            var e2 = v2 - v0;

            //вычисление вектора нормали
            var pvec = Vec3f.Cross(dir, e2);
            var det = e1 * pvec;

            //Луч параллелен плкоскости
            if (det > -1e-8 && det < 1e-8) return false;

            var inv_det = 1 / det;
            var tvec = orig - v0;
            var u = tvec * pvec * inv_det;
            if (u < 0 || u > 1) return false;

            var qvec = Vec3f.Cross(tvec, e1);
            var v = dir * qvec * inv_det;
            if (v < 0 || u + v > 1) return false;

            N = new Vec3f(0, 1, 0);

            material.DiffColor = new Vec3f(0, 0, 255);

            return e2 * qvec * inv_det < MaxDisctance;
        }
    }
}


