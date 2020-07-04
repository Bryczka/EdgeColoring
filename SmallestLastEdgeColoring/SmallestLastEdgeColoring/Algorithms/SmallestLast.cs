using SmallestLastEdgeColoring.Generator.Model;
using System.Collections.Generic;
using System.Linq;

namespace SmallestLastEdgeColoring.ALgorithms
{
    public class SmallestLast
    {
        private Graph _graph;

        public SmallestLast(Graph graph)
        {
            _graph = graph;
        }
        public Graph SLAlgorithm()
        {
            _graph.Edges = GreedyColoringAlghoritm(EdgesList());
            return _graph;
        }

        private List<Edge> GetEdgesByDegreeList(List<Edge> edges)
        {
            List<Edge> edgesWithDegree = new List<Edge>();
            foreach (Edge edge in edges)
            {
                edge.Degree = edge.GetEdgeDegree(edge.EdgeId, edges);
                edgesWithDegree.Add(edge);
            }
            return edgesWithDegree.OrderBy(x => x.Degree).ToList();
        }

        private List<Edge> EdgesList()
        {
            var a = new List<Edge>(_graph.Edges);
            var listGood = new List<Edge>();           
            while(listGood.Count < _graph.Edges.Count)
            {
                var list = GetEdgesByDegreeList(a);
                listGood.Add(list[0]);
                a.Remove(list[0]);
            }
            return listGood.OrderByDescending(x=>x.Degree).ToList();

        }

        private List<Edge> GreedyColoringAlghoritm(List<Edge> edges)
        {
            foreach (Edge edge in edges)
            {
                int i = 0;
                var connectedEdges = edge.GetConnectedEdges(edge.EdgeId, _graph);
                while (edge.Color == null)
                {
                    if (connectedEdges.FindAll(x => x.Color == i).Count() == 0) { edge.Color = i; }                       
                    i++;
                }
            }
            return edges;
        }
    }
}
