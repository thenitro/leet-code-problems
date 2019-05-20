namespace TwoSum
{
    internal class Program
    {
        public static void Main(string[] args)
        {
        }

        public int[] TwoSum(int[] nums, int target)
        {
            for (var i = 0; i < nums.Length; i++)
            {
                for (var j = 0; j < nums.Length; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    var num1 = nums[i];
                    var num2 = nums[j];

                    if (num1 + num2 == target)
                    {
                        return new int[] {i , j};
                    }
                }
            }

            return null;
        }
    }
}