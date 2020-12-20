using System;

namespace CVA.Continuous
{
    public class Renderer
    {
        public int renderWidth = 100;
        public int renderHeight = 100;

        public readonly Animation scene = null;
        public Renderer(Animation scene)
        {
            if (scene is null)
            {
                throw new NullReferenceException();
            }
            this.scene = scene;
        }
        public ColorRGB RenderPixel(int x, int y, double t)
        {
            Vector pixelInWorldSpace = new Vector(((x + 0.5) / renderWidth * scene.viewPortWidth) + scene.viewPortPositionX, ((y + 0.5) / renderHeight * scene.viewPortHeight) + scene.viewPortPositionY);
            ColorRGB output = scene.backgroundShader.SamplePoint(pixelInWorldSpace);

            foreach (Object o in scene.objects)
            {
                if (o.ContainsPoint(pixelInWorldSpace))
                {
                    output = CVAHelper.Flatten(output, o.SampleShader(pixelInWorldSpace));
                }
            }

            return output;
        }
        public System.Drawing.Bitmap RenderToBitmap(double t)
        {
            System.Drawing.Bitmap output = new System.Drawing.Bitmap(renderWidth, renderHeight);
            for (int x = 0; x < renderWidth; x++)
            {
                for (int y = 0; y < renderHeight; y++)
                {
                    ColorRGB pixelColor = RenderPixel(x, y, t);

                    byte r = (byte)(pixelColor.r * 255);
                    byte g = (byte)(pixelColor.g * 255);
                    byte b = (byte)(pixelColor.b * 255);
                    byte a = 255;

                    output.SetPixel(x, renderHeight - y - 1, System.Drawing.Color.FromArgb(BitConverter.ToInt32(new byte[] { r, g, b, a }, 0)));
                }
            }
            return output;
        }
        public Microsoft.Xna.Framework.Graphics.Texture2D RenderToTexture2D(Microsoft.Xna.Framework.Graphics.GraphicsDevice graphicsDevice)
        {
            Microsoft.Xna.Framework.Graphics.Texture2D output = new Microsoft.Xna.Framework.Graphics.Texture2D(graphicsDevice, renderWidth, renderHeight);

            Microsoft.Xna.Framework.Color[] outputColors = new Microsoft.Xna.Framework.Color[renderWidth * renderHeight];

            int i = 0;
            for (int y = renderHeight - 1; y >= 0; y--)
            {
                for (int x = 0; x < renderWidth; x++)
                {
                    ColorRGB pixelColor = RenderPixel(x, y);

                    byte r = (byte)(pixelColor.r * 255);
                    byte g = (byte)(pixelColor.g * 255);
                    byte b = (byte)(pixelColor.b * 255);
                    byte a = 255;

                    outputColors[i] = new Microsoft.Xna.Framework.Color(r, g, b, a);
                    i++;
                }
            }

            output.SetData(outputColors);

            return output;
        }
    }
}
