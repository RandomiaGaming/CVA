using System.Collections.Generic;
namespace CVA.Animations
{
    public sealed class Animation
    {
        public Curve viewPortWidth;
        public Curve viewPortHeight;
        public Curve viewPortPositionX;
        public Curve viewPortPositionY;

        public ShaderRGB backgroundShader = null;
        public List<Object> objects = new List<Object>();
    }
}