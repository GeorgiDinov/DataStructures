using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    internal class BSTree
    {

        private BSTNode root;

        public BSTree()
        {
            root = null;
        }

        public void Insert(int data)
        {
            if (root == null)
            {
                root = new BSTNode(data);
            }
            root.Insert(data);
        }

        public BSTNode Get(int data)
        {
            if (root == null)
            {
                throw new Exception("Empty tree!");
            }
            return root.Get(data);
        }

        public void Delete(int data)
        {
            root = Delete(root, data);
        }

        private BSTNode Delete(BSTNode subtreeRoot, int data)
        {
            if (subtreeRoot == null)
            {
                return subtreeRoot;
            }

            if (data < subtreeRoot.Data)
            {
                subtreeRoot.LeftChild = Delete(subtreeRoot.LeftChild, data);
            }
            else if (data > subtreeRoot.Data)
            {
                subtreeRoot.RightChild = Delete(subtreeRoot.RightChild, data);
            }
            else
            {
                // we are at the node which we want to delete
                // first we handle cases where we have only one or no children
                // and replace the deleted node with one or the other, or null if there is no children
                if (subtreeRoot.LeftChild == null)
                {
                    return subtreeRoot.RightChild;
                }
                if (subtreeRoot.RightChild == null)
                {
                    return subtreeRoot.LeftChild;
                }

                // if we get to here we know that the node we want to delete has two children
                // we have to pick replacement node for the one we want to delete and preserve the BSTree
                // we either take the minimum node of the right child, or the maximum node of the left child
                // set the value of the picked node for replacement to the one we want to delete, and then delete the replacing node from the tree
                subtreeRoot.Data = subtreeRoot.RightChild.Min();
                Delete(subtreeRoot.RightChild, subtreeRoot.Data);
            }
            return subtreeRoot;
        }

        public int Min()
        {
            if (root == null)
            {
                throw new Exception("Empty tree!");
            }
            return root.Min();
        }

        public int Max()
        {
            if (root == null)
            {
                throw new Exception("Empty tree!");
            }
            return root.Max();
        }

        public void TraverseInOrder()
        {
            if (root == null)
            {
                throw new Exception("Empty tree!");
            }
            root.TraverseInOrder();
            Console.WriteLine();
        }

        public void TraversePreOrder()
        {
            if (root == null)
            {
                throw new Exception("Empty tree!");
            }
            root.TraversePreOrder();
            Console.WriteLine();
        }

        public void TraversePostOrder()
        {
            if (root == null)
            {
                throw new Exception("Empty tree!");
            }
            root.TraversePostOrder();
            Console.WriteLine();
        }
    }
}
