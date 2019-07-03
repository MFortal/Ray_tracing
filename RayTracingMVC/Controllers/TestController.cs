using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RayTracingLib;
using RayTracingMVC.Models;

namespace RayTracingMVC.Controllers
{
    public class RenderController : ApiController
    {
        [HttpPost]
        public int RenderImage(RenderImageRequest request)
        {
            return 1;
        }

    }
}
