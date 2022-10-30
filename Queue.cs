using System;
using System.Collections.Generic;
using System.Text;

namespace DSA
{
    public class Queue<T>
    {
        private int Size { get; set; }

        public Arrray<T> Array { get; set; }

        public int Count { get; set; }

        private int Last { get; set; }

        public Queue(int size)
        {
            Array = new Arrray<T>(size);
            Size = size;
            Count = 0;
            Last = -1;
        }

        public void AddQueue(T value)
        {
            Last++;
            Array.AddLast(value);
            Count++;
        }

        public T DeQueue()
        {
            var value = Array.RemoveFirst();
            Count--;
            Last--;
            return value;
        }

        public T Peek()
        {
            return Array.Peek();
        }
    }
}
