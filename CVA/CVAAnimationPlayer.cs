using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using cva = CVA.Static;

public class CVAAnimationGame : Game
{
    private SpriteBatch spriteBatch;
    private readonly cva.Renderer renderer;
    private double animationProgress = 0;
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

        cva.Scene scene = new cva.Scene
        {
            viewPortHeight = 1,
            viewPortWidth = 1,
            viewPortPositionX = 0,
            viewPortPositionY = 0,
            backgroundShader = new cva.ConstantShaderRGB(new cva.ColorRGB(0, 0, 0))
        };

        cva.Object topCheek = new cva.Object
        {
            position = new cva.Vector(0.5, 0.5),
            scale = new cva.Vector(-1, 1),
            negativeShapes = new List<cva.Shape>(),
            objectShader = new cva.ConstantShaderRGBA(new cva.ColorRGBA(1, 1, 1))
        };
        topCheek.shapes.Add(new cva.Curve());

        cva.Object bottomCheek = new cva.Object
        {
            position = new cva.Vector(0.5, 0.5),
            scale = new cva.Vector(-1, -1),
            negativeShapes = new List<cva.Shape>(),
            objectShader = new cva.ConstantShaderRGBA(new cva.ColorRGBA(1, 1, 1))
        };
        bottomCheek.shapes.Add(new cva.Curve());

        scene.objects.Add(topCheek);
        scene.objects.Add(bottomCheek);

        renderer = new cva.Renderer(scene)
        {
            renderWidth = 100,
            renderHeight = 100
        };
    }
    protected override void Update(GameTime gameTime)
    {
        animationProgress += gameTime.ElapsedGameTime.TotalSeconds / 10;
        animationProgress = cva.CVAHelper.LoopClamp(animationProgress, 0, 1);

        ((cva.Curve)renderer.scene.objects[0].shapes[0]).height = animationProgress / 2;
    }
    protected override void Initialize()
    {
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