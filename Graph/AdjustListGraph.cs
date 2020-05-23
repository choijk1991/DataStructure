using System;
using DataStructure.Heap;
using DataStructure.List;
using DataStructure.Queue;
using DataStructure.Stack;

namespace DataStructure.Graph
{
    enum GraphVertex
    {
        A = 0,
        B = 1,
        C = 2,
        D = 3,
        E = 4,
        F = 5,
        G = 6,
        H = 7,
        I = 8,
        J = 9
    }

    class AdjustListGraph
    {
        public int VertexCount => _lists.Length;
        public int EdgeCount { get; private set; }
        
        private readonly SimpleLinkedList<GraphVertex>[] _lists;
        private readonly int[] _visitInformation;
        private readonly PriorityQueue<GraphEdge> _edgeQueue;

        public AdjustListGraph(int vertexCount, SimpleLinkedList<GraphVertex>.CompareDelegate rule)
        {
            _lists = new SimpleLinkedList<GraphVertex>[vertexCount];
            _visitInformation = new int[vertexCount];
            
            _edgeQueue = new PriorityQueue<GraphEdge>(vertexCount*2, (value1, value2) => value1.Weight - value2.Weight >= 0);

            for (int i = 0; i < _lists.Length; i++)
            {
                _lists[i] = new SimpleLinkedList<GraphVertex>();
                _lists[i].SetSortRule(rule);
            }
        }

        public void AddEdge(GraphVertex fromVertex, GraphVertex toVertex)
        {
            int intFromVertex = (int) fromVertex;
            int intToVertex = (int) toVertex;

            _lists[intFromVertex].Insert(toVertex);
            _lists[intToVertex].Insert(fromVertex);

            EdgeCount++;
        }

        public void AddEdge(GraphVertex fromVertex, GraphVertex toVertex, int weight)
        {
            GraphEdge edge = new GraphEdge(fromVertex, toVertex, weight);

            int intFromVertex = (int)fromVertex;
            int intToVertex = (int)toVertex;

            _lists[intFromVertex].Insert(toVertex);
            _lists[intToVertex].Insert(fromVertex);

            EdgeCount++;

            _edgeQueue.Enqueue(edge);
        }

        public void ConvertKruskalSpanningTree()
        {
            GraphEdge[] edges = new GraphEdge[20];
            int index = 0;

            while (EdgeCount+1 > VertexCount)
            {
                GraphEdge edge = _edgeQueue.Dequeue();

                RemoveEdge(edge.Vertex1, edge.Vertex2);

                if (CheckVertexConnection(edge.Vertex1, edge.Vertex2)) continue;

                RecoverEdge(edge.Vertex1, edge.Vertex2);

                edges[index++] = edge;
            }

            for (var i = 0; i < index; i++)
            {
                GraphEdge edge = edges[i];
                _edgeQueue.Enqueue(edge);
            }
        }

        public void ShowGraphEdgeWeightInfo()
        {
            PriorityQueue<GraphEdge> queue = _edgeQueue;

            while (!queue.IsEmpty())
            {
                GraphEdge edge = queue.Dequeue();
                Console.WriteLine("[" + edge.Vertex1 + ", " + edge.Vertex2 + "] : " + edge.Weight);
            }
        }

        private void RecoverEdge(GraphVertex fromVertex, GraphVertex toVertex)
        {   
            _lists[(int)fromVertex].Insert(toVertex);
            _lists[(int)toVertex].Insert(fromVertex);

            EdgeCount++;
        }

        private bool CheckVertexConnection(GraphVertex vertex1, GraphVertex vertex2)
        {
            GraphVertex visit = vertex1;
            ListStack<GraphVertex> stack = new ListStack<GraphVertex>();

            VisitVertex(visit);
            stack.Push(visit);

            while (_lists[(int) visit].ReadFirst())
            {
                GraphVertex next = _lists[(int) visit].CurrentNode.Data;
                bool visited = false;

                if (next == vertex2)
                {
                    InitializeVisitInformation();
                    return true;
                }

                if (VisitVertex(next))
                {
                    stack.Push(visit);
                    visit = next;
                    visited = true;
                }
                else
                {
                    while (_lists[(int) visit].ReadNext())
                    {
                        next = _lists[(int) visit].CurrentNode.Data;

                        if (next == vertex2)
                        {
                            InitializeVisitInformation();
                            return true;
                        }

                        if (!VisitVertex(next)) continue;

                        stack.Push(visit);
                        visit = next;
                        visited = true;
                        break;
                    }
                }

                if (visited) continue;
                if (stack.IsEmpty()) break;

                visit = stack.Pop();
            }

            InitializeVisitInformation();

            return false;
        }

