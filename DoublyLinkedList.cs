using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    internal class DoublyLinkedList
    {

        private int size;
        private LinkedListNode head;
        private LinkedListNode tail;

        public DoublyLinkedList()
        {
            size = 0;
            head = null;
            tail = null;
        }

        public void Add(int value)
        {
            AddLast(value);
        }

        public void AddFirst(int value)
        {
            if (head == null)
            {
                head = new LinkedListNode(value);
                tail = head;
            }
            else
            {
                LinkedListNode newNode = new LinkedListNode(value);
                head.Previous = newNode;
                newNode.Next = head;
                head = newNode;
            }
            size++;
        }

        public void AddInOrder(int value)
        {
            if (IsEmpty())
            {
                AddFirst(value);
                return;
            }

            if (value <= head.ValueHolder)
            {
                AddFirst(value);
                return;
            }

            LinkedListNode current = head;
            LinkedListNode next = head.Next;

            while (next != null && value > next.ValueHolder)
            {
                current = current.Next;
                next = next.Next;
            }

            LinkedListNode newNode = new LinkedListNode(value);
            current.Next = newNode;
            newNode.Previous = current;

            newNode.Next = next;
            if (next != null)
            {
                next.Previous = newNode;
            }
            else
            {
                tail = newNode;
            }
            size++;
        }

        public int RemoveFirst()
        {
            if (IsEmpty())
            {
                throw new Exception("Empty List Exception");
            }
            LinkedListNode nodeToRemove = head;
            head = head.Next;
            nodeToRemove.Next = null;
            if (head != null)
            {
                head.Previous = null;
            }
            size--;
            return nodeToRemove.ValueHolder;
        }

        public int GetFirst()
        {
            if (IsEmpty())
            {
                throw new Exception("Empty List Exception");
            }
            return head.ValueHolder;
        }

        public void AddLast(int value)
        {
            if (tail == null)
            {
                tail = new LinkedListNode(value);
                head = tail;
            }
            else
            {
                LinkedListNode newNode = new LinkedListNode(value);
                tail.Next = newNode;
                newNode.Previous = tail;
                tail = newNode;
            }
            size++;
        }

        public void AddLastIterative(int value)
        {
            if (head == null)
            {
                head = new LinkedListNode(value);
                tail = head;
            }
            else
            {
                LinkedListNode current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                LinkedListNode newNode = new LinkedListNode(value);
                current.Next = newNode;
                newNode.Previous = current;
                tail = newNode;
            }
            size++;
        }

        public int RemoveLast()
        {
            if (IsEmpty())
            {
                throw new Exception("Empty List Exception");
            }
            LinkedListNode nodeToRemove = tail;
            tail = tail.Previous;
            nodeToRemove.Previous = null;
            if (tail != null)
            {
                tail.Next = null;
            }
            size--;
            return nodeToRemove.ValueHolder;
        }

        public int GetLast()
        {
            if (IsEmpty())
            {
                throw new Exception("Empty List Exception");
            }
            return tail.ValueHolder;
        }


        public bool Contains(int value)
        {
            if (IsEmpty())
            {
                throw new Exception("Empty List Exception");
            }

            LinkedListNode first = head;
            LinkedListNode last = tail;

            if (first == last)
            {
                return first.ValueHolder == value;
            }

            while (first != last)
            {
                if (first.ValueHolder == value || last.ValueHolder == value)
                {
                    return true;
                }
                first = first.Next;
                last = last.Previous;
            }
            return false;
        }

        public int Size()
        {
            return size;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public void Print()
        {
            LinkedListNode current = head;
            while (current != null)
            {
                Console.Write(current.ValueHolder + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }

    }
}
