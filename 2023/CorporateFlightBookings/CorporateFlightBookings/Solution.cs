public class Solution {
    public int[] CorpFlightBookings(int[][] bookings, int n)
    {
        var result = new int[n];

        foreach (var booking in bookings)
        {
            var start = booking[0];
            var end = booking[1];
            var seats = booking[2];

            for (var j = start - 1; j < end; j++)
            {
                if (j > n - 1)
                {
                    continue;
                }
                
                result[j] += seats;
            }
        }
        
        return result;
    }
}