using System;
using System.Collections.Generic;

namespace ImplementQueueUsingStack
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            MyQueue queue = new MyQueue();

            queue.Push(1);
            queue.Push(2);
            Console.WriteLine(queue.Peek()); // returns 1
            Console.WriteLine(queue.Pop()); // returns 1
            Console.WriteLine(queue.Empty()); // returns false
        }
    }
}

public class MyQueue
{
    private Stack<int> _stack;

    /** Initialize your data structure here. */
    public MyQueue()
    {
        _stack = new Stack<int>();
    }

    /** Push element x to the back of queue. */
    public void Push(int x)
    {
        var stackB = new Stack<int>();

        while (_stack.Count > 0)
        {
            stackB.Push(_stack.Pop());
        }
        
        _stack.Push(x);

        while (stackB.Count > 0)
        {
            _stack.Push(stackB.Pop());
        }
    }

    /** Removes the element from in front of queue and returns that element. */
    public int Pop()
    {
        return _stack.Pop();
    }

    /** Get the front element. */
    public int Peek()
    {
        return _stack.Peek();
    }

    /** Returns whether the queue is empty. */
    public bool Empty()
    {
        return _stack.Count == 0;
    }
}

/**
 * Your MyQueue object will be instantiated and called as such:
 * MyQueue obj = new MyQueue();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Peek();
 * bool param_4 = obj.Empty();
 */