using System;

namespace TSP_TW
{
    internal class Program
    {
        public static void PrintAdj(Graph graph)
        {
            Console.WriteLine();
            var adjMatrix = graph.ToAdjMatrix();
            for (int i = 0; i < graph.Nodes.Count; i++)
            {
                for (int j = 0; j < graph.Nodes.Count; j++)
                    Console.Write(adjMatrix[i, j] + ", ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            var graph = new Graph();
            graph.GenerateOptimal(5, 200);
            PrintAdj(graph);
            graph.FillGraph(0.77f);
            PrintAdj(graph);
            var greedy = new Greedy(graph);
            var v = graph.Nodes.ConvertAll(x => false).ToArray();
            v[0] = true;
            (bool[] solution, int ans) = greedy.Solve(graph.ToAdjMatrix(), v, 0, 1, 0, graph.Edges[0].Time, 200);
        }
    }
}
