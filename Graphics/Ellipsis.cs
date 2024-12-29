using System;
using CVA.Core;
namespace CVA.Graphics
{
    public sealed class Ellipsis : Shape
    {
        public double height = 0.5;
        public double width = 1;
        public Vector center = new Vector(0, 0);
        public override bool ContainsPoint(Vector point)
        {
            Vector localizedPoint = new Vector(center.x - point.x, center.y - point.y);
            double a = CVAHelper.Sqr(localizedPoint.x) / CVAHelper.Sqr(width / 2);
            double b = CVAHelper.Sqr(localizedPoint.y) / CVAHelper.Sqr(height / 2);
            return a + b <= 1;
        }
    }
}
