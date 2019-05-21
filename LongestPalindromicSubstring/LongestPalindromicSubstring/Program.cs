using System;
using System.Diagnostics;
using System.Linq;

namespace LongestPalindromicSubstring
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("babad bab {0}", new Solution().LongestPalindrome("babad"));
            Console.WriteLine("cbbd bb {0}", new Solution().LongestPalindrome("cbbd"));
            Console.WriteLine("a a {0}", new Solution().LongestPalindrome("a"));
            Console.WriteLine("bb bb {0}", new Solution().LongestPalindrome("bb"));
            Console.WriteLine("abba abba {0}", new Solution().LongestPalindrome("abba"));
            
            var time = new Stopwatch();
            time.Start();

            new Solution().LongestPalindrome(
                "civilwartestingwhetherthatnaptionoranynartionsoconceivedandsodedicatedcanlongendureWeareqmetonagreatbattlefiemldoftzhatwarWehavecometodedicpateaportionofthatfieldasafinalrestingplaceforthosewhoheregavetheirlivesthatthatnationmightliveItisaltogetherfangandproperthatweshoulddothisButinalargersensewecannotdedicatewecannotconsecratewecannothallowthisgroundThebravelmenlivinganddeadwhostruggledherehaveconsecrateditfaraboveourpoorponwertoaddordetractTgheworldadswfilllittlenotlenorlongrememberwhatwesayherebutitcanneverforgetwhattheydidhereItisforusthelivingrathertobededicatedheretotheulnfinishedworkwhichtheywhofoughtherehavethusfarsonoblyadvancedItisratherforustobeherededicatedtothegreattdafskremainingbeforeusthatfromthesehonoreddeadwetakeincreaseddevotiontothatcauseforwhichtheygavethelastpfullmeasureofdevotionthatweherehighlyresolvethatthesedeadshallnothavediedinvainthatthisnationunsderGodshallhaveanewbirthoffreedomandthatgovernmentofthepeoplebythepeopleforthepeopleshallnotperishfromtheearth");
            
            time.Stop();
            
            Console.WriteLine("Elapsed={0}", time.Elapsed);
            
            var time2 = new Stopwatch();
            time2.Start();

            new Solution().LongestPalindrome(
                "vaomxdtiuwqlwhgutkhxxhccsgvyoaccuicgybnqnslogtqhblegfudagpxfvjdacsxgevvepuwthdtybgflsxjdmmfumyqgpxatvdypjmlapccaxwkuxkilqqgpihyepkilhlfkdrbsefinitdcaghqmhylnixidrygdnzmgubeybczjceiybowglkywrpkfcwpsjbkcpnvfbxnpuqzhotzspgebptnhwevbkcueyzecdrjpbpxemagnwmtwikmkpqluwmvyswvxghajknjxfazshsvjkstkezdlbnkwxawlwkqnxghjzyigkvqpapvsntojnxlmtywdrommoltpbvxwqyijpkirvndwpgufgjelqvwffpuycqfwenhzrbzbdtupyutgccdjyvhptnuhxdwbmdcbpfvxvtfryszhaakwshrjseonfvjrrdefyxefqfvadlwmedpvnozobftnnsutegrtxhwitrwdpfienhdbvvykoynrsbpmzjtotjxbvemgoxreiveakmmbbvbmfbbnyfxwrueswdlxvuelbkrdxlutyukppkzjnmfmclqpkwzyylwlzsvriwomchzzqwqglpflaepoxcnnewzstvegyaowwhgvcwjhbbstvzhhvghigoazbjiikglbqlxlccrwqvyqxpbtpoqjliziwmdkzfsrqtqdkeniulsavsfqsjwnvpprvczcujihoqeanobhlsvbzmgflhykndfydbxatskf");
            
            time2.Stop();
            
            Console.WriteLine("Elapsed={0}", time2.Elapsed);
        }
    }
}

public class SolutionSlow {
    private bool IsPalindrome(string s)
    {
        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] != s[s.Length - 1 - i])
            {
                return false;
            }
        }

        return true;
    }
    
    public string LongestPalindrome(string s)
    {
        var longestPalindrome = string.Empty;
        
        for (var i = 0; i < s.Length; i++)
        {
            for (var j = i; j < s.Length; j++)
            {
                var str = s.Substring(i, j - i + 1);
                
                if (IsPalindrome(str))
                {
                    if (str.Length > longestPalindrome.Length)
                    {
                        longestPalindrome = str;
                    }
                }
            }
        }

        return longestPalindrome;
    }
}

public class Solution {
    
    public string LongestPalindrome(string s)
    {
        if (string.IsNullOrEmpty(s) || s.Length == 1)
        {
            return s;
        }

        var start = 0;
        var maxLen = 0;
        for (var i = 0; i < s.Length; i++)
        {
            var len1 = Expand(s, i, i);
            var len2 = Expand(s, i, i + 1);
            
            var len = Math.Max(len1, len2);
            
            if (len > maxLen)
            {
                start = i - (len - 1) / 2;
                maxLen = len;
            }
        }

        return s.Substring(start, maxLen);
    }

    private int Expand(string s, int left, int right)
    {
        var l = left;
        var r = right;

        while (l >= 0 && r < s.Length && s[l] == s[r])
        {
            l--;
            r++;
        }

        return r - l - 1;
    }
}