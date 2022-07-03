using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool isEmpty()
        {
            if (Count == 0)
            {
                return true;
            }

            return false;
        }

        public Stack<string> AddRange(IEnumerable<string> collection)
        {
            foreach (string item in collection)
            {
                this.Push(item);
            }

            return this;
        }
    }
}
