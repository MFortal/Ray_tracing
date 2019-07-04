using System.Drawing;

namespace RayTracingLib
{
    internal interface ICheckerBoard
    {
        Geometry.Geometry.Vec3f Color1 { get; set; }
        Geometry.Geometry.Vec3f Color2 { get; set; }
    }
}