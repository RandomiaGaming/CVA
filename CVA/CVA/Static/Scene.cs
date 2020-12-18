using System.Collections.Generic;
namespace CVA.Static
{
    public sealed class Scene
    {
        public double viewPortWidth = 1;
        public double viewPortHeight = 1;
        public double viewPortPositionX = 0;
        public double viewPortPositionY = 0;

        public ShaderRGB backgroundShader = null;
        public List<Object> objects = new List<Object>();
    }
}