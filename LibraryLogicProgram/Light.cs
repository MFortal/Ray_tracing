using static Geometry.Geometry;
namespace RayTracingLib
{
    public class Light : ILight
    {
        public Vec3f position { get; set; }
        public float intensity { get; set; }

        public Light(Vec3f position, float intensity)
        {
            this.position = position;
            this.intensity = intensity;
        }
    }
}
