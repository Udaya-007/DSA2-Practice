using System;
using System.Collections.Generic;
using System.Text;

namespace DSA
{
    public class GenericLinkedList<T>
    {
        private class Node
        {
            public T Value;
            public Node Next;
            public Node Previous;

            public Node(T value)
            {
                this.Value = value;
            }
        }

        private Node First;
        private Node Last;

        public void AddLast(T item)
        {
            var node = new Node(item);

            if (IsEmpty())
                First = Last = node;
            else
            {
                //var previous = Last;
                node.Previous = Last;
                Last.Next = node;
                Last = node;
                //Last.Previous = previous;
            }
        }

        public void AddFirst(T item)
        {
            var node = new Node(item);

            if (IsEmpty())
                First = Last = node;
            else
            {
                First.Previous = node;
                node.Next = First;
                //First.Previous = node;
                First = node;
            }
        }

        public void DeleteFirst()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            if (First == Last)
            {
                First = Last = null;
                return;
            }

            var second = First.Next;
            First.Next = null;
            second.Previous = null;
            First = second;
        }

        public void DeleteLast()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            if (First == Last)
            {
                First = Last = null;
                return;
            }

            //Last = GetPreviousNode(Last);
            //Last.Next = null;

            DeleteLastNode();
        }

        private bool IsEmpty()
        {
            return First == null;
        }

        public int IndexOf(T item)
        {
            int index = 0;
            var current = First;
            while (current != null)
            {
                if(item.Equals(current.Value))
                //if (current.Value == item)
                    return index;

                current = current.Next;
                index++;
            }
            return -1;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        private void DeleteLastNode()
        {
            var current = First;
            Node lastBefore = null;
            while (current.Next != null)
            {
                lastBefore = current;
                current = current.Next;
            }

            lastBefore.Next = null;
            Last.Previous = null;
            Last = lastBefore;
        }

        private Node GetPreviousNode(Node node)
        {
            var current = First;
            while (current != null)
            {
                if (node == current.Next)
                    return current;
                else
                    current = current.Next;
            }

            throw new NullReferenceException();
        }

        public void Reverse()
        {
            var current = First;
            Node previous = null;
            Node temp = null;

            while (current != null)
            {
                temp = current.Next;
                if (previous == null) Last = current;
                current.Next = previous;
                previous = current;
                previous.Previous = temp;
                current = temp;
            }

            First = previous;
        }

        public void OddEvenList()
        {
            // ListNode oddIdxListFirst = head;
            var oddIdxListLast = First;
            var evenIdxListFirst = First.Next;
            var evenIdxListLast = First.Next;
            var current = First.Next.Next;
            var currIdx = 3;

            while (current != null)
            {
                if (currIdx % 2 == 0)
                {
                    evenIdxListLast.Next = current;
                    evenIdxListLast = evenIdxListLast.Next;
                }
                else
                {
                    oddIdxListLast.Next = current;
                    oddIdxListLast = oddIdxListLast.Next;
                }

                current = current.Next;
                currIdx++;
            }

            oddIdxListLast.Next = evenIdxListFirst;
            //Last = evenIdxListLast;

            //return First;
        }
    }
}
