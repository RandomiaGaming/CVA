using CVA.Core;
namespace CVA.Graphics
{
    public class GradientShader : Shader
    {
        public Color left = new Color(0, 0, 0);
        public Color right = new Color(1, 1, 1);
        public override Color SamplePoint(Vector point)
        {
            double sample = CVAHelper.LoopClamp(point.x, 0, 1);
            double r = CVAHelper.Lerp(sample, left.r, right.r);
            double g = CVAHelper.Lerp(sample, left.g, right.g);
            double b = CVAHelper.Lerp(sample, left.b, right.b);
            return new Color((byte)(r * 255), (byte)(g * 255), (byte)(b * 255));
        }
    }
}