        private void RemoveEdge(GraphVertex from, GraphVertex to)
        {
            RemoveWayEdge(from, to);
            RemoveWayEdge(to, from);

            EdgeCount--;
        }

        private void RemoveWayEdge(GraphVertex fromVertex, GraphVertex toVertex)
        {
            int fromVertexInt = (int) fromVertex;

            if (!_lists[fromVertexInt].ReadFirst()) return;

            GraphVertex vertex = _lists[fromVertexInt].CurrentNode.Data;

            if (vertex == toVertex)
            {
                _lists[fromVertexInt].RemoveData(vertex);
                return;
            }

            while (_lists[fromVertexInt].ReadNext())
            {
                vertex = _lists[fromVertexInt].CurrentNode.Data;

                if (vertex != toVertex) continue;

                _lists[fromVertexInt].RemoveData(vertex);
                return;
            }
        }

        public void ShowVertexGraphWithBreadth(GraphVertex vertexStart)
        {
            Console.Write(vertexStart + "부터 탐색 : ");

            GraphVertex vertexVisit = vertexStart;

            VisitVertex(vertexVisit);

            ListBasedQueue<GraphVertex> queue = new ListBasedQueue<GraphVertex>();

            while (_lists[(int) vertexVisit].ReadFirst())
            {
                GraphVertex vertexNext = _lists[(int) vertexVisit].CurrentNode.Data;

                if (VisitVertex(vertexNext))
                {
                    queue.Enqueue(vertexNext);
                }

                while (_lists[(int) vertexVisit].ReadNext())
                {
                    vertexNext = _lists[(int)vertexVisit].CurrentNode.Data;

                    if (VisitVertex(vertexNext))
                    {
                        queue.Enqueue(vertexNext);
                    }
                }

                if (queue.IsEmpty()) break;
                
                vertexVisit = queue.Dequeue();
            }

            Console.WriteLine();

            InitializeVisitInformation();
        }

        public void ShowVertexGraphWithDepth(GraphVertex vertexStart)
        {
            Console.Write(vertexStart+"부터 탐색 : ");

            GraphVertex vertexVisit = vertexStart;

            VisitVertex(vertexVisit);

            ListStack<GraphVertex> stack = new ListStack<GraphVertex>();

            stack.Push(vertexVisit);

            while (_lists[(int)vertexVisit].ReadFirst())
            {
                bool visitFlag = false;
                var vertexNext = _lists[(int)vertexVisit].CurrentNode.Data;

                if (VisitVertex(vertexNext))
                {
                    stack.Push(vertexVisit);

                    vertexVisit = vertexNext;
                    visitFlag = true;
                }
                else
                {
                    while (_lists[(int) vertexVisit].ReadNext())
                    {
                        vertexNext = _lists[(int) vertexVisit].CurrentNode.Data;

                        if (!VisitVertex(vertexNext)) continue;

                        stack.Push(vertexVisit);

                        vertexVisit = vertexNext;
                        visitFlag = true;
                        break;
                    }
                }

                if (visitFlag) continue;
                if (stack.IsEmpty()) break;

                vertexVisit = stack.Pop();
            }

            Console.WriteLine();

            InitializeVisitInformation();
        }

        private bool VisitVertex(GraphVertex vertex)
        {
            int vertexInt = (int) vertex;

            if (_visitInformation[vertexInt] != 0) return false;

            _visitInformation[vertexInt] = 1;

            Console.Write(vertex);

            return true;
        }

        public void ShowEdgeInformation()
        {
            for (int i = 0; i < VertexCount; i++)
            {
                char edge = (char) (i + 65);

                Console.Write(edge+"와 연결된 정점 : ");

                var list = _lists[i];

                if (!list.ReadFirst()) continue;

                Console.Write(list.CurrentNode.Data);

                while (list.ReadNext())
                {
                    Console.Write(",");
                    Console.Write(list.CurrentNode.Data);
                }
                Console.WriteLine();
            }
        }

        private void InitializeVisitInformation()
        {
            for (int i = 0; i < VertexCount; i++)
            {
                _visitInformation[i] = 0;
            }
        }

        public void DestroyGraph()
        {
            for (int i = 0; i < VertexCount; i++)
            {
                _lists[i] = new SimpleLinkedList<GraphVertex>();
                _visitInformation[i] = 0;
            }
        }
    }
}
