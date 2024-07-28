namespace CVA.Animations
{
    public struct ColorRGBA
    {
        public Curve r;
        public Curve g;
        public Curve b;
        public Curve a;
        public ColorRGBA(Curve r, Curve g, Curve b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            a =  1;
        }
        public ColorRGBA(Curve r, Curve g, Curve b, Curve a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }
    }
}