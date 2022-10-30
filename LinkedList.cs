using System;
using System.Collections.Generic;
using System.Text;

namespace DSA
{
    public class LinkedList
    {
        private class Node
        {
            public int Value;
            public Node Next;
            public Node Previous;

            public Node(int value)
            {
                this.Value = value;
            }
        }

        private Node First;
        private Node Last;

        public void AddLast(int item)
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

        public void AddFirst(int item)
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

        public int IndexOf(int item)
        {
            int index = 0;
            var current = First;
            while (current != null)
            {
                if (current.Value == item)
                    return index;

                current = current.Next;
                index++;
            }
            return -1;
        }

        public bool Contains(int item)
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
                if(node == current.Next)
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

            while(current != null)
            {
                var temp = current.Next;
                current.Next = previous;
                previous = current;
                current = temp;
            }

            First = previous;
        }
    }
}
