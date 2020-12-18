using System.Collections.Generic;
namespace CVA.Static
{
    public sealed class Object
    {
        public Vector position = new Vector(0, 0);
        public double rotation = 0;
        public Vector scale = new Vector(1, 1);
        public ShaderRGBA objectShader = null;
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
        public ColorRGBA SampleShader(Vector point)
        {
            return objectShader.SamplePoint(Transform(point));
        }
    }
}
