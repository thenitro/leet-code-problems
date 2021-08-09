using System;
using System.Collections.Generic;

namespace ExclusiveTimeOfFunctions
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var result = new Solution().ExclusiveTime(2,
                new List<string>() { "0:start:0", "1:start:2", "1:end:5", "0:end:6" });
            Console.WriteLine(3 == result[0]);
            Console.WriteLine(4 == result[1]);
        }
    }
}

public class Solution
{
    public int[] ExclusiveTime(int n, IList<string> logs)
    {
        var stack = new Stack<LogEvent>();

        var result = new int[n];
        var prev = 0;

        foreach (var log in logs)
        {
            var entry = new LogEvent(log);

            if (stack.Count == 0)
            {
                stack.Push(entry);
                prev = entry.Time;
                continue;
            }

            if (entry.Type == "start")
            {
                var interval = entry.Time - prev;
                result[stack.Peek().Id] += interval;
                stack.Push(entry);
                prev = entry.Time;
            }
            else
            {
                var interval = entry.Time - prev + 1;
                result[stack.Pop().Id] += interval;
                prev = entry.Time + 1;
            }
        }

        return result;
    }

    private class LogEvent
    {
        public int Id;
        public string Type;
        public int Time;

        public LogEvent(string entry)
        {
            var splitted = entry.Split(':');
            
            Id = int.Parse(splitted[0]);
            Type = splitted[1];
            Time = int.Parse(splitted[2]);
        }
    }
}