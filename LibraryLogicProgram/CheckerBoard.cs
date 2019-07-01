﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Geometry.Geometry;

namespace RayTracingLib
{
    public class CheckerBoard : ObjectBase, ICheckerBoard
    {
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

                    material.DiffColor = ((_hitX + _hitZ) & 1) == 0 ? new Vec3f(255f, 255f, 255f) : new Vec3f(0f, 0f, 0f);
                }
            }
            return checkerboardDist < MaxDisctance;
        }
    }
}
