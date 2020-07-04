using SmallestLastEdgeColoring.Generator.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SmallestLastEdgeColoring.Algorithms
{
    public class BruteForce
    {
        private bool isColored = false;
        private Graph _graph;

        public BruteForce(Graph graph)
        {
            _graph = graph;
        }
        public Graph ColorEdges()
        {
            for (int i = 2; i <= _graph.Edges.Count; i++) 
            {
                if (!isColored)
                {
                    Debug.WriteLine("Sprawdzenie dla: " + i + " kolorów");
                    Loop(i, _graph.Edges, 0);                
                }  
            }
            return _graph;
        }

        private void Loop(int colorCount, List<Edge> edges, int index)
        {
            for (int i = 0; i < colorCount; i++)
            {
                if (isColored) { break; }
                if (index >= edges.Count)
                {
                    int coloredGoodCount = 0;
                    foreach (Edge e in edges)
                    {
                        var connectedEdges = e.GetConnectedEdges(e.EdgeId, _graph);
                        if (connectedEdges.FindAll(x => x.Color == e.Color).Count == 0) { coloredGoodCount++; }
                    }
                    if (coloredGoodCount == edges.Count) { isColored = true; }
                    break;
                }
                edges[index].Color = i;
                Loop(colorCount, edges, index + 1);
            }
        }
    }
}
