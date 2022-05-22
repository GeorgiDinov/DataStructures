using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    internal class StackListImpl
    {

        DoublyLinkedList linkedList;

        public StackListImpl()
        {
            linkedList = new DoublyLinkedList();
        }

        public void Push(int value)
        {
            linkedList.AddFirst(value);
        }

        public int Pop()
        {
            return linkedList.RemoveFirst();
        }

        public int Peek()
        {
            return linkedList.GetFirst();
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
