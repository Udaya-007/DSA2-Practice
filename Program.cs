using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace DSA
{
    class Program
    {
        static void Main(string[] args)
        {
            //Array
            //var arr = new Arrray<int>(55);

            //  for(var i= arr.size/2; i>0; i--)
            //  {
            //      arr.AddFirst(i);
            //  }

            //  var lengthAfterAddFirst = arr.GetLength();

            //  for (var i = arr.GetLength() + 2; i <= arr.size; i++)
            //  {
            //      arr.AddLast(i);
            //  }

            //arr.AddAtIndex(lengthAfterAddFirst + 1, lengthAfterAddFirst);

            //var stk = new Queue<string>(9);

            //stk.AddQueue("A");
            //stk.AddQueue("B");
            //stk.DeQueue();

            //stk.AddQueue("C");
            //stk.AddQueue("D");    
            //stk.AddQueue("E");
            //stk.AddQueue("F");           
            //stk.AddQueue("G");
            //stk.AddQueue("H");

            //var peek = stk.Peek();

            //var count = stk.Count;

            //var ind = BinarySearch<string>(stk.Array.arr, "C");

            //var bst = new BinarySearchTree<string>();

            //var value = bst.Find(31);

            //value = bst.Find(31);

            //var inorderArr = bst.InorderTraversal();
            //var preorderArr = bst.PreorderTraversal();
            //var postorderArr = bst.PostorderTraversal();

            //var arr = BubbleSort(new int[] { 5,9,2,4,11,33,1});

            //var fact = Factorial(4);

            // graph
            //Dictionary<string, List<string>> adjList = new Dictionary<string, List<string>>();
            //adjList.Add("a",new List<string> { "b", "c" });
            //adjList.Add("b",new List<string> { "d", "a" });
            //adjList.Add("c",new List<string> { "e", "a" });
            //adjList.Add("d",new List<string> { "f", "b"});
            //adjList.Add("e",new List<string> { "c"});
            //adjList.Add("f",new List<string> { "d"});
            //adjList.Add("g",new List<string>());

            //var graph = new Graph<string>(adjList);

            //var dfsI = graph.DfsIterative("a");
            //var dfsR = graph.DfsRecursive("a");
            //var bfs = graph.BredthFirstSearch("a");

            //Console.WriteLine(graph.HasPath("f", "e"));


            //Merge Sort

            //int[] arr1 = new int[] { 1, 3, 5, 7, 9 };

            //int[] arr2 = new int[] { 2, 4, 6, 8, 10 };

            //var mArr = Merge(arr1, arr2);

            //int[] arr3 = new int[] { 199, 100, 89, 78, 67, 56, 45, 34, 23, 12, 1 };

            //var msort = MergeSort(arr3);




            // Linked List
            var linkList = new GenericLinkedList<int>();

            linkList.AddFirst(1);
            linkList.AddFirst(2);
            linkList.AddFirst(3);
            linkList.AddFirst(4);
            linkList.AddFirst(5);
            linkList.AddFirst(6);
            linkList.AddFirst(7);
            linkList.AddFirst(8);
            linkList.AddFirst(9);
            linkList.AddFirst(10);

            linkList.Reverse();
            linkList.OddEvenList();

            Console.WriteLine("Hello");
        }



        // Algorithms
        static int BinarySearch<T>(T[] arr, T value) where T : IComparable
        {
            Array.Sort(arr, StringComparer.InvariantCulture);
            var start = 0;
            var end = arr.Length - 1;

            while (start < end)
            {
                var mid = (start + end) / 2;

                if (value.CompareTo(arr[mid]) == 0)
                {
                    return mid;
                }
                else if (value.CompareTo(arr[mid]) < 0)
                {
                    end = mid;
                }
                else if (value.CompareTo(arr[mid]) > 0)
                {
                    start = mid + 1;
                }
            }
            return -1;
        }

        static int[] BubbleSort(int[] array)
        {
            int temp;

            for (var i = 0; i < array.Length; i++)
            {
                for (var j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        temp = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = temp;
                    }
                }
            }

            return array;
        }

        // Recursion
        static int Factorial(int n)
        {
            if(n > 1)
            {
                n *= Factorial(n - 1);
            }

            return n;
        }

        // Merge two Sorted Lists
        static int[] Merge(int[] arr1, int[] arr2)
        {
            var i = 0;
            var j = 0;
            var r = 0;
            var returnArr = new int[arr1.Length + arr2.Length];

            while(i < arr1.Length && j < arr2.Length)
            {
                if(arr2[j] < arr1[i])
                {
                    returnArr[r] = arr2[j];
                    j++;
                } 
                else
                {
                    returnArr[r] = arr1[i];
                    i++;
                }
                r++;
            }

            for(; i < arr1.Length; i++)
            {
                returnArr[r] = arr1[i];
                r++;
            }

            for (; j < arr2.Length; j++)
            {
                returnArr[r] = arr2[j];
                r++;
            }

            return returnArr;
        }

        // Merge Sort
        static int[] MergeSort(int[] arr)
        {
            if (arr.Length > 1)
            {
                int q = (arr.Length) / 2;
                var a1 = MergeSort(arr[..q]);
                var a2 = MergeSort(arr[q..]);
                return Merge(a1, a2);
            }

            return arr;
        }
    }
}
