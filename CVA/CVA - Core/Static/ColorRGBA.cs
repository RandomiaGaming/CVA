namespace CVA.Static
{
    public struct ColorRGBA
    {
        public double r;
        public double g;
        public double b;
        public double a;
        public ColorRGBA(double r, double g, double b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            a = 1;
        }
        public ColorRGBA(double r, double g, double b, double a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }
    }
}