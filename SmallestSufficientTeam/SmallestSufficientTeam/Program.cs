using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SmallestSufficientTeam
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(string.Join(", ", new Solution().SmallestSufficientTeam(new []{ "java", "nodejs", "reactjs"}, new List<IList<string>>()
            {
                new List<string>() { "java" },
                new List<string>() { "nodejs" },
                new List<string>() { "nodejs", "reactjs" },
            })));
            
            Console.WriteLine(string.Join(", ", new Solution().SmallestSufficientTeam(new []{ "algorithms", "math", "java", "reactjs", "csharp", "aws"}, new List<IList<string>>()
            {
                new List<string>() { "algorithms", "math", "java" },
                new List<string>() { "algorithms", "math", "reactjs" },
                new List<string>() { "java", "csharp", "aws" },
                new List<string>() { "reactjs", "csharp" },
                new List<string>() { "csharp", "math" },
                new List<string>() { "aws", "java" },
            })));
        }
    }
}

public class Solution
{
    public int[] SmallestSufficientTeam(string[] req_skills, IList<IList<string>> people)
    {
        var sLen = req_skills.Length;
        var pLen = people.Count;
        
        var skMap = new Dictionary<string, int>();
        for (var i = 0; i < sLen; i++)
        {
            skMap.Add(req_skills[i], i);
        }

        var skillArr = new HashSet<int>[1 << sLen];
            skillArr[0] = new HashSet<int>();

        for (var ppl = 0; ppl < pLen; ppl++)
        {
            var pplSkill = 0;

            for (var j = 0; j < people[ppl].Count; j++)
            {
                pplSkill |= 1 << (skMap[people[ppl][j]]);
            }

            for (var k = 0; k < skillArr.Length; k++)
            {
                if (skillArr[k] == null)
                {
                    continue;
                }

                var currSkills = skillArr[k];

                var combined = k | pplSkill;
                if (combined == k)
                {
                    continue;
                }

                if (skillArr[combined] == null || skillArr[combined].Count > currSkills.Count + 1)
                {
                    var cSkills = new HashSet<int>(currSkills);
                        cSkills.Add(ppl);

                        skillArr[combined] = cSkills;
                }
            }
        }

        var resSet = skillArr[(1 << sLen) - 1];
        var res = new int[resSet.Count];
        var pos = 0;

        foreach (var value in resSet)
        {
            res[pos++] = value;
        }

        return res;
    }
}