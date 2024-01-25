using CVA.Core;
namespace CVA.Graphics
{
    public sealed class ConstantShader : Shader
    {
        public Color color = new Color(0, 0, 0);
        public override Color SamplePoint(Vector point)
        {
            return color;
        }
        public ConstantShader(Color color)
        {
            this.color = color;
        }
    }
}
