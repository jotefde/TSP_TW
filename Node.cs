using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP_TW
{
    public class Node
    {
        public int ID;
        public (int start, int end) TimeWindow;
        public static int Count = 0;
        public bool IsVisited = false;
        public Node()
        {
            ID = Count++;
        }
    }
}
