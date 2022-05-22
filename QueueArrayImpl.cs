using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    internal class QueueArrayImpl
    {

        private int[] queue;
        private int front;
        private int back;

        public QueueArrayImpl(int capacity)
        {
            if (capacity <= 0)
            {
                queue = new int[10];
            }
            else
            {
                queue = new int[capacity];
            }
            front = 0;
            back = 0;
        }

        public void Add(int value)
        {
            if (Size() == queue.Length - 1)
            {
                int[] replacingQueue = new int[2 * queue.Length];
                int numElements = Size();
                if (IsNotWrapped())
                {
                    Array.Copy(queue, front, replacingQueue, 0, back);
                }
                else
                {
                    Array.Copy(queue, front, replacingQueue, 0, queue.Length - front);
                    Array.Copy(queue, 0, replacingQueue, queue.Length - front, back);
                }
                queue = replacingQueue;
                front = 0;
                back = numElements;
            }
            queue[back] = value;
            if (back == queue.Length - 1)
            {
                back = 0;
            }
            else
            {
                back++;
            }
        }

        public int Remove()
        {
            if (Size() == 0)
            {
                throw new Exception("Empty Queue!");
            }
            int value = queue[front];
            queue[front] = 0;
            front++;
            if (Size() == 0)
            {
                front = 0;
                back = 0;
            }
            if (front == queue.Length)
            {
                front = 0;
            }
            return value;
        }

        public int Peek()
        {
            if (Size() == 0)
            {
                throw new Exception("Empty Queue!");
            }
            return queue[front];
        }


        public void Print()
        {
            if (IsNotWrapped())
            {
                for (int i = front; i < back; i++)
                {
                    Console.WriteLine(queue[i]);
                }
            }
            else
            {
                for (int i = front; i < queue.Length; i++)
                {
                    Console.WriteLine(queue[i]);
                }
                for (int i = 0; i < back; i++)
                {
                    Console.WriteLine(queue[i]);
                }
            }
        }

        public int Size()
        {
            if (IsNotWrapped())
            {
                return back - front;
            }
            else
            {
                return (back - front) + queue.Length;
            }
        }

        private bool IsNotWrapped()
        {
            return front <= back;
        }

    }
}
