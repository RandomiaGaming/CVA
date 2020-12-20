namespace CVA.Static
{
    public sealed class Triangle : Shape
    {
        public Vector corner1 = new Vector(0, 0);
        public Vector corner2 = new Vector(1, 0);
        public Vector corner3 = new Vector(0.5, 1);
        public override bool ContainsPoint(Vector point)
        {
            double d1, d2, d3;
            bool has_neg, has_pos;

            d1 = sign(point, corner1, corner2);
            d2 = sign(point, corner2, corner3);
            d3 = sign(point, corner3, corner1);

            has_neg = (d1 < 0) || (d2 < 0) || (d3 < 0);
            has_pos = (d1 > 0) || (d2 > 0) || (d3 > 0);

            return !(has_neg && has_pos);
        }
        private static double sign(Vector p1, Vector p2, Vector p3)
        {
            return (p1.x - p3.x) * (p2.y - p3.y) - (p2.x - p3.x) * (p1.y - p3.y);
        }
    }
}