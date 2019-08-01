using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ExpresssionAddOperators
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var result = new Solution().AddOperators("123", 6);
            Console.WriteLine(string.Join(", ", result));

            var result2 = new Solution().AddOperators("232", 8);
            Console.WriteLine(string.Join(", ", result2));

            var result3 = new Solution().AddOperators("105", 5);
            Console.WriteLine("result " + string.Join(", ", result3));

            var result4 = new Solution().AddOperators("00", 0);
            Console.WriteLine(string.Join(", ", result4));

            var result5 = new Solution().AddOperators("3456237490", 9191);
            Console.WriteLine(string.Join(", ", result5));
        }
    }
}

public class Solution
{
    private List<string> _result;
    private string _digits;
    private int _target;
    
    public IList<string> AddOperators(string num, int target)
    {
        _result = new List<string>();
        
        if (num.Length > 0)
        {
            _target = target;
            _digits = num;
            
            AddOperatorsHelper(0, 0, 0, 0, new List<string>());
        }
        
        return _result;
    }

    private void AddOperatorsHelper(int index, int prev, int current, long value, List<string> ops)
    {
        var nums = _digits;

        if (index == nums.Length)
        {
            if (value == _target && current == 0)
            {
                var sb = new StringBuilder();

                for (var i = 1; i < ops.Count; i++)
                {
                    sb.Append(ops[i]);
                }

                var str = sb.ToString();

                if (str != "-2147483648")
                {
                    _result.Add(str);
                }
            }

            return;
        }

        current = current * 10 + (nums[index] - '0');

        var currentStr = current.ToString();
        var length = nums.Length;
        var nextIndex = index + 1;

        if (current > 0)
        {
            AddOperatorsHelper(nextIndex, prev, current, value, ops);
        }
        
        ops.Add("+");
        ops.Add(currentStr);
        AddOperatorsHelper(nextIndex, current, 0, value + current, ops);
        ops.RemoveAt(ops.Count - 1);
        ops.RemoveAt(ops.Count - 1);

        if (ops.Count > 0)
        {
            ops.Add("-");
            ops.Add(currentStr);
            AddOperatorsHelper(nextIndex, -current, 0, value - current, ops);
            ops.RemoveAt(ops.Count - 1);
            ops.RemoveAt(ops.Count - 1);
            
            ops.Add("*");
            ops.Add(currentStr);
            AddOperatorsHelper(nextIndex, current * prev, 0, value - prev + (current * prev), ops);
            ops.RemoveAt(ops.Count - 1);
            ops.RemoveAt(ops.Count - 1);
        }
    }
}