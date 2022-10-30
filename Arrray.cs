using System;
using System.Collections.Generic;
using System.Text;

namespace DSA
{
    public class Arrray<T>
    {
        private int Length { get; set; }
        public T[] arr { get; set; }

        public int size { get; }

        public Arrray(int n)
        {
            arr = new T[n];
            size = n;
        }

        public int GetLength()
        {
            return Length;
        }

        public void AddFirst(T val)
        {
            if (Length == 0)
            {
                arr[Length] = val;
                Length++;
            }
            else
            {
                for(var i = Length-1; i >= 0; i--)
                {
                    arr[i + 1] = arr[i];
                }

                arr[0] = val;
                Length++;
            }
        }

        public void AddLast(T val)
        {
            arr[Length] = val;
            Length++;
        }

        public void AddAtIndex(T val, int index)
        {
            if (Length <= index)
            {
                arr[index] = val;
                Length++;
            }
            else
            {
                for (var i = Length - 1; i >= index; i--)
                {
                    arr[i + 1] = arr[i];
                }

                arr[index] = val;
                Length++;
            }
        }

        public T RemoveFirst()
        {
            var value = arr[0];

            for (var i = 0; i < Length - 1; i++)
            {
                arr[i] = arr[i + 1];
            }

            Length--;

            return value;
        }

        public T Peek()
        {
            return arr[0];
        }


    }
}
