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

            var material = new Material(1, new[] { .9f, .1f, .0f, .0f }, Color.Black, 10);
            var sphere = new Sphere(new Geometry.Geometry.Vec3f(0f, 0, -5), 1.5F, Color.Black, material);
            var light = new Light(new Geometry.Geometry.Vec3f(-20, 20, 20), 1);

            RayTraceHelper.Render(width, height, sphere, Color.White, light).Save("C:/1/1.jpg");


        }
    }
}
