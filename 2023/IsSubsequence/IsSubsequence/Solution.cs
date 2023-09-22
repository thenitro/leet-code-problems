public class Solution
{
    public bool IsSubsequence(string s, string t)
    {
        if (string.IsNullOrEmpty(s))
        {
            return true;
        }
        
        var indexS = 0;
        var indexT = 0;

        while (indexS < s.Length && indexT < t.Length)
        {
            if (s[indexS] == t[indexT])
            {
                indexS++;
            }

            indexT++;
            
            if (indexS >= s.Length)
            {
                return true;
            }
        }
        
        return false;
    }
}