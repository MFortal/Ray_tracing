
namespace RayTracingLib
{
    public class Light
    {
        public Geometry.Geometry.Vec3f position;
        public float intensity;

        public Light(Geometry.Geometry.Vec3f position, float intensity)
        {
            this.position = position;
            this.intensity = intensity;
        }
    }
}
