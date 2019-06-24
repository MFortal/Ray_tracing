using System;
using System.Collections.Generic;
using System.Drawing;
using static Geometry.Geometry;

namespace RayTracingLib
{
    public class Material
    {
        public float RefIndex;
        public Vec3f DiffColor;
        public float SpecExp;
        public float[] Albedo;

        public Material(float refIndex, float[] albedo, Color diffColor, float specExp)
        {
            RefIndex = refIndex;
            Albedo = albedo;
            DiffColor = new Vec3f(diffColor.R, diffColor.G, diffColor.B);
            SpecExp = specExp;
        }

        public Material()
        {
            RefIndex = 1;
            SpecExp = 0;
            Albedo = new[] { 1f, 0f, 0f, 0f };
            DiffColor = new Vec3f();
        }
    }
}
