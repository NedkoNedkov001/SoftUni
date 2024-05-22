using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool isEmpty()
        {
            return this.Count == 0;
        }
        public void AddRange(IEnumerable<string> collection)
        {
            foreach (var element in collection)
            {
                this.Push(element);
            }
        }
    }
}
