using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    internal class StackArrayImpl
    {

        private int top;
        private int[] stack;

        public StackArrayImpl() : this(10)
        {
        }

        public StackArrayImpl(int capacity)
        {
            ValidateCapacity(capacity);
            top = 0;
            stack = new int[capacity];
        }

        public void push(int value)
        {
            if (IsEligibleToResize())
            {
                DoubleStackSize();
            }
            stack[top++] = value;
        }

        public int pop()
        {
            if (IsEmpty())
            {
                throw new Exception("Empty stack exception");
            }
            int valueToPop = stack[top - 1];
            stack[top - 1] = 0;
            top--;
            return valueToPop;
        }

        public int peek()
        {
            if (IsEmpty())
            {
                throw new Exception("Empty stack exception");
            }
            return stack[top - 1];
        }

        public bool IsEmpty()
        {
            return top == 0;
        }

        public int size()
        {
            return top;
        }

        public void print()
        {
            for (int i = top - 1; i >= 0; i--)
            {
                Console.WriteLine("[ " + stack[i] + " ]");
            }
        }


        private bool IsEligibleToResize()
        {
            return top == stack.Length;
        }

        private void DoubleStackSize()
        {
            int[] newStack = new int[stack.Length * 2];
            for (int i = 0; i < top; i++)
            {
                newStack[i] = stack[i];
            }
            stack = newStack;
        }

        private void ValidateCapacity(int capacity)
        {
            if (capacity < 1)
            {
                throw new Exception("Wrong capacity");
            }
        }

    }
}
