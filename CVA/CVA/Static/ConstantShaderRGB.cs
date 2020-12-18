namespace CVA.Static
{
    public sealed class ConstantShaderRGB : ShaderRGB
    {
        public ColorRGB color = new ColorRGB(0, 0, 0);
        public override ColorRGB SamplePoint(Vector point)
        {
            return color;
        }
        public ConstantShaderRGB(ColorRGB color)
        {
            this.color = color;
        }
    }
}
