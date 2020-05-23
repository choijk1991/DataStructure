namespace DataStructure.Graph
{
    class GraphEdge
    {
        public int Weight { get; }
        public GraphVertex Vertex1 { get; }
        public GraphVertex Vertex2 { get; }

        public GraphEdge(GraphVertex vertex1, GraphVertex vertex2, int weight)
        {
            Vertex1 = vertex1;
            Vertex2 = vertex2;
            Weight = weight;
        }
    }
}