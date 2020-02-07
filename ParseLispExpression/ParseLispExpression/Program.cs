using System;
using System.Collections.Generic;
using System.Text;

namespace ParseLispExpression
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(3 == new Solution().Evaluate("(add 1 2)"));
            Console.WriteLine(15 == new Solution().Evaluate("(mult 3 (add 2 3))"));
            Console.WriteLine(10 == new Solution().Evaluate("(let x 2 (mult x 5))"));
            Console.WriteLine(14 == new Solution().Evaluate("(let x 2 (mult x (let x 3 y 4 (add x y))))"));
            Console.WriteLine(2 == new Solution().Evaluate("(let x 3 x 2 x)"));
        }
    }
}

public class Solution
{
    private List<Dictionary<string, int>> _scope = new List<Dictionary<string, int>>();

    public Solution()
    {
        _scope.Add(new Dictionary<string, int>());
    }

    public int Evaluate(string expression)
    {
        _scope.Add(new Dictionary<string, int>());
        var result = EvaluateInner(expression);
        _scope.RemoveAt(_scope.Count - 1);
        
        return result;
    }

    private int EvaluateInner(string expression)
    {
        if (expression[0] != '(')
        {
            if (Char.IsDigit(expression[0]) || expression[0] == '-')
            {
                return int.Parse(expression);
            }

            for (var i = _scope.Count - 1; i >= 0; i--)
            {
                if (_scope[i].ContainsKey(expression))
                {
                    return _scope[i][expression];
                }
            }
        }

        var start = expression[1] == 'm' ? 6 : 5;
        var end = expression.Length - start - 1;
        
        var tokens = Parse(expression.Substring(start, end));

        if (expression.StartsWith("(add"))
        {
            return Evaluate(tokens[0]) + Evaluate(tokens[1]);
        } 
        else if (expression.StartsWith("(mult"))
        {
            return Evaluate(tokens[0]) * Evaluate(tokens[1]);
        }
        else
        {
            for (var j = 1; j < tokens.Count; j += 2)
            {
                if (_scope[_scope.Count - 1].ContainsKey(tokens[j - 1]))
                {
                    _scope[_scope.Count - 1][tokens[j - 1]] = Evaluate(tokens[j]);
                }
                else
                {
                    _scope[_scope.Count - 1].Add(tokens[j - 1], Evaluate(tokens[j]));
                }
                
            }

            return Evaluate(tokens[tokens.Count - 1]);
        }
    }

    private List<string> Parse(string expression)
    {
        var result = new List<string>();
        var balance = 0;

        var sb = new StringBuilder();

        foreach (var token in expression.Split(' '))
        {
            foreach (var character in token)
            {
                if (character == '(')
                {
                    balance++;
                }

                if (character == ')')
                {
                    balance--;
                }
            }

            if (sb.Length > 0)
            {
                sb.Append(" ");
            }

            sb.Append(token);

            if (balance == 0)
            {
                result.Add(sb.ToString());
                sb.Clear();
            }
        }

        if (sb.Length > 0)
        {
            result.Add(sb.ToString());
        }

        return result;
    }
}