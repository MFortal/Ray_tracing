using System;
using System.Drawing;
using Geometry;
using RayTracingLib;


namespace TestingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = 1024;
            int height = 768;

            //var gR = Color.BlueViolet.R;
            //var gG = Color.BlueViolet.G;
            //var gB = Color.BlueViolet.B;

            var sphere = new Sphere(new Geometry.Geometry.Vec3f(0f, 1, -10), 1, Color.DarkKhaki);

            RayTraceHelper.Render(width, height, sphere, Color.DarkOliveGreen).Save("C:/1/1.jpg");

        }
    }
}
