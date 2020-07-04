using System.Collections.Generic;
using System.Linq;

namespace SmallestLastEdgeColoring.Generator.Model
{
    public class Graph
    {
        public List<Edge> Edges { get; set; }
        public int? GetEdgeColorCount() => Edges.OrderByDescending(x => x.Color).First().Color + 1;
    }
}
