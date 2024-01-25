using System.Collections.Generic;
using CVA.Core;
namespace CVA.Graphics
{
    public sealed class Scene
    {
        public double viewPortWidth = 1;
        public double viewPortHeight = 1;
        public double viewPortPositionX = 0;
        public double viewPortPositionY = 0;

        public Shader backgroundShader = null;
        public List<Object> objects = new List<Object>();
    }
}