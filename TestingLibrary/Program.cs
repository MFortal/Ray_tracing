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

            Bitmap backgroundImage = new Bitmap(@"C:/1/back.jpg");

            List<Light> lights = new List<Light>()
            {
                new Light(new Vec3f(0, 15, 100), 2f)
                //new Light( new Vec3f( -30, 50, 0), 1f)
            };

            List<Material> materials = new List<Material>()
            {
               new Material(1, new[] { .9f, .1f, .0f, .0f }, Color.Crimson, 10),
               new Material(1, new[] { .9f, .1f, .0f, .0f }, Color.Yellow, 10),
               new Material(1, new[] { .9f, .1f, .0f, .0f }, Color.Blue, 10)
            };

            List<Sphere> spheres = new List<Sphere>()
            {
                new Sphere(new Vec3f(0f, 0f, -3), .6F, materials[1]),
                new Sphere(new Vec3f(0f, 0f, -2), .08F, materials[2]),
                new Sphere(new Vec3f(-.2f, .2f, -2), .05F, materials[0]),
                new Sphere(new Vec3f(.2f, .2f, -2), .05F, materials[0]),
                //new Sphere(new Vec3f(1f, 0.6f, -4), 0.1F, materials[2])
            };
            RayTraceHelper.Render(width, height, spheres, backgroundImage, lights).Save("C:/1/1.jpg");
        }
    }
}
