using System;

namespace FindServersThatHandledMostNumberOfRequests
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(string.Join(",", new Solution().BusiestServers(3, new []{1,2,3,4,5}, new []{5,2,3,3,3})));// [ 1 ]
            Console.WriteLine(string.Join(",", new Solution().BusiestServers(2, new []{2,3,4,8}, new []{3,2,4,3})));// [ 1 ];
            Console.WriteLine(string.Join(",", new Solution().BusiestServers(7, new []{1,3,4,5,6,11,12,13,15,19,20,21,23,25,31,32}, new []{9,16,14,1,5,15,6,10,1,1,7,5,11,4,4,6})));// [ 0 ];
        }
    }
}