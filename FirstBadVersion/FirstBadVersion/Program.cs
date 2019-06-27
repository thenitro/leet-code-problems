using System;

namespace FirstBadVersion
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var s = new Solution();
                s.SetBadVersion(4);
                Console.WriteLine(4 == s.FirstBadVersion(5));
                
                s.SetBadVersion(10);
                Console.WriteLine(10 == s.FirstBadVersion(20));
                
                s.SetBadVersion(2126753390);
                Console.WriteLine(4 == s.FirstBadVersion(1702766719));
        }
    }
}

/* The isBadVersion API is defined in the parent class VersionControl.
      bool IsBadVersion(int version); */

public class Solution : VersionControl {
    public int FirstBadVersion(int n) {
        var lo = 1;
        var hi = n;
        
        while (lo < hi) {
            var middle = lo + (hi - lo) / 2;
            if (IsBadVersion(middle))
            {
                hi = middle;
            }
            else
            {
                lo = middle + 1;
            }
        }
        
        return lo;
    }
}

public class VersionControl
{
    private int _badVersion;
    
    public VersionControl()
    {
        
    }

    public void SetBadVersion(int badVersion)
    {
        _badVersion = badVersion;
    }
    
    public bool IsBadVersion(int version)
    {
        return version >= _badVersion;
    }
}