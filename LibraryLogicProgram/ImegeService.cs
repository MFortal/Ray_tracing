using System;
using System.Drawing;
using System.Drawing.Imaging;


namespace RayTracingLib
{
    public class ImageService
    {
        /// <summary>
        /// Создание массива пикселей
        /// </summary>
        /// <param name="width">ширина</param>
        /// <param name="height">высота</param>
        /// <returns></returns>
        public static byte[] GetImageArray(int width, int height)
        {
            //создание массива пикселей
            byte[] p = new byte[width * height];

            //Создание объекта для генерации чисел
            Random rnd = new Random();

            //заполнение массива чиселками
            for (int i = 0; i < p.Length; i++)
            {
                p[i] = (byte)(rnd.Next(0, 255));
            }
            return p;
        }

        /// <summary>
        /// Создание изображения из пикселей
        /// </summary>
        /// <param name="width">ширина холста</param>
        /// <param name="height">высота</param>
        /// <param name="imageData">массив пикселей</param>
        /// <returns></returns>
        public static Bitmap CreateImage(int width, int height, byte[] imageData)
        {
            byte[] data = new byte[width * height * 4];
            int l = 0;
            for (int i = 0; i < imageData.Length; i++)
            {
                byte value = imageData[i];
                data[l++] = value;
                data[l++] = value;
                data[l++] = value;
                data[l++] = 0;
            }
            unsafe
            {
                fixed (byte* ptr = data)
                {
                    return new Bitmap(width, height, width * 4, PixelFormat.Format32bppRgb, new IntPtr(ptr));
                }
            }
        }
    }
}
