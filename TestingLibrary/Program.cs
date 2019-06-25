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
                new Light(new Vec3f(20, 15, 100), 2f),
                new Light( new Vec3f( -30, 50, 0), 1f)
            };

            List<Material> materials = new List<Material>()
            {
               new Material(1, new[] { .9f, .1f, .0f, .0f }, Color.Bisque, 10),
               new Material(1, new[] { 0f, 10f, .8f, .0f }, Color.Black, 1425),
               new Material(1, new[] { .9f, .1f, .0f, .0f }, Color.Aquamarine, 10)
            };

            List<Sphere> spheres = new List<Sphere>()
            {
                new Sphere(new Vec3f(0f, -.3f, -3), .8F, materials[1]),
                new Sphere(new Vec3f(-.2f, -.3f, -2), .08F, materials[2]),
                new Sphere(new Vec3f(-.2f, -.1f, -2), .05F, materials[0]),
                new Sphere(new Vec3f(.2f, 0f, -2), .1F, materials[0])
            };
            RayTraceHelper.Render(width, height, spheres, backgroundImage, lights).Save("C:/1/1.jpg");
        }
    }
}
