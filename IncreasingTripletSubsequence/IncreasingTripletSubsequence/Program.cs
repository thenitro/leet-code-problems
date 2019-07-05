using System;
using System.Runtime.InteropServices.WindowsRuntime;

namespace IncreasingTripletSubsequence
{
	internal class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine(true == new Solution().IncreasingTriplet(new []{ 1, 2, 3, 4, 5 }));
			Console.WriteLine(false == new Solution().IncreasingTriplet(new []{ 5, 4, 3, 2, 1 }));
			Console.WriteLine(true == new Solution().IncreasingTriplet(new []{ 2, 1, 5, 0, 4, 6 }));
			Console.WriteLine(true == new Solution().IncreasingTriplet(new []{ 5, 1, 5, 5, 2, 5, 4 }));
			Console.WriteLine(false == new Solution().IncreasingTriplet(new []{ 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 }));
		}
	}
}

public class Solution {
 	public bool IncreasingTriplet(int[] nums)
    {
	    var c1 = int.MaxValue;
	    var c2 = int.MaxValue;

	    for (var i = 0; i < nums.Length; i++)
	    {
		    var x = nums[i];

		    if (x <= c1)
		    {
			    c1 = x;
		    }
		    else if (x <= c2)
		    {
			    c2 = x;
		    }
		    else
		    {
			    return true;
		    }
		}

	    return false;
    }
 }