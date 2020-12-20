namespace CVA.Static
{
    public sealed class ConstantShaderRGBA : ShaderRGBA
    {
        public ColorRGBA color = new ColorRGBA(0, 0, 0, 1);
        public override ColorRGBA SamplePoint(Vector point)
        {
            return color;
        }
        public ConstantShaderRGBA(ColorRGBA color)
        {
            this.color = color;
        }
    }
}
