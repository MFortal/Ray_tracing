using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Mvc;
using RayTracingLib;
using RayTracingMVC.Extensions;
using RayTracingMVC.Models;

namespace RayTracingMVC.Controllers
{
    public class RenderController : ApiController
    {
        [System.Web.Http.HttpPost]
        public HttpResponseMessage RenderImage(RenderImageRequest request)
        {
            var width = request.Width;
            var height = request.Height;

            var spheres = request.Spheres;
            var checkerBoard = request.CheckerBoard;

            var obj = new List<IObjectBase>();
            foreach (var sphere in spheres)
            {
                obj.Add(sphere);
            }
            foreach (var checker in checkerBoard)
            {
                obj.Add(checker);
            }

            var pathBack = request.PathBack;
            var client = new WebClient();
            var stream = client.OpenRead(pathBack);
            var background = new Bitmap(stream);

            var ligths = request.Lights;
            

            var byteArray = RayTraceHelper.Render(width, height, obj, background, ligths).ToByteArray(ImageFormat.Jpeg);

            HttpResponseMessage response = new HttpResponseMessage();
            response.Content = new StreamContent(new MemoryStream(byteArray)); // this file stream will be closed by lower layers of web api for you once the response is completed.
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");

            return response;
        }



    }
}
