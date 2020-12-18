using System.Collections.Generic;
namespace CVA.Continuous
{
    public sealed class Animation
    {
        public ColorRGB backgroundColor = new ColorRGB();
        public List<Tri> tris = new List<Tri>();
        public List<Circle> circles = new List<Circle>();
    }
}