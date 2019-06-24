using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingLib
{
    public class Material
    {
        public float RefIndex;
        public Geometry.Geometry.Vec3f DiffColor;
        public float SpecExp;
        public float[] Albedo;

        public Material(float refIndex, float[] albedo, Geometry.Geometry.Vec3f diffColor, float specExp)
        {
            RefIndex = refIndex;
            Albedo = albedo;
            DiffColor = diffColor;
            SpecExp = specExp;
        }

        public Material()
        {
            RefIndex = 1;
            SpecExp = 0;
            Albedo = new[] { 1f, 0f, 0f, 0f };
            DiffColor = new Geometry.Geometry.Vec3f();
        }
    }
}
