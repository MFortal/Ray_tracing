using System;
using System.Drawing;
using System.Drawing.Imaging;
using Geometry;


namespace RayTracingLib
{
    public class RayTraceHelper
    {
        public static Bitmap Render(int width, int height, Sphere sphere, Color background, Light light)
        {
            var fov = (float)(Math.PI / 3f);

            var framebuffer = new Color[width * height];

            // actual rendering loop
            for (var j = 0; j < height; j++)
            {
                for (var i = 0; i < width; i++)
                {
                    // this flips the image at the same time
                    var dirx = i + .5f - width / 2f;

                    var diry = -(j + .5f) + height / 2f;

                    var dirz = -height / (2f * (float)Math.Tan(fov / 2f));

                    var vcam = new Geometry.Geometry.Vec3f(0, 0, 0);

                    var vdir = new Geometry.Geometry.Vec3f(dirx, diry, dirz).normalize();

                    framebuffer[i + j * width] = CastRay(vcam, vdir, sphere, background, sphere.Material, light);
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
        private static Color CastRay(Geometry.Geometry.Vec3f orig, Geometry.Geometry.Vec3f dir, Sphere sphere, Color background, Material material, Light light)
        {
            var N = new Geometry.Geometry.Vec3f();

            if (!sphere.IsSphereIntersect(orig, dir, sphere, material))
            {
                return background;
            }

            var diffuseLightIntensity = 2f;
            var lightDir = (light.position - N).normalize();
            diffuseLightIntensity += light.intensity * Math.Max(0, lightDir * N);

            var lightresult = material.DiffColor;

            sphere.Color = Color.FromArgb(255,(int)(lightresult.x), (int)(lightresult.y), (int)(lightresult.z));

            return sphere.Color;
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
