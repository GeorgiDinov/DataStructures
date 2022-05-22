using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    internal class QueueListImpl
    {

        DoublyLinkedList linkedList;

        public QueueListImpl()
        {
            linkedList = new DoublyLinkedList();
        }

        public void Add(int value)
        {
            linkedList.AddFirst(value);
        }

        public int Remove()
        {
            return linkedList.RemoveLast();
        }

        public int Peek()
        {
            return linkedList.GetLast();
        }

        public bool IsEmpty()
        {
            return linkedList.IsEmpty();
        }

        public int Size()
        {
            return linkedList.Size();
        }
    }
}
