public class Solution
{
    public int MinOperations(int[] nums)
    {
        var result = 0;
        var n = nums.Length;

        while (true)
        {
            var count = 0;
            var countZero = 0;

            for (var i = 0; i < n; i++)
            {
                if (nums[i] % 2 != 0)
                {
                    nums[i] -= 1;
                    result++;
                }
                else
                {
                    count++;
                }

                if (nums[i] == 0)
                {
                    countZero++;
                }
            }

            if (countZero == n)
            {
                return result;
            }

            if (count == n)
            {
                result++;

                for (int i = 0; i < n; i++)
                {
                    nums[i] /= 2;
                }
            }
        }

        return result;
    }
}