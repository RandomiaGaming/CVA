using CVA.Core;
namespace CVA.Graphics
{
    public sealed class Rectangle : Shape
    {
        public Vector min = new Vector(-0.25, -0.25);
        public Vector max = new Vector(0.25, 0.25);
        public override bool ContainsPoint(Vector point)
        {
            if(point.x > min.x && point.x < max.x && point.y > min.y && point.y < max.y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
