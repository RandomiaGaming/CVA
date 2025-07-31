using System.Collections.Generic;
using CVA.Core;
namespace CVA.Animations
{
    public sealed class Object
    {
        public Vector position;
        public Curve rotation;
        public Vector scale;
        public ShaderRGBA objectShader;
        public List<Shape> shapes = new List<Shape>();
        public List<Shape> negativeShapes = new List<Shape>();
        public Vector Transform(Vector original)
        {
            return CVAHelper.RotateVector((original + position) / scale, rotation);
        }
        public bool ContainsPoint(Vector point)
        {
            Vector transformedPoint = Transform(point);
            foreach (Shape s in shapes)
            {
                if (s.ContainsPoint(transformedPoint))
                {
                    foreach (Shape ns in negativeShapes)
                    {
                        if (ns.ContainsPoint(transformedPoint))
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
            return false;
        }
        public ColorRGBA SampleShader(Vector point, double t)
        {
            return objectShader.SamplePoint(Transform(point));
        }
    }
}
