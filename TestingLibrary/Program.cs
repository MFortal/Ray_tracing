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

            var backgroundImage = new Bitmap(@"C:/1/back1.jpg");

            List<Light> lights = new List<Light>()
            {
                new Light(new Vec3f(-20, 20,  20), 1.5f),
                new Light(new Vec3f( 30, 50, -25), 1.8f),
                new Light( new Vec3f(30, 20, 30), 1.7f)
        };

            List<Material> materials = new List<Material>()
            {
               new Material(1, new[] { .9f, .1f, .0f, .0f }, Color.Bisque, 10),
               new Material(1.5f, new[] {0.0f,  0.5f, 0.1f, 0.8f}, Color.Blue, 1425),
               new Material(1, new[] { .9f, .1f, .0f, .0f }, Color.Aquamarine, 10)
            };

            List<Sphere> spheres = new List<Sphere>()
            {
                new Sphere(new Vec3f(-3,    0,   -16), 2, materials[2]),
                new Sphere(new Vec3f(-1.0f, -1.5f, -12), 2F, materials[1]),
                new Sphere(new Vec3f(1.5f, -0.5f, -18), 3F, materials[0]),
                new Sphere(new Vec3f(7,    5,   -18), 4F, materials[0])
            };
            RayTraceHelper.Render(width, height, spheres, backgroundImage, lights).Save("C:/1/1.jpg");
        }
    }
}
