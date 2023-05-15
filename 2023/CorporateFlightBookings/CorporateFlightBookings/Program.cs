using System;

namespace CorporateFlightBookings
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(string.Join(",", new Solution().CorpFlightBookings(new [] { new [] {1, 2, 10}, new []{2,3,20}, new []{2,5,25} }, 5)));
            Console.WriteLine(string.Join(",", new Solution().CorpFlightBookings(new [] { new [] {1, 2, 10}, new []{2,2,15}}, 2)));
        }
    }
}