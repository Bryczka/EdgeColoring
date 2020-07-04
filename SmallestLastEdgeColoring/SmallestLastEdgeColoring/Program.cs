using SmallestLastEdgeColoring.Algorithms;
using SmallestLastEdgeColoring.ALgorithms;
using SmallestLastEdgeColoring.Generator;
using System;

namespace SmallestLastEdgeColoring
{
    class Program
    {
        private static readonly int nodesCount = 4;
        private static readonly int edgesCount = 8;
        static void Main(string[] args)
        {
            var graphGenerator = new GraphGenerator();
            var graph = graphGenerator.GenerateGraph(nodesCount, edgesCount);

            SmallestLast smallestLast = new SmallestLast(graph);
            BruteForce bruteForce = new BruteForce(graph);

            var slWatch = System.Diagnostics.Stopwatch.StartNew();
            var slMemoryBefore = GC.GetTotalMemory(false) / 1024;
            var coloredGraphSL = smallestLast.SLAlgorithm();
            var slMemoryAfter = GC.GetTotalMemory(false) / 1024;
            slWatch.Stop();
            var slTime = slWatch.ElapsedMilliseconds;

            var bfWatch = System.Diagnostics.Stopwatch.StartNew();
            var bfMemoryBefore = GC.GetTotalMemory(false) / 1024;
            var coloredGraphBF = bruteForce.ColorEdges();
            var bfMemoryAfter = GC.GetTotalMemory(false) / 1024;
            bfWatch.Stop();
            var bfTime = bfWatch.ElapsedMilliseconds;

            Console.WriteLine("Algorytmy wykorzystane w zadaniu to algorytm dokładny kolorowania grafu oraz algorytm smallest last ");
            Console.WriteLine("Graf jest generowany losowo zgodnie z podaną ilością wierzchołków oraz krawędzi");
            Console.WriteLine("Liczba wierzchołków: " + nodesCount);
            Console.WriteLine("Liczba krawędzi: " + edgesCount);
            Console.WriteLine("----------------------------------- SMALLEST LAST ---------------------------------");
            Console.WriteLine("Ilość kolorów dla smallest last: " + coloredGraphSL.GetEdgeColorCount());
            Console.WriteLine("Czas trwania smallest last: " + slTime + " ms");
            Console.WriteLine("Pamięć dla smallest last: " + (slMemoryAfter - slMemoryBefore).ToString() + " kb");
            Console.WriteLine("----------------------------------- ALGORYTM DOKŁADNY ---------------------------------");
            Console.WriteLine("Ilość kolorów dla algorytmu dokładnego: " + coloredGraphBF.GetEdgeColorCount());
            Console.WriteLine("Czas trwania algorytmu dokładnego: " + bfTime + " ms");
            Console.WriteLine("Pamięć dla algorytmu dokładnego: " + (bfMemoryAfter - bfMemoryBefore).ToString() + " kb");

        }
    }
}
