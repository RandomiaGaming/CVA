namespace CVA.Animations
{
    public struct ColorRGB
    {
        public Curve r;
        public Curve g;
        public Curve b;
        public ColorRGB(Curve r, Curve g, Curve b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }
    }
}