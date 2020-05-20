using System;
using System.Collections.Generic;

namespace FindMedianFromDataStream
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var finder = new MedianFinder();

            finder.AddNum(1);
            finder.AddNum(2);
            Console.WriteLine(finder.FindMedian() == 1.5);
            finder.AddNum(3);
            Console.WriteLine(finder.FindMedian() == 2);
            
            var finder2 = new MedianFinder();

            finder2.AddNum(-1);
            finder2.AddNum(-2);
            Console.WriteLine(finder2.FindMedian() == -1.5);
            finder2.AddNum(-3);
            Console.WriteLine(finder2.FindMedian() == -2);
            
        }
    }
}

public class MedianFinder
{
    private List<int> _list;

    public MedianFinder()
    {
        _list = new List<int>();
    }

    public void AddNum(int num)
    {
        if (_list.Count == 0)
        {
            _list.Add(num);
            return;
        }
        
        var index = 0;

        while (index < _list.Count && _list[index] > num)
        {
            index++;
        }
        
        _list.Insert(index, num);
    }

    public double FindMedian()
    {
        var N = _list.Count;
        var N2 = N / 2;

        return N % 2 == 0 ? (_list[N2 - 1] + _list[N2]) / 2.0 : _list[N2];
    }
}