using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    // Simple implementation of a Binary Heap
    // It has to be a complete binary tree
    // It has to satisfy the heap property

    // https://en.wikipedia.org/wiki/Binary_heap
    // https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.priorityqueue-2?view=net-6.0

    internal class MaxHeap
    {

        private int[] heap;
        private int size;

        public MaxHeap(int capacity)
        {
            heap = new int[capacity];
            size = 0;
        }


        public void Insert(int value)
        {
            if (IsFull())
            {
                throw new Exception("Max Heap Is Full");
            }

            heap[size] = value;
            FixHeapAbove(size);
            size++;
        }

        public int Delete(int index)
        {
            if (IsEmpty())
            {
                throw new Exception("Max Heap Is Empty");
            }
            int parent = GetParent(index);
            int deletedItem = heap[index];
            heap[index] = heap[size - 1];
            if (index == 0 || heap[index] < heap[GetParent(index)])
            {
                FixHeapBellow(index, size - 1);
            }
            else
            {
                FixHeapAbove(index);
            }
            size--;
            return deletedItem;
        }

        public int Peek()
        {
            if (IsEmpty())
            {
                throw new Exception("Max Heap Is Empty");
            }
            return heap[0];
        }


        public bool IsEmpty()
        {
            return size == 0;
        }

        public bool IsFull()
        {
            return size == heap.Length;
        }


        // We know the root has the largest value
        // Swap the root with last element int the array
        // Heapify the tree, but exclude the last node
        // After heapify, second largest element is at the root
        // Rinse and repeat

        //== once sorted you no longer have a heap ==
        public void Sort()
        {
            int lastHeapIndex = size - 1;
            for (int i = 0; i < lastHeapIndex; i++)
            {
                int temp = heap[0];
                heap[0] = heap[lastHeapIndex - i];
                heap[lastHeapIndex - i] = temp;

                FixHeapBellow(0, lastHeapIndex - i - 1);
            }
        }

        public void Print()
        {
            Console.Write("Heap = [");
            for (int i = 0; i < size; i++)
            {
                Console.Write((i < size - 1) ? heap[i] + ", " : heap[i] + "]\n");
            }
        }


        //== private methods == 
        private int GetParent(int index)
        {
            return (index - 1) / 2;
        }

        private int GetChild(int index, bool left)
        {
            return 2 * index + (left ? 1 : 2);
        }

        private void FixHeapAbove(int index)
        {
            int newValue = heap[index];
            while (index > 0 && newValue > heap[GetParent(index)])
            {
                heap[index] = heap[GetParent(index)];
                index = GetParent(index);
            }
            heap[index] = newValue;
        }

        private void FixHeapBellow(int index, int lastHeapIndex)
        {
            int childToSwap;

            while (index <= lastHeapIndex)
            {
                int leftChild = GetChild(index, true);
                int rightChild = GetChild(index, false);
                if (leftChild <= lastHeapIndex)
                {
                    if (rightChild > lastHeapIndex)
                    {
                        childToSwap = leftChild;
                    }
                    else
                    {
                        childToSwap = heap[leftChild] > heap[rightChild] ? leftChild : rightChild;
                    }


                    if (heap[index] < heap[childToSwap])
                    {
                        int temp = heap[index];
                        heap[index] = heap[childToSwap];
                        heap[childToSwap] = temp;
                    }
                    else
                    {
                        break;
                    }
                    index = childToSwap;
                }
                else
                {
                    break;
                }
            }
        }

    }
}
