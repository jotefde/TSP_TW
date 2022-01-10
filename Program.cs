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
            graph.GenerateOptimal(10, 200);
            PrintAdj(graph);
            graph.FillGraph(0.77f);
            PrintAdj(graph);
        }
    }
}
