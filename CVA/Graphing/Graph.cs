namespace CVA.Graphing
{
    public abstract class Graph
    {
        public CVA.Core.Color color = new Core.Color(255, 255, 255);
        public abstract double Sample(double value);
    }
}
