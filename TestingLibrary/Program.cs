using System;
using System.Drawing;
using Geometry;
using RayTracingLib;
using static Geometry.Geometry;


namespace TestingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = 1024;
            int height = 768;

            var material = new Material(1, new[] { .9f, .1f, .0f, .0f }, Color.BlueViolet, 10);
            var sphere = new Sphere(new Vec3f(0f, 0, -5), 1.5F, material);
            var light = new Light(new Vec3f(-20, 20, 20), 1);

            RayTraceHelper.Render(width, height, sphere, Color.White, light).Save("C:/1/1.jpg");


        }
    }
}
