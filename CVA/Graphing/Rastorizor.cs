using CVA.Core;
namespace CVA.Graphing
{
    public static class Rastorizor
    {
        public static Bitmap Rastor(Scene scene, ushort pixelWidth, ushort pixelHeight)
        {
            Bitmap output = new Bitmap(pixelWidth, pixelHeight);
            double premultipliedWidth = pixelWidth * scene.viewPortWidth;
            double premultipliedHeight = pixelHeight * scene.viewPortHeight;
            for (int x = 0; x < pixelWidth; x++)
            {
                double xMin = (x / premultipliedWidth) + scene.viewPortPositionX;
                double xMax = ((x + 1.0) / premultipliedWidth) + scene.viewPortPositionX;
                int graphCount = scene.graphs.Count;
                Range[] ranges = new Range[graphCount];
                for (int i = 0; i < graphCount; i++)
                {
                    double sample0 = scene.graphs[i].Sample(xMin);
                    double sample1 = scene.graphs[i].Sample(xMax);
                    if(sample0 < sample1)
                    {
                        ranges[i] = new Range(sample0, sample1);
                    }
                    else
                    {
                        ranges[i] = new Range(sample1, sample0);
                    }
                }
                for (int y = 0; y < pixelHeight; y++)
                {
                    bool hit = false;
                    double yMin = (y / premultipliedHeight) + scene.viewPortPositionY;
                    double yMax = ((y + 1.0) / premultipliedHeight) + scene.viewPortPositionY;
                    Range yRange = new Range(yMin, yMax);
                    for (int i = 0; i < graphCount; i++)
                    {
                        if (yRange.Overlaps(ranges[i]))
                        {
                            output.SetPixel(x, y, scene.graphs[i].color);
                            hit = true;
                            break;
                        }
                    }
                    if (!hit)
                    {
                        output.SetPixel(x, y, scene.backgroundColor);
                    }
                }
            }
            return output;
        }
    }
}
