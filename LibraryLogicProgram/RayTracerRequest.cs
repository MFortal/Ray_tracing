using System.Collections.Generic;

namespace RayTracingLib
{
    public class RayTracerRequest
    {
        public int Width { get; set; }

        public int Height { get; set; }

        private List<Sphere> Spheres { get; set; }

    }
}