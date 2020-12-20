namespace CVA.Static
{
    public sealed class Curve : Shape
    {
        public double height = 0.25;
        public double width = 0.25;
        public Vector center = new Vector(0, 0);
        public override bool ContainsPoint(Vector point)
        {
            if(point.x < center.x)
            {
                return false;
            }
            if (point.y < center.y)
            {
                return false;
            }
            Vector localizedPoint = new Vector(center.x - point.x, center.y - point.y);
            double a = CVAHelper.Sqr(localizedPoint.x) / CVAHelper.Sqr(width);
            double b = CVAHelper.Sqr(localizedPoint.y) / CVAHelper.Sqr(height);
            return a + b <= 1;
        }
    }
}