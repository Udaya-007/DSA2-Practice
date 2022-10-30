using System;
using System.Collections.Generic;
using System.Text;

namespace DSA
{
    public class Stack<T>
    {
        private int Size { get; set; }

        private T[] Array { get; set; }

        public int Count { get; set; }

        private int Top { get; set; }

        public Stack(int size)
        {
            Array = new T[size];
            Size = size;
            Count = 0;
            Top = -1;
        }

        public void Push(T value)
        {
            Top++;
            Array[Top] = value;
            Count++;
        }

        public T Pop()
        {
            T topValue = Array[Top];
            Top--;
            Count--;

            return topValue;
        }

        public T Peek()
        {
            return Array[Top];
        }
    }
}
