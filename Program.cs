using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace CVA
{
    public static class Program
    {
        public const int testIterations = 1;
        public const ushort rastorWidth = 1920;
        public const ushort rastorHeight = 1080;
        [STAThread]
        static void Main()
        {
            CVA.Graphing.Scene scene = new CVA.Graphing.Scene()
            {
                backgroundColor = new CVA.Core.Color(0, 0, 0),
                graphs = new List<Graphing.Graph>(),
                viewPortHeight = 1,
                viewPortWidth = 1,
                viewPortPositionX = 0,
                viewPortPositionY = 0
            };

            CVA.Graphing.TestGraph testGraph = new CVA.Graphing.TestGraph()
            {
                color = new CVA.Core.Color(255, 0, 0)
            };

            scene.graphs.Add(testGraph);



            List<long> computeTimes = new List<long>();

            Stopwatch stopwatch = new Stopwatch();

            for (int i = 0; i < testIterations; i++)
            {
                stopwatch.Reset();
                stopwatch.Start();
                _ = CVA.Graphing.Rastorizor.Rastor(scene, rastorWidth, rastorHeight);
                stopwatch.Stop();
                computeTimes.Add(stopwatch.ElapsedTicks);
                Console.WriteLine($"Finished iteration {i + 1} of {testIterations} in {stopwatch.ElapsedTicks} ticks which is {stopwatch.ElapsedTicks / 10000000.0} seconds.");
            }

            long totalComputeTime = 0;
            foreach (long computeTime in computeTimes)
            {
                totalComputeTime += computeTime;
            }
            long averageComputeTime = totalComputeTime / testIterations;
            Console.WriteLine($"Test finished with an average time of {averageComputeTime} ticks which is {averageComputeTime / 10000000.0} seconds.");

            GraphicViewer graphicViewer = new GraphicViewer(CVA.Graphing.Rastorizor.Rastor(scene, rastorWidth, rastorHeight));
            graphicViewer.Run();
        }
    }
}