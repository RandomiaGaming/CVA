using System;
using CVA.Core;
namespace CVA.Graphics
{
    public static class Rastorizor
    {
        public static Bitmap Rastor(Scene scene, ushort pixelWidth, ushort pixelHeight)
        {
            Bitmap output = new Bitmap(pixelWidth, pixelHeight);
            int pixelHeightMinusOne = pixelHeight - 1;
            double premultipliedWidth = pixelWidth * scene.viewPortWidth;
            double premultipliedHeight = pixelHeight * scene.viewPortHeight;
            for (int x = 0; !(x == pixelWidth); x++)
            {
                for (int y = 0; !(y == pixelHeight); y++)
                {
                    Vector pixelInWorldSpace = new Vector(((x + 0.5) / premultipliedWidth) + scene.viewPortPositionX, ((y + 0.5) / premultipliedHeight) + scene.viewPortPositionY);
                    output.SetPixel(x, pixelHeightMinusOne - y, scene.backgroundShader.SamplePoint(pixelInWorldSpace));
                    foreach (Object o in scene.objects)
                    {
                        Vector pixelInLocalSpace = o.Transform(pixelInWorldSpace);
                        if (o.ContainsPoint(pixelInLocalSpace))
                        {
                            output.SetPixel(x, pixelHeightMinusOne - y, o.SampleShader(pixelInLocalSpace));
                        }
                    }
                }
            }
            return output;
        }
    }
}
