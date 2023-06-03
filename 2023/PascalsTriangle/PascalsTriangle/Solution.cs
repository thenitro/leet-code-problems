using System.Collections.Generic;

public class Solution
{
    public IList<IList<int>> Generate(int numRows)
    {
        var result = new List<IList<int>>();

        for (var currentRow = 0; currentRow < numRows; currentRow++)
        {
            var subresult = new List<int>();
            
            for (var currentPosition = 0; currentPosition < currentRow + 1; currentPosition++)
            {
                if (currentPosition == 0 || currentPosition == currentRow)
                {
                    subresult.Add(1);
                }
                else
                {
                    subresult.Add(result[currentRow - 1][currentPosition - 1] + result[currentRow - 1][currentPosition]);
                }
            }
            
            result.Add(subresult);
        }

        return result;
    }
}