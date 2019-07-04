using System;
using System.Drawing;
using static Geometry.Geometry;

namespace RayTracingLib
{
    public class CheckerBoard : ObjectBase, ICheckerBoard
    {
        public Vec3f Color1 { get; set; }
        public Vec3f Color2 { get; set; }
        public CheckerBoard(Color color1, Color color2)
        {
            this.Color1.x = color1.R;
            this.Color1.y = color1.G;
            this.Color1.z = color1.B;
            this.Color2.x = color2.R;
            this.Color2.y = color2.G;
            this.Color2.z = color2.B;
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

                    material.DiffColor = ((_hitX + _hitZ) & 1) == 0 ? Color1 : Color2;
                }
            }
            return checkerboardDist < MaxDisctance;
        }
    }
}
