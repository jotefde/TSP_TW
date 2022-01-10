using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP_TW
{
    public class Graph
    {
        public List<Edge> Edges;
        public List<Node> Nodes;
        public int MaxTime;
        public int RestTime;
        public Node this[int index] { get => Nodes[index]; }
        public Graph()
        {
            Edges = new List<Edge>();
            Nodes = new List<Node>();
        }

        public void ResetNodes()
        {
            foreach(var node in Nodes)
            {
                node.IsVisited = false;
            }
        }
        public bool EdgeExists(Node A, Node B)
        {
            var found = Edges.Find(edge =>
            {
                return (edge.A == A && edge.B == B) || (edge.A == B && edge.B == A);
            });
            return found != null;
        }

        public void AddEdge(Node A, Node B, int distance)
        {
            Edges.Add(new Edge(A, B, distance));
        }

        public void GenerateOptimal(int vCount, int totalTime = 0)
        {
            MaxTime = totalTime;
            for (int i = 0; i < vCount; i++)
                Nodes.Add(new Node());
            var rand = new Random();
            for (int i = 0; i < vCount - 1; i++)
            {
                Edges.Add(new Edge(Nodes[i], Nodes[i + 1], 1));
            }
            Edges.Add(new Edge(Nodes[vCount - 1], Nodes[0], 1));

            // rozw opt
            var timeCounter = 0;
            var avgEdgeTime = MaxTime / Edges.Count;
            foreach (var edge in Edges)
            {
                var time = rand.Next(1, avgEdgeTime);
                if (timeCounter + time > MaxTime)
                    break;
                edge.Time = time;
                timeCounter += time;
            }
            RestTime = MaxTime - timeCounter;
            Console.WriteLine("timeCounter: " + timeCounter);

            // generacja okien czasowych
            int currentTime = 0;
            foreach(var edge in Edges)
            {
                int start = rand.Next(currentTime/2,currentTime);
                int limitEnd = (MaxTime - currentTime) / 2;
                int end = rand.Next(currentTime,currentTime + limitEnd);
                edge.A.TimeWindow = (start, end);
                currentTime += edge.Time;
            }
        }

        public void FillGraph(float eSat)
        {
            var completeSat = Nodes.Count * (Nodes.Count - 1) / 2; //liczba krawędzi w grafie pełnym;
            var expCount = completeSat * eSat;
            var rand = new Random();
            var remGraph = GenerateComplete();
            remGraph.RemoveAll(edge => EdgeExists(edge.A, edge.B));
            while (Edges.Count < expCount)
            {
                var randEdgeIndex = rand.Next(0, remGraph.Count - 1);
                Edges.Add(remGraph[randEdgeIndex]);
                remGraph.RemoveAt(randEdgeIndex);
            }
        }

        public List<Edge> GenerateComplete()
        {
            List<Edge> completeGraph = new List<Edge>();
            var minEdgeTime = Edges.Sum(edge => edge.Time) / Nodes.Count;
            var rand = new Random();
            for (var i = 0; i < Nodes.Count - 1; i++)
            {
                for (var j = i + 1; j < Nodes.Count; j++)
                {
                    var edgetime = rand.Next(minEdgeTime, RestTime / 2);
                    completeGraph.Add(new Edge(Nodes[i], Nodes[j], edgetime));
                }
            }
            return completeGraph;
        }

        public void PrintEdges()
        {
            foreach(var edge in Edges)
            {
                Console.WriteLine(edge.Time);
            }
        }
        public void PrintIncMatrix()
        {
            int[][] matrix = new int[Node.Count][];
            for(int x = 0; x < Node.Count; x++)
            {
                matrix[x] = new int[Edges.Count];
                for(int y = 0; y < Edges.Count; y++)
                {
                    matrix[x][y] = 0;
                }
            }

            for(int i = 0; i < Edges.Count; i++)
            {
                var edge = Edges[i];
                matrix[edge.A.ID][i] = 1;
                matrix[edge.B.ID][i] = 1;
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                for(int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j] + ",");
                }
                Console.WriteLine();
            }
        }

        public int[,] ToAdjMatrix()
        {
            int[,] matrix = new int[Node.Count, Node.Count];
            foreach (var edge in Edges)
            {
                matrix[edge.A.ID, edge.B.ID] = edge.Time;
                matrix[edge.B.ID, edge.A.ID] = edge.Time;
            }
            return matrix;
        }
    }
}
