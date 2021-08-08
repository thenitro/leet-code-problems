using System.Collections.Generic;

namespace DotProductOfTwoSparseVectors
{
    internal class Program
    {
        public static void Main(string[] args)
        {
        }
    }
}

public class SparseVector
{
    private Dictionary<int, int> _nums = new Dictionary<int, int>();

    public SparseVector(int[] nums)
    {
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] > 0)
            {
                _nums[i] = nums[i];
            }
        }
    }

    // Return the dotProduct of two sparse vectors
    public int DotProduct(SparseVector vec)
    {
        var merged = new HashSet<int>();

        foreach (var num in _nums)
        {
            if (vec._nums.ContainsKey(num.Key))
            {
                merged.Add(num.Key);
            }
        }
        
        foreach (var num in vec._nums)
        {
            if (_nums.ContainsKey(num.Key))
            {
                merged.Add(num.Key);
            }
        }

        var result = 0;

        foreach (var i in merged)
        {
            result += _nums[i] * vec._nums[i];
        }

        return result;
    }
}

// Your SparseVector object will be instantiated and called as such:
// SparseVector v1 = new SparseVector(nums1);
// SparseVector v2 = new SparseVector(nums2);
// int ans = v1.DotProduct(v2);