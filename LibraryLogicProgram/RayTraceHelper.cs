using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using Geometry;
using static Geometry.Geometry;


namespace RayTracingLib
{
    public class RayTraceHelper
    {
        public static Bitmap Render(int width, int height, List<Sphere> spheres, Bitmap background, List<Light> lights)
        {
            var fov = (float)(Math.PI / 3f);

            var framebuffer = new Color[width * height];

            for (var j = 0; j < height; j++)
            {
                for (var i = 0; i < width; i++)
                {
                    var dirx = i + .5f - width / 2f;

                    var diry = -(j + .5f) + height / 2f;

                    var dirz = -height / (2f * (float)Math.Tan(fov / 2f));

                    var vcam = new Vec3f(0, 0, 0);

                    var vdir = new Vec3f(dirx, diry, dirz).Normalize();

                    var backgroundPixel = background.GetPixel(i, j);

                    framebuffer[i + j * width] = CastRay(vcam, vdir, spheres, backgroundPixel, lights);
                }
            }
            return CreateImage(width, height, framebuffer);
        }

        /// <summary>
        /// Цвет пикселя
        /// </summary>
        /// <param name="orig"></param>
        /// <param name="dir"></param>
        /// <param name="sphere"></param>
        /// <returns></returns>
        private static Color CastRay(Vec3f orig, Vec3f dir, List<Sphere> spheres, Color background, List<Light> lights)
        {
            var n = new Vec3f();
            var point = new Vec3f();
            var material = new Material();
            var result = new Vec3f();

            if (!Sphere.IsSphereIntersect(orig, dir, spheres, ref point, ref n, ref material))
            {
                return background;
            }

            var diffuseLightIntensity = 0f;
            foreach (var light in lights)
            {
                var lightDir = (light.position - point).Normalize();

                var lightDistance = (light.position - point).Norm();

                diffuseLightIntensity += light.intensity * Math.Max(0, lightDir * n);
            }

            result = material.DiffColor * diffuseLightIntensity * material.Albedo[0];

            if (result.x > 255) result.x = 255;
            if (result.y > 255) result.y = 255;
            if (result.z > 255) result.z = 255;

            return Color.FromArgb(255, (int)(result.x), (int)(result.y), (int)(result.z));
        }

        public static Bitmap CreateImage(int width, int height, Color[] imageData)
        {

            byte[] data = new byte[width * height * 4];
            int l = 0;
            for (int i = 0; i < imageData.Length; i++)
            {
                data[l++] = imageData[i].B;
                data[l++] = imageData[i].G;
                data[l++] = imageData[i].R;
                data[l++] = 255;
            }
            unsafe
            {
                fixed (byte* ptr = data)
                {
                    return new Bitmap(width, height, width * 4, PixelFormat.Format32bppArgb, new IntPtr(ptr));
                }
            }
        }
    }
}
