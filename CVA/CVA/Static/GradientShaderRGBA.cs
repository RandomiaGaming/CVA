namespace CVA.Static
{
    public class GradientShaderRGBA : ShaderRGBA
    {
        public ColorRGBA left = new ColorRGBA(0, 0, 0);
        public ColorRGBA right = new ColorRGBA(1, 1, 1);
        public override ColorRGBA SamplePoint(Vector point)
        {
            double sample = CVAHelper.LoopClamp(point.x, 0, 1);
            double r = CVAHelper.Lerp(sample, left.r, right.r);
            double g = CVAHelper.Lerp(sample, left.g, right.g);
            double b = CVAHelper.Lerp(sample, left.b, right.b);
            double a = CVAHelper.Lerp(sample, left.a, right.a);
            return new ColorRGBA(r, g, b, a);
        }
    }
}
