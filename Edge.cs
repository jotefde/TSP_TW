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
    }
}

