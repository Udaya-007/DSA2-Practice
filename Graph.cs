using System;
using System.Collections;
using cg = System.Collections.Generic;
using System.Collections.Generic;
using System.Text;

namespace DSA
{
    public class Graph<TKey>
    {
        public Dictionary<TKey, List<TKey>> AdjacencyList { get; set; }

        public Graph(Dictionary<TKey, List<TKey>> adjacencyList)
        {
            AdjacencyList = adjacencyList;
        }

        public  List<TKey> List { get; set; }

        public List<TKey> DfsIterative(TKey source)
        {
            var stk = new cg.Stack<TKey>();
            List = new List<TKey>();
            stk.Push(source);
            var visited = new HashSet<TKey>();

            while(stk.Count > 0)
            {
                TKey currentNode = stk.Pop();
                visited.Add(currentNode);
                List.Add(currentNode);
                foreach (var item in AdjacencyList[currentNode])
                {
                    if(!visited.Contains(item))
                        stk.Push(item);
                }
            }

            return List;
        }

        public List<TKey> DfsRecursive(TKey source)
        {
            List = new List<TKey>();
            var visited = new HashSet<TKey>();
            DfsRecursion(source, visited);

            return List;
        }

        internal void DfsRecursion(TKey source, HashSet<TKey> visited)
        {
            List.Add(source);
            visited.Add(source);
            foreach(var item in AdjacencyList[source])
            {
                if (!visited.Contains(item))
                    DfsRecursion(item, visited);
            }
        }

        public List<TKey> BredthFirstSearch(TKey source)
        {
            var que = new cg.Queue<TKey>();
            List = new List<TKey>();
            var visited = new HashSet<TKey>();
            que.Enqueue(source);

            while (que.Count > 0)
            {
                TKey currentNode = que.Dequeue();
                List.Add(currentNode);
                visited.Add(currentNode);
                foreach (var item in AdjacencyList[currentNode])
                {
                    if (!visited.Contains(item))
                        que.Enqueue(item);
                }
            }

            return List;

        }

        public bool HasPath(TKey source, TKey dest)
        {
            var visited = new HashSet<TKey>();
            return HasPathInternal(source, dest, visited);
        }

        private bool HasPathInternal(TKey source, TKey dest, HashSet<TKey> visited)
        {
            if (source.Equals(dest)) return true;
            if (visited.Contains(source)) return false;

            visited.Add(source);


            foreach(var ngbr in AdjacencyList[source])
            {
                if(HasPathInternal(ngbr, dest, visited)) return true;
            }

            return false;
        }
    }
}
