using System.Collections.Generic;
using CVA.Core;
namespace CVA.Graphics
{
    public sealed class Object
    {
        public Vector position = new Vector(0, 0);
        public double rotation = 0;
        public Vector scale = new Vector(1, 1);
        public Shader objectShader = null;
        public List<Shape> shapes = new List<Shape>();
        public List<Shape> negativeShapes = new List<Shape>();
        public Vector Transform(Vector original)
        {
            return original - position;
        }
        public bool ContainsPoint(Vector point)
        {
            if(shapes.Count == 0)
            {
                return false;
            }
            if(negativeShapes.Count != 0)
            {
                foreach (Shape ns in negativeShapes)
                {
                    if (ns.ContainsPoint(point))
                    {
                        return false;
                    }
                }
            }
            foreach (Shape s in shapes)
            {
                if (s.ContainsPoint(point))
                {
                    return true;
                }
            }
            return false;
        }
        public Color SampleShader(Vector point)
        {
            return objectShader.SamplePoint(point);
        }
    }
}
