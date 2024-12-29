using System;
using CVA.Core;
namespace CVA.Graphics
{
    public sealed class Circle : Shape
    {
        public double radius = 0.5;
        public Vector center = new Vector(0, 0);
        public override bool ContainsPoint(Vector point)
        {
            Vector localizedPoint = new Vector(center.x - point.x, center.y - point.y);
            double distance = Math.Sqrt((localizedPoint.x * localizedPoint.x) + (localizedPoint.y * localizedPoint.y));
            return distance / radius <= 1;
        }
    }
}
