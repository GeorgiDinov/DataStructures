using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{

    // Binary search tree consists of three nodes called as follows
    //
    //        (parent)
    //         /    \
    //        /      \
    //(leftChild) (rightChild)
    //
    internal class BSTNode
    {

        private int data;

        public int Data
        {
            get { return data; }
            set { data = value; }
        }

        private BSTNode leftChild;

        public BSTNode LeftChild
        {
            get { return leftChild; }
            set { leftChild = value; }
        }

        private BSTNode rightChild;

        public BSTNode RightChild
        {
            get { return rightChild; }
            set { rightChild = value; }
        }

        public BSTNode(int data)
        {
            this.data = data;
            this.leftChild = null;
            this.rightChild = null;
        }


        public void Insert(int data)
        {
            if (data == this.data)
            {
                return; //not to allow duplicates in this implementation
            }

            if (data < this.data)
            {
                if (leftChild == null)
                {
                    leftChild = new BSTNode(data);
                }
                else
                {
                    leftChild.Insert(data);
                }
            }
            else
            {
                if (rightChild == null)
                {
                    rightChild = new BSTNode(data);
                }
                else
                {
                    rightChild.Insert(data);
                }
            }
        }

        public BSTNode Get(int data)
        {
            if (data == this.data)
            {
                return this;
            }

            if (data < this.data)
            {
                if (leftChild != null)
                {
                    return leftChild.Get(data);
                }
            }
            else
            {
                if (rightChild != null)
                {
                    return rightChild.Get(data);
                }
            }
            return null;
        }

        public int Min()
        {
            return leftChild != null ? leftChild.Min() : data;
        }

        public int Max()
        {
            return rightChild != null ? leftChild.Max() : data;
        }


        //traversals with the respect of when e visit the parent node

        public void TraverseInOrder()// visit leftChild, parent and rightChild
        {
            if (leftChild != null)
            {
                leftChild.TraverseInOrder();
            }

            Console.Write(this);

            if (rightChild != null)
            {
                rightChild.TraverseInOrder();
            }
        }

        public void TraversePreOrder()// visit parent, leftChild and rightChild
        {
            Console.Write(this);

            if (leftChild != null)
            {
                leftChild.TraversePreOrder();
            }

            if (rightChild != null)
            {
                rightChild.TraversePreOrder();
            }
        }

        public void TraversePostOrder()// visit leftChild, rightChild and parent
        {
            if (leftChild != null)
            {
                leftChild.TraversePostOrder();
            }

            if (rightChild != null)
            {
                rightChild.TraversePostOrder();
            }

            Console.Write(this);
        }

        public override string ToString()
        {
            return "(" + data + ")";
        }

    }
}
