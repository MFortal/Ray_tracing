using System.Drawing;
using static Geometry.Geometry;

namespace RayTracingLib
{
    public class Material : IMaterial
    {
        public float RefIndex { get; set; }
        public Vec3f DiffColor { get; set; }
        public float SpecExp { get; set; }
        public float[] Albedo { get; set; }
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
