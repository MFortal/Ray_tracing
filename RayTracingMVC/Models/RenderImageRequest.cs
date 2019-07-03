using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RayTracingLib;

namespace RayTracingMVC.Models
{
    public class RenderImageRequest
    {
        public Geometry.Geometry.Vec3f Origin { get; set; }
        public List<Sphere> Spheres { get; set; }
        public List<Light> Lights { get; set; }
    }
}