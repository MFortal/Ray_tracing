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
        //public Bitmap RayTraceHelper(RayTracerRequest  request)
        //{

        //};

        public static Bitmap Render(int width, int height, List<IObjectBase> objects, Bitmap background, List<Light> lights)
        {
            return CalculateBitmap(width, height, objects, background, lights);
        }

        private static Bitmap CalculateBitmap(int width, int height, List<IObjectBase> objects, Bitmap background, List<Light> lights)
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

                    framebuffer[i + j * width] = CastRay(vcam, vdir, objects, backgroundPixel, lights);
                }
            }
            return CreateImage(width, height, framebuffer);
        }


        /// <summary>
        /// Определение цвета пикселя
        /// </summary>
        /// <param name="orig"></param>
        /// <param name="dir"></param>
        /// <param name="objects"></param>
        /// <param name="background"></param>
        /// <param name="lights"></param>
        /// <param name="depth">Глубина рекурсии</param>
        /// <returns></returns>
        private static Color CastRay(Vec3f orig, Vec3f dir, List<IObjectBase> objects, Color background, List<Light> lights, int depth = 0)
        {
            foreach (var _object in objects)
            {
                var n = new Vec3f();
                var point = new Vec3f();
                var material = new Material();
                var result = new Vec3f();
                var boolVar = false;

                if (depth < 4 && _object.IsRayIntersect(orig, dir, ref point, ref n, ref material))
                {

                    var reflectDir = Reflect(dir, n).Normalize();
                    var refractDir = Refract(dir, n, material.RefIndex).Normalize();

                    var reflectOrig = reflectDir * n < 0 ? point - n * 1e-3f : point + n * 1e-3f;
                    var refractOrig = refractDir * n < 0 ? point - n * 1e-3f : point + n * 1e-3f;

                    var reflectColor = CastRay(reflectOrig, reflectDir, objects, background, lights, depth + 1);
                    var refractColor = CastRay(refractOrig, refractDir, objects, background, lights, depth + 1);

                    var reflectVec = new Vec3f(reflectColor.R, reflectColor.G, reflectColor.B);
                    var refractVec = new Vec3f(refractColor.R, refractColor.G, refractColor.B);

                    var diffuseLightIntensity = 0f;
                    var specularLightIntensity = 0f;

                    foreach (var light in lights)
                    {
                        var lightDir = (light.position - point).Normalize();

                        var lightDistance = (light.position - point).Norm();

                        var shadow_orig = lightDir * n < 0 ? point - n * 1e-3f : point + n * 1e-3f;

                        var shadow_pt = new Vec3f();

                        var shadow_N = new Vec3f();

                        var tmpmaterial = new Material();

                        if (_object.IsRayIntersect(shadow_orig, lightDir, ref shadow_pt, ref shadow_N, ref tmpmaterial) && (shadow_pt - shadow_orig).Norm() < lightDistance)
                            continue;

                        diffuseLightIntensity += light.intensity * Math.Max(0f, lightDir * n);
                        specularLightIntensity += (float)Math.Pow(Math.Max(0d, -Reflect(-lightDir, n) * dir), material.SpecExp);
                    }

                    result = material.DiffColor * diffuseLightIntensity * material.Albedo[0] + new Vec3f(255, 255, 255) * specularLightIntensity * material.Albedo[1] + reflectVec * material.Albedo[2] + refractVec * material.Albedo[3];

                    if (result.x > 255) result.x = 255;
                    if (result.y > 255) result.y = 255;
                    if (result.z > 255) result.z = 255;

                    return Color.FromArgb(255, (int)(result.x), (int)(result.y), (int)(result.z));
                }

            }
            return background;
        }

        /// <summary>
        /// Вектор отражения
        /// </summary>
        /// <param name="I"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        private static Vec3f Reflect(Vec3f I, Vec3f N)
        {
            return I - N * 2f * (I * N);
        }

        /// <summary>
        /// Преломления
        /// </summary>
        /// <returns></returns>
        private static Vec3f Refract(Vec3f I, Vec3f N, float refIndex)
        {
            float cosI = -Math.Max(-1f, Math.Min(1f, I * N));
            float etaI = 1;
            float etat = refIndex;
            var n = N;

            if (cosI < 0)
            {
                cosI = -cosI;
                var _eta = etaI;
                etaI = etat;
                etat = _eta;
                n = -N;
            }

            var eta = etaI / etat;
            float k = 1 - eta * eta * (1 - cosI * cosI);

            var _n = n * (float)(eta * cosI - Math.Sqrt(k));

            return k < 0 ? new Vec3f(0, 0, 0) : I * eta + _n;
        }

        private static Bitmap CreateImage(int width, int height, Color[] imageData)
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
