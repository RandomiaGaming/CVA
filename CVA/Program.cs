using System;
using System.Drawing;
using Accord.Video.FFMPEG;
using cva = CVA.Static;
using System.Collections.Generic;

public static class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        CVAAnimationGame game = new CVAAnimationGame();
        game.Run();
        game.Dispose();
        //MakeVideo();
    }
    public static void MakeVideo()
    {
        cva.Scene scene = new cva.Scene();
        scene.viewPortHeight = 1;
        scene.viewPortWidth = 1;
        scene.viewPortPositionX = 0;
        scene.viewPortPositionY = 0;
        scene.backgroundShader = new cva.ConstantShaderRGB(new cva.ColorRGB(0, 0, 0));

        cva.Object obj2 = new cva.Object();
        obj2.position = new cva.Vector(-0.5, -0.5);
        obj2.negativeShapes = new List<cva.Shape>();
        obj2.shapes.Add(new cva.Rectangle());
        obj2.objectShader = new cva.ConstantShaderRGBA(new cva.ColorRGBA(1, 1, 1));

        scene.objects.Add(obj2);

        cva.Renderer renderer = new cva.Renderer(scene);
        renderer.renderWidth = 1000;
        renderer.renderHeight = 1000;

        VideoFileWriter vFWriter = new VideoFileWriter();

        vFWriter.Open(@"D:\TestVideo.mp4", 1000, 1000, 60, VideoCodec.MPEG4);

        for (int i = 0; i < 600; i++)
        {
            renderer.scene.objects[0].rotation = (i / 600.0) * 360.0;
            Bitmap frame = renderer.RenderToBitmap();
            vFWriter.WriteVideoFrame(frame);
            frame.Dispose();
        }

        vFWriter.Close();

        vFWriter.Dispose();
    }
}