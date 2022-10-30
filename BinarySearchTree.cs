using System;
using System.Collections.Generic;
using System.Text;

namespace DSA
{
    public class BinarySearchTree<T>
    {
        private TreeNode<T> Root { get; set; }

        internal int Size { get; set; }


        private class TreeNode<T>
        {
            internal int Index { get; set; }

            internal T Value { get; set; }

            internal TreeNode<T> LeftChild { get; set; }

            internal TreeNode<T> RightChild { get; set; }

            public TreeNode(int index, T Value)
            {
                this.Index = index;
                this.Value = Value; 
            }
        }

        public BinarySearchTree()
        {
            Root = null;
        }

        public BinarySearchTree(int Index, T Value)
        {
            Root = new TreeNode<T>(Index, Value);
        }

        public void InsertNode(int Index, T Value)
        {
            Root = InsertChild(Root, Index, Value);
        }

        private TreeNode<T> InsertChild(TreeNode<T> node, int Index, T Value)
        {
            if(node == null)
            {
                node = new TreeNode<T>(Index, Value);
                //return node;
            }
            else if(Index < node.Index)
            {
                node.LeftChild = InsertChild(node.LeftChild, Index, Value);
            }
            else
            {
                node.RightChild = InsertChild(node.RightChild, Index, Value);   
            }

            Size++;
            return node;
        }

        public T Find(int Index)
        {
            var valueNode = FindChild(Root, Index);
            return valueNode == null ? default : valueNode.Value;
        }

        private TreeNode<T> FindChild(TreeNode<T> node, int Index)
        {
            TreeNode<T> valueNode = null;

            if(node == null || Index == node.Index)
            {
                valueNode = node;
            }
            else if(Index < node.Index)
            {
                valueNode = FindChild(node.LeftChild, Index);
            }
            else
            {
                valueNode = FindChild(node.RightChild, Index);
            }

            return valueNode;
        }


        #region Depth First Search

        internal List<T> array { get; set; }

        public List<T> InorderTraversal()
        {
            array = new List<T>();
            Inorder(Root);

            return array;
        }

        private void Inorder(TreeNode<T> node)
        {
            if(node != null)
            {
                Inorder(node.LeftChild);
                array.Add(node.Value);
                Inorder(node.RightChild);
            }
        }

        public List<T> PreorderTraversal()
        {
            array = new List<T>();
            Preorder(Root);

            return array;
        }

        private void Preorder(TreeNode<T> node)
        {
            if (node != null)
            {
                array.Add(node.Value);
                Preorder(node.LeftChild);
                Preorder(node.RightChild);
            }
        }

        public List<T> PostorderTraversal()
        {
            array = new List<T>();
            Postorder(Root);

            return array;
        }

        private void Postorder(TreeNode<T> node)
        {
            if (node != null)
            {
                Postorder(node.LeftChild);
                Postorder(node.RightChild);
                array.Add(node.Value);
            }
        }

        #endregion
    }
}
