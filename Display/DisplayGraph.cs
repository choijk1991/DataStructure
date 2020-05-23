using System;
using DataStructure.Graph;

namespace DataStructure.Display
{
    static class DisplayGraph
    {
        public static void DisplayAdjustListGraph()
        {
            AdjustListGraph graph = new AdjustListGraph(5, (value1, value2) => value1 >= value2);

            graph.AddEdge(GraphVertex.A, GraphVertex.B);
            graph.AddEdge(GraphVertex.A, GraphVertex.D);
            graph.AddEdge(GraphVertex.B, GraphVertex.C);
            graph.AddEdge(GraphVertex.C, GraphVertex.D);
            graph.AddEdge(GraphVertex.D, GraphVertex.E);
            graph.AddEdge(GraphVertex.E, GraphVertex.A);

            graph.ShowEdgeInformation();
        }

        public static void DisplayKruskalSpanningTree()
        {
            AdjustListGraph graph = new AdjustListGraph(6, (value1, value2) => value1 >= value2);

            graph.AddEdge(GraphVertex.A, GraphVertex.B, 9);
            graph.AddEdge(GraphVertex.B, GraphVertex.C, 2);
            graph.AddEdge(GraphVertex.A, GraphVertex.C, 12);
            graph.AddEdge(GraphVertex.A, GraphVertex.D, 8);
            graph.AddEdge(GraphVertex.D, GraphVertex.C, 6);
            graph.AddEdge(GraphVertex.A, GraphVertex.F, 11);
            graph.AddEdge(GraphVertex.F, GraphVertex.D, 4);
            graph.AddEdge(GraphVertex.D, GraphVertex.E, 3);
            graph.AddEdge(GraphVertex.E, GraphVertex.C, 7);
            graph.AddEdge(GraphVertex.F, GraphVertex.E, 13);

            graph.ShowEdgeInformation();
            graph.ConvertKruskalSpanningTree();
            Console.WriteLine();
            graph.ShowEdgeInformation();
            graph.ShowGraphEdgeWeightInfo();
            
        }

        public static void DisplayGraphDepthBreadthSearch()
        {
            AdjustListGraph graph = new AdjustListGraph(7, (value1, value2) => value1 >= value2);

            graph.AddEdge(GraphVertex.A, GraphVertex.B);
            graph.AddEdge(GraphVertex.A, GraphVertex.D);
            graph.AddEdge(GraphVertex.B, GraphVertex.C);
            graph.AddEdge(GraphVertex.D, GraphVertex.C);
            graph.AddEdge(GraphVertex.D, GraphVertex.E);
            graph.AddEdge(GraphVertex.E, GraphVertex.F);
            graph.AddEdge(GraphVertex.E, GraphVertex.G);

            graph.ShowEdgeInformation();
            graph.ShowVertexGraphWithDepth(GraphVertex.A);
            graph.ShowVertexGraphWithDepth(GraphVertex.C);
            graph.ShowVertexGraphWithDepth(GraphVertex.E);
            graph.ShowVertexGraphWithDepth(GraphVertex.G);
            graph.ShowVertexGraphWithBreadth(GraphVertex.A);
            graph.ShowVertexGraphWithBreadth(GraphVertex.C);
            graph.ShowVertexGraphWithBreadth(GraphVertex.E);
            graph.ShowVertexGraphWithBreadth(GraphVertex.G);
        }
    }
}