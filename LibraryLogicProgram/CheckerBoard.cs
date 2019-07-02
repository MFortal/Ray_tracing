using System;
using System.Drawing;
using static Geometry.Geometry;

namespace RayTracingLib
{
    public class CheckerBoard : ObjectBase, ICheckerBoard
    {
        public Color Color1 { get; set; }
        public Color Color2 { get; set; }
        public CheckerBoard(Color color1, Color color2)
        {
            this.Color1 = color1;
            this.Color2 = color2;

        }

        public override bool IsRayIntersect(Vec3f orig, Vec3f dir, ref Vec3f hit, ref Vec3f N,
            ref Material material)
        {
            var MaxDisctance = float.MaxValue;
            var checkerboardDist = float.MaxValue;

            if (Math.Abs(dir.y) > 1e-3)
            {
                var d = -(orig.y + 4) / dir.y;
                var pt = orig + dir * d;
                if (d > 0 && Math.Abs(pt.x) < 10 && pt.z < -10 && pt.z > -30 && d < MaxDisctance)
                {
                    checkerboardDist = d;
                    hit = pt;

                    N = new Vec3f(0, 1, 0);

                    var _hitX = (int)(.5 * hit.x + 1000);
                    var _hitZ = (int)(.5 * hit.z);

                    material.DiffColor = ((_hitX + _hitZ) & 1) == 0 ? new Vec3f(Color1.R, Color1.G, Color1.B) : new Vec3f(Color2.R, Color2.G, Color2.B);
                }
            }
            return checkerboardDist < MaxDisctance;
        }
    }
}
