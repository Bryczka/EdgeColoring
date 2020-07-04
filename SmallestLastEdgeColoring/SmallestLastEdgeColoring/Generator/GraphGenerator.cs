using SmallestLastEdgeColoring.Generator.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmallestLastEdgeColoring.Generator
{
    public class GraphGenerator
    {
        public Graph GenerateGraph(int nodesCount, int edgesCount)
        {
            Random random = new Random();
            Graph graph = new Graph();
            List<Edge> edges = new List<Edge>();
            List<int> nodes = new List<int>();

            for (int i = 0; i < nodesCount; i++) { nodes.Add(i); }
            nodes = nodes.OrderBy(x => random.Next()).ToList();
            for (int i = 0; i < edgesCount; i++)
            {
                if (i < nodesCount - 1) { edges.Add(new Edge(i, Tuple.Create(nodes[i], nodes[i + 1]))); }
                else {
                    var t = Tuple.Create(0, 0);
                    while(edges.FindAll(x=>(x.Nodes.Item1 == t.Item1 && x.Nodes.Item2 == t.Item1) ||
                    (x.Nodes.Item1 == t.Item2 && x.Nodes.Item2 == t.Item1)).Count != 0 || t.Item1 == t.Item2)
                    {
                        t = Tuple.Create(nodes[random.Next(0, nodesCount - 1)], nodes[random.Next(0, nodesCount - 1)]);
                    }
                    edges.Add(new Edge(i, t)); 
                }
            }
            Console.WriteLine("Utworzony graf (zapis czytać należy Wierzchołek : Wierzchołek)");
            edges.ForEach(i => Console.WriteLine(i.Nodes.Item1 + " ---- " + i.Nodes.Item2));
            graph.Edges = edges;
            return graph;
        }
    }
}
