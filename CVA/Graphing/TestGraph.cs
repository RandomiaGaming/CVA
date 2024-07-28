namespace CVA.Graphing
{
    public sealed class TestGraph : Graph
    {
        public override double Sample(double value)
        {
            return System.Math.Sin(value);
        }
    }
}