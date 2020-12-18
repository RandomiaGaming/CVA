namespace CVA.Static
{
    public class GradientShaderRGB : ShaderRGB
    {
        public ColorRGB left = new ColorRGB(0, 0, 0);
        public ColorRGB right = new ColorRGB(1, 1, 1);
        public override ColorRGB SamplePoint(Vector point)
        {
            double sample = CVAHelper.LoopClamp(point.x, 0, 1);
            double r = CVAHelper.Lerp(sample, left.r, right.r);
            double g = CVAHelper.Lerp(sample, left.g, right.g);
            double b = CVAHelper.Lerp(sample, left.b, right.b);
            return new ColorRGB(r, g, b);
        }
    }
}
