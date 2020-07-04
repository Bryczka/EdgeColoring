using System;
using System.Collections.Generic;
using System.Linq;

namespace SmallestLastEdgeColoring.Generator.Model
{
    public class Edge
    {
        public int? Color { get; set; }
        public int EdgeId { get; set; }
        public Tuple<int, int> Nodes { get; set; }
        public int Degree { get; set; }

        public Edge(int edgeId, Tuple<int, int> nodes)
        {
            EdgeId = edgeId;
            Nodes = nodes;
            Color = null;
        }

        public int GetEdgeDegree(int edgeId, List<Edge> edges)
        {
            var edge = edges.Where(x => x.EdgeId == edgeId).FirstOrDefault();
            var degree = edges.FindAll(x =>
                                        x.Nodes.Item1 == edge.Nodes.Item1 ||
                                        x.Nodes.Item1 == edge.Nodes.Item2 ||
                                        x.Nodes.Item2 == edge.Nodes.Item1 ||
                                        x.Nodes.Item2 == edge.Nodes.Item2)
                                        .Count();
            return degree--;
        }

        public List<Edge> GetConnectedEdges(int edgeId, Graph graph)
        {
            var edge = graph.Edges.Where(x => x.EdgeId == edgeId).FirstOrDefault();
            var connectedEdgesList = graph.Edges.FindAll(x => 
                                        x.Nodes.Item1 == edge.Nodes.Item1 ||
                                        x.Nodes.Item1 == edge.Nodes.Item2 ||
                                        x.Nodes.Item2 == edge.Nodes.Item1 ||
                                        x.Nodes.Item2 == edge.Nodes.Item2
                                        ).Where(x => x.EdgeId != edge.EdgeId)
                                        .ToList();
            return connectedEdgesList;
        }
    }
}