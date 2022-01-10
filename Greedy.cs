using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP_TW
{
    internal class Greedy
    {
        Graph problem;
        Greedy(Graph graph)
        {
            problem = graph;
        }
        //List<Node> Solve(Node start, Node current, int time)
        //{   
        //    List<Edge> possibleEdges = new List<Edge>();
        //    possibleEdges = problem.Edges.FindAll(edge => edge.A == current || edge.B == current);
        //    List<Node> solution;

        //    if (current.IsVisited) {
        //        if(start == current)
        //            return new List<Node>(){current};
        //        else
        //            return new List<Node>();
        //    }

        //    foreach (var edge in possibleEdges)
        //    {
        //        if(edge.A != current)
        //        {
        //            solution = Solve(start,edge.A,1);
        //        }
        //        else
        //        {
        //            solution = Solve(start, edge.B,1);
        //        }

                
        //        solution.Add(current);

        //        if (solution.Contains(start) && problem.Nodes.All(n => n.IsVisited))
        //        {
        //            return solution;
        //        }
        //        else
        //        {   
        //            solution.ForEach(n => n.IsVisited = false);
        //            return new List<Node>();
        //        }
        //    }
        //}
        public void Solve(List<Node> path,Node current,int time)
        {

        }
    }
}
