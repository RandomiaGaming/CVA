using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using cva = CVA.Static;

public class CVAAnimationGame : Game
{
    private Texture2D frame;
    private Color[] frameColors;
    private SpriteBatch spriteBatch;
    private cva.Renderer renderer;
    public CVAAnimationGame()
    {
        _ = new GraphicsDeviceManager(this)
        {
            SynchronizeWithVerticalRetrace = false
        };
        Window.AllowUserResizing = true;
        Window.AllowAltF4 = true;
        Window.IsBorderless = false;
        Window.Title = "Don't Melt - 1.0.0";
        IsMouseVisible = true;
        IsFixedTimeStep = false;
        TargetElapsedTime = new TimeSpan(10000000 / 60);

        cva.Scene scene = new cva.Scene();
        scene.viewPortHeight = 1;
        scene.viewPortWidth = 1;
        scene.viewPortPositionX = 0;
        scene.viewPortPositionY = 0;
        scene.backgroundShader = new cva.ConstantShaderRGB(new cva.ColorRGB(0, 0, 0));

        cva.Object obj1 = new cva.Object();
        obj1.position = new cva.Vector(-0.5, -0.5);
        obj1.negativeShapes = new List<cva.Shape>();
        obj1.shapes.Add(new cva.Rectangle());
        obj1.objectShader = new cva.ConstantShaderRGBA(new cva.ColorRGBA(1, 1, 1, 0.5));

        cva.Object obj2 = new cva.Object();
        obj2.position = new cva.Vector(-1, -0.5);
        obj2.negativeShapes = new List<cva.Shape>();
        obj2.shapes.Add(new cva.Circle());
        obj2.objectShader = new cva.ConstantShaderRGBA(new cva.ColorRGBA(1, 0, 0, 1));

        scene.objects.Add(obj2);
        scene.objects.Add(obj1);

        renderer = new cva.Renderer(scene);
        renderer.renderWidth = 100;
        renderer.renderHeight = 100;
    }
    protected override void Update(GameTime gameTime)
    {
        renderer.scene.objects[0].rotation += gameTime.ElapsedGameTime.TotalMinutes * 360.0;
        base.Update(gameTime);
    }
    protected override void Initialize()
    {
        frame = new Texture2D(GraphicsDevice, 256, 144);
        frameColors = new Color[256 * 144];
        spriteBatch = new SpriteBatch(GraphicsDevice);
    }
    protected override void Draw(GameTime gameTime)
    {
        spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        spriteBatch.Draw(renderer.RenderToTexture2D(GraphicsDevice), new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
        spriteBatch.End();

        Console.WriteLine($"{gameTime.ElapsedGameTime.Ticks / 1000}k TPF which is {(int)(1.0 / (gameTime.ElapsedGameTime.Ticks / 10000000.0))} FPS.");
    }
}