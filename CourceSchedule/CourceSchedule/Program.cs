using System;
using System.Collections.Generic;

namespace CourseSchedule
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(new Solution().CanFinish(2, new int[][] {new int[] {1, 0}}));
            Console.WriteLine(new Solution().CanFinish(2, new int[][] {new int[] {1, 0}, new int[] {0, 1}}));
        }
    }

    public class Solution
    {
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            var matrix = new int[numCourses, numCourses];
            var indegree = new int[numCourses];

            for (var i = 0; i < prerequisites.Length; i++)
            {
                int ready = prerequisites[i][0];
                int pre = prerequisites[i][1];

                if (matrix[pre, ready] == 0)
                {
                    indegree[ready]++;
                }

                matrix[pre, ready] = 1;
            }

            var count = 0;

            var queue = new Queue<int>();
            for (int i = 0; i < indegree.Length; i++)
            {
                if (indegree[i] == 0)
                {
                    queue.Enqueue(i);
                }
            }

            while (queue.Count > 0)
            {
                var course = queue.Dequeue();
                count++;
                for (var i = 0; i < numCourses; i++)
                {
                    if (matrix[course, i] != 0)
                    {
                        if (--indegree[i] == 0)
                        {
                            queue.Enqueue(i);
                        }
                    }
                }
            }

            return count == numCourses;
        }
    }
}