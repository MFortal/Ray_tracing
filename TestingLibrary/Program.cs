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

            var material = new Material(1, null, new Geometry.Geometry.Vec3f(255f, 0f, 0f), 1);
            
            var sphere = new Sphere(new Geometry.Geometry.Vec3f(0f, 0, -5), 1.5F, material);
            var light = new Light(new Geometry.Geometry.Vec3f(-20, 20, -5), 1);

            RayTraceHelper.Render(width, height, sphere, Color.White, light).Save("C:/1/1.jpg");


        }
    }
}
