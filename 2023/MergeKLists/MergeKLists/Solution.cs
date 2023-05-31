using System;

public class HeapNode<T>
{
    public int Priority;
    public T Data { get; }
        
    public HeapNode(int priority, T data)
    {
        Priority = priority;
        Data = data;
    }
}

public class MinHeap<T>
{
    private int _count;
    private HeapNode<T>[] _array;

    public MinHeap()
    {
        _count = 0;
        _array = new HeapNode<T>[1];
    }

    public int Count => _count;

    public T Peek()
    {
        return _array[0].Data;
    }

    public void Push(int priority, T data)
    {
        if (_count == _array.Length)
        {
            var newArray = new HeapNode<T>[_count * 2];
            Array.Copy(_array, newArray, _array.Length);
            _array = newArray;
        }

        _count++;
        var i = _count - 1;
        _array[i] = new HeapNode<T>(priority, data);

        while (i != 0 && _array[Parent(i)].Priority > _array[i].Priority)
        {
            Swap(i, Parent(i));
            i = Parent(i);
        }
    }

    public HeapNode<T> Pop()
    {
        if (_count <= 0)
        {
            return default(HeapNode<T>);
        }

        if (_count == 1)
        {
            _count--;
            return _array[0];
        }

        var root = _array[0];
        _array[0] = _array[_count - 1];
        _count--;

        Heapify(0);

        return root;
    }

    public void Decrease(int i, int newI)
    {
        _array[i].Priority = newI;

        while (i != 0 && _array[Parent(i)].Priority > _array[i].Priority)
        {
            Swap(i, Parent(i));
            i = Parent(i);
        }
    }

    public void Delete(int value)
    {
        Decrease(value, int.MinValue);
        Pop();
    }

    private int Parent(int i)
    {
        return (i - 1) / 2;
    }

    private int Left(int i)
    {
        return 2 * i + 1;
    }

    private int Right(int i)
    {
        return 2 * i + 2;
    }

    private void Swap(int i, int j)
    {
        var tmp = _array[i];
        _array[i] = _array[j];
        _array[j] = tmp;
    }

    private void Heapify(int i)
    {
        var l = Left(i);
        var r = Right(i);

        var smallest = i;

        if (l < _count && _array[l].Priority < _array[i].Priority)
        {
            smallest = l;
        }

        if (r < _count && _array[r].Priority < _array[smallest].Priority)
        {
            smallest = r;
        }

        if (smallest != i)
        {
            Swap(i, smallest);
            Heapify(smallest);
        }
    }
}

public class Solution
{
    public ListNode MergeKLists(ListNode[] lists)
    {
        var heap = new MinHeap<ListNode>();

        foreach (var listNode in lists)
        {
            if (listNode == null)
            {
                continue;
            }
            
            heap.Push(listNode.val, listNode);
        }

        ListNode head = null;
        ListNode track = null;

        while (heap.Count > 0)
        {
            var current = heap.Pop().Data;
            
            if (current.next != null)
            {
                heap.Push(current.next.val, current.next);
            }
            
            if (head == null)
            {
                head = current;
                track = current;
            }
            else
            {
                track.next = current;
                track = current;
            }
        }

        return head;
    }
}