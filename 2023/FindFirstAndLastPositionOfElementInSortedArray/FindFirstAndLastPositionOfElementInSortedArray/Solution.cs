public class Solution
{
    public int[] SearchRange(int[] nums, int target)
    {
        var result = new int[] { -1, -1 };
        
        var left = 0;
        var right = nums.Length;
        
        while (left < right)
        {
            var middle = left + (right - left) / 2;
            
            if (nums[middle] < target)
            {
                left = middle + 1;
            }
            else if (nums[middle] > target)
            {
                right = middle;
            }
            else
            {
                if (result[0] == -1)
                {
                    if (middle == 0 || nums[middle - 1] != target)
                    {
                        result[0] = middle;
                    }
                    else
                    {
                        left--;
                    }
                }
                else if (result[1] == -1)
                {
                    if (middle == nums.Length - 1 || nums[middle + 1] != target)
                    {
                        result[1] = middle;
                    }
                    else
                    {
                        right++;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        return result;
    }
}