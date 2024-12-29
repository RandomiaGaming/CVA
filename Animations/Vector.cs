namespace CVA.Animations
{
    public struct Vector
    {
        public Curve x;
        public Curve y;
        public Vector(Curve x, Curve y)
        {
            this.x = x;
            this.y = y;
        }
    }
}