using System;
using System.Collections.Generic;

namespace ImplementStackUsingQueues
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var stack = new MyStack();

            stack.Push(1);
            stack.Push(2);
            Console.WriteLine(2 == stack.Top()); // returns 2
            Console.WriteLine(2 == stack.Pop()); // returns 2
            Console.WriteLine(1 == stack.Top()); // returns 1
            Console.WriteLine(false == stack.Empty()); // returns false
        }
    }

    public class MyStack
    {
        private Queue<int> _queue;
        private int _last;
        
        /** Initialize your data structure here. */
        public MyStack()
        {
            _queue = new Queue<int>();
        }

        /** Push element x onto stack. */
        public void Push(int x)
        {
            _last = x;
            
            var count = _queue.Count;
            _queue.Enqueue(x);

            while (count > 0)
            {
                _queue.Enqueue(_queue.Dequeue());
                count--;
            }
        }

        /** Removes the element on top of the stack and returns that element. */
        public int Pop()
        {
            if (_queue.Count > 0)
            {
                return _queue.Dequeue();
            }

            return 0;
        }

        /** Get the top element. */
        public int Top()
        {
            if (_queue.Count > 0)
            {
                var last = _queue.Dequeue();
                
                Push(last);
                
                return last;
            }
            
            return 0;
        }

        /** Returns whether the stack is empty. */
        public bool Empty()
        {
            return _queue.Count == 0;
        }
    }
}