using System;
namespace CVA
{
    public class GraphicViewer : Microsoft.Xna.Framework.Game
    {
        private CVA.Core.Bitmap graphic = new Core.Bitmap(1920, 1080);
        private Microsoft.Xna.Framework.Color[] monogameGraphicColors = new Microsoft.Xna.Framework.Color[0];
        private Microsoft.Xna.Framework.Graphics.Texture2D monogameGraphic = null;
        private Microsoft.Xna.Framework.Graphics.SpriteBatch monogameSpriteBatch = null;
        public GraphicViewer(CVA.Core.Bitmap graphic)
        {
            this.graphic = graphic;
            foreach (CVA.Core.Color c in graphic.GetData())
            {
                if (c.r > 0)
                {
                    //teset
                }
            }
            _ = new Microsoft.Xna.Framework.GraphicsDeviceManager(this)
            {
                SynchronizeWithVerticalRetrace = false
            };
            Window.AllowUserResizing = true;
            Window.AllowAltF4 = true;
            Window.IsBorderless = false;
            Window.Title = "CVA Graphic Veiwer";
            IsMouseVisible = true;
            IsFixedTimeStep = false;
            TargetElapsedTime = new TimeSpan(10000000 / 60);
        }
        protected override void Initialize()
        {
            monogameGraphicColors = new Microsoft.Xna.Framework.Color[graphic.width * graphic.height];
            int i = 0;
            for (int y = graphic.height - 1; y >= 0; y--)
            {
                for (int x = 0; x < graphic.width; x++)
                {
                    CVA.Core.Color pixelColor = graphic.GetPixel(x, y);
                    monogameGraphicColors[i] = new Microsoft.Xna.Framework.Color(pixelColor.r, pixelColor.g, pixelColor.b, byte.MaxValue);
                    i++;
                }
            }
            monogameGraphic = new Microsoft.Xna.Framework.Graphics.Texture2D(GraphicsDevice, graphic.width, graphic.height);
            monogameGraphic.SetData(monogameGraphicColors);
            monogameSpriteBatch = new Microsoft.Xna.Framework.Graphics.SpriteBatch(GraphicsDevice);
            base.Initialize();
        }
        protected override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            monogameSpriteBatch.Begin(samplerState: Microsoft.Xna.Framework.Graphics.SamplerState.PointClamp);
            monogameSpriteBatch.Draw(monogameGraphic, new Microsoft.Xna.Framework.Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Microsoft.Xna.Framework.Color.White);
            monogameSpriteBatch.End();
            base.Draw(gameTime);
        }
    }
}