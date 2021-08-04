using System;
using System.Collections.Generic;

namespace InsertDeleteGetRandomO1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var set = new RandomizedSet();
            /*set.Insert(1);
            set.Remove(2);
            set.Insert(2);
            set.GetRandom();
            set.Remove(1);
            set.Insert(2);
            set.GetRandom();*/

            Console.WriteLine(false == set.Remove(0));
            Console.WriteLine(false == set.Remove(0));
            Console.WriteLine(true == set.Insert(0));
            Console.WriteLine(0 == set.GetRandom());
            Console.WriteLine(true == set.Remove(0));
            Console.WriteLine(true == set.Insert(0));
        }
    }
}

public class RandomizedSet
{
    private Dictionary<int, Node> _set;
    private Node _head;
    private Node _current;
    private int _count;
    private Random _random;

    /** Initialize your data structure here. */
    public RandomizedSet()
    {
        _set = new Dictionary<int, Node>();
        _head = new Node();
        _current = _head;
        _count = 0;
        _random = new Random();
    }

    /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
    public bool Insert(int val)
    {
        if (_set.ContainsKey(val))
        {
            return false;
        }

        var node = new Node()
        {
            Prev = _current,
            Value = val,
        };

        _current.Next = node;
        _current = node;
        
        _set.Add(val, node);

        _count++;

        return true;
    }

    /** Removes a value from the set. Returns true if the set contained the specified element. */
    public bool Remove(int val)
    {
        if (!_set.ContainsKey(val))
        {
            return false;
        }

        var node = _set[val];
        if (node == _current)
        {
            _current = node.Prev;
        }

        if (node.Prev != null)
        {
            node.Prev.Next = node.Next;
        }

        if (node.Next != null)
        {
            node.Next.Prev = node.Prev;
        }

        _count--;
        _set.Remove(val);
        
        return true;
    }

    /** Get a random element from the set. */
    public int GetRandom()
    {
        var elementIndex = _random.Next(1, _count + 1);
        var node = _head;

        while (elementIndex > 0)
        {
            node = node.Next;
            elementIndex--;
        }

        return node.Value;
    }

    private class Node
    {
        public Node Next;
        public Node Prev;
        public int Value;
    }
}

/**
 * Your RandomizedSet object will be instantiated and called as such:
 * RandomizedSet obj = new RandomizedSet();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */