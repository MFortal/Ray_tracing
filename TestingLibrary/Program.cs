using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using Geometry;
using RayTracingLib;
using static Geometry.Geometry;


namespace TestingApp
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Vec3f> verts = new List<Vec3f>();
            foreach (var line in File.ReadAllLines("C:/1/cube.obj"))
            {
                if (line.StartsWith("v "))
                {
                    var currentVerts = line.Replace(".",",").Split(' ');
                    verts.Add(new Vec3f(float.Parse(currentVerts[1]),
                        float.Parse(currentVerts[2]),
                        float.Parse(currentVerts[3])
                        ));
                }
            }

            int width = 1024;
            int height = 768;

            var backgroundImage = new Bitmap(@"C:/1/back.jpg");
            
            List<Light> lights = new List<Light>()
            {
                new Light(new Vec3f(-20, 20,  20), 1.5f),
                new Light(new Vec3f( 30, 50, -25), 1.8f),
                new Light( new Vec3f(30, 20, 30), 1.7f)
            };
            
            List<Material> materials = new List<Material>()
            { 
                //little specular
                new Material(1, new[] { .6f, .3f, .0f, .0f }, Color.DarkSlateBlue, 150),
               //mirror-bubble
               new Material(1f, new[] {0, 10, .8f, 0}, Color.Brown, 1425),
               //rubber
               new Material(1, new[] { .9f, .1f, .0f, .0f }, Color.DarkSlateGray, 10),
               //glass
               new Material(1.5f, new[] {0,  .5f, .1f, .8f}, Color.Yellow, 125)
            };

            List<ObjectBase> objects = new List<ObjectBase>()
            {
                new Sphere(new Vec3f(-3, 0, -16), 2, materials[0]),
                new Sphere(new Vec3f(4f, -1.5f, -12), 2F, materials[3]),
                new Sphere(new Vec3f(1.5f, -0.5f, -18), 3F, materials[2]),
                new Sphere(new Vec3f(7,    5,   -18), 4F, materials[1]),
                new CheckerBoard(),
            };

            RayTraceHelper.Render(width, height, objects, backgroundImage, lights).Save("C:/1/1.jpg");



          
        }
    }
}