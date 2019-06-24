using System;
using System.Collections.Generic;
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

            Bitmap backgroundImage = new Bitmap(@"C:/1/3.jpg");

            var light = new Light(new Vec3f(-20, 20, 20), 1);

            List<Material> materials = new List<Material>()
            {
               new Material(1, new[] { .9f, .1f, .0f, .0f }, Color.Azure, 10),
               new Material(1, new[] { .9f, .1f, .0f, .0f }, Color.Blue, 10)
            };

            List<Sphere> spheres = new List<Sphere>()
            {
                new Sphere(new Vec3f(0f, 0, -5), 1.5F, materials[0]),
                new Sphere(new Vec3f(1f, 1, -10), 1.5F, materials[1])
            };

            RayTraceHelper.Render(width, height, spheres, backgroundImage, light).Save("C:/1/1.jpg");
        }
    }
}
