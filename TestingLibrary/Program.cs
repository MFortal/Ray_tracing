using RayTracingLib;


namespace TestingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //ширина
            int width = 1024;
            //высота
            int height = 768;

            //получение массива различных пикселей
            var pixel = ImageService.GetImageArray(width, height);

            //получение холста
            var image = ImageService.CreateImage(width, height, pixel);

            //сохранение изображения на диск                     
            image.Save("C:/1/2.bmp");
        }
    }
}
