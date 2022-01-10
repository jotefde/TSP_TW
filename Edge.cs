using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP_TW
{
    public class Edge
    {
        public int Time;
        public Node A;
        public Node B;
        public static int Count = 0;

        public Edge(Node a, Node b, int time)
        {
            A = a;
            B = b;
            Time = time;
            Edge.Count++;
        }

        public Node SecondNode(Node node)
        {
            if (node == A)
                return B;
            else
                return A;
        }

        public bool ContainsNode(Node node)
        {
            return node == B || node == A;
        }
    }

    public class EdgeTimeComp : Comparer<Edge>
    {
        // Compares by Length, Height, and Width.
        public override int Compare(Edge x, Edge y)
        {
            return x.Time.CompareTo(y.Time);
        }
    }
}

