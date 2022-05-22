using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    internal class LinkedListNode
    {

        private int valueHolder;

        public int ValueHolder
        {
            get { return valueHolder; }
            set { valueHolder = value; }
        }

        private LinkedListNode previous;

        public LinkedListNode Previous
        {
            get { return previous; }
            set { previous = value; }
        }

        private LinkedListNode next;

        public LinkedListNode Next
        {
            get { return next; }
            set { next = value; }
        }

        public LinkedListNode(int value)
        {
            valueHolder = value;
            previous = null;
            next = null;
        }

    }
}
