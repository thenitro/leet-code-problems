using System;
using System.Collections.Generic;

//namespace MinStack
//{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var minStack = new MinStack();
            minStack.Push(-2);
            minStack.Push(0);
            minStack.Push(-3);
            Console.WriteLine(-3 == minStack.GetMin());
            minStack.Pop();
            Console.WriteLine(0 == minStack.Top());
            Console.WriteLine(-2 == minStack.GetMin());
        }
    }
//}

public class MinStack
{

    private List<int> _stack;
    private int _min;
    
    /** initialize your data structure here. */
    public MinStack() {
        _stack = new List<int>();
        _min = int.MaxValue;
    }
    
    public void Push(int x) {
        _stack.Add(x);

        if (_min > x)
        {
            _min = x;
        }
    }
    
    public void Pop() {
        if (_stack.Count == 0)
        {
            return;
        }

        var invalidateMin = Top() == _min;
        
        _stack.RemoveAt(_stack.Count - 1);

        if (invalidateMin)
        {
            _min = int.MaxValue;

            for (int i = 0; i < _stack.Count; i++)
            {
                if (_min > _stack[i])
                {
                    _min = _stack[i];
                }
            }
        }
    }
    
    public int Top()
    {
        if (_stack.Count == 0)
        {
            return 0;
        }
        
        return _stack[_stack.Count - 1];
    }
    
    public int GetMin()
    {
        return _min;
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(x);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */