using System.Collections.Generic;

public class Solution
{
    public int FindDuplicate(int[] nums)
    {
        var set = new HashSet<int>();

        foreach (var num in nums)
        {
            if (set.Contains(num))
            {
                return num;
            }

            set.Add(num);
        }

        return -1;
    }
}