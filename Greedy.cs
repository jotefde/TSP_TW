using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP_TW
{
    public class Greedy
    {
        Graph problem;
        public Greedy(Graph graph)
        {
            problem = graph;
        }

        List<Node> SolveRec(List<Node> path, int time)
        {
            Node current = path.FirstOrDefault();
            List<Edge> possibleEdges = problem.Edges.FindAll(edge => edge.ContainsNode(current));
            possibleEdges.Sort(new EdgeTimeComp());

            foreach(Edge edge in possibleEdges)
            {
                Edge lowerestCostEdge = possibleEdges.FirstOrDefault();
                Node nextNode = lowerestCostEdge.SecondNode(current);
                if (nextNode.IsVisited == false)
                {
                    nextNode.IsVisited = true;
                    // ??
                    SolveRec(path, time);
                }

            }    
        }

        public (bool[], int) Solve(int[,] adj, bool[] v,
                    int currentIndex, int n,
                    int count, int cost, int ans)
        {
            if (count == n && adj[currentIndex, 0] > 0)
            {
                ans = Math.Min(ans, cost + adj[currentIndex, 0]);
                return (v, ans);
            }

            for (int i = 0; i < n; i++)
            {
                if (v[i] == false && adj[currentIndex, i] > 0)
                {

                    // odwiedziony
                    v[i] = true;
                    (bool[] newV, int newAns) = Solve(adj, v, i, n, count + 1,
                              cost + adj[currentIndex, i], ans);
                    ans = newAns;
                    // odznacz
                    v[i] = false;
                }
            }
            return (v, ans);
        }
    }
}
