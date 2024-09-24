using System.Text;
public class Q1961_CheckIfStringIsPrefixOfArray
{
    // TC: O(n), n scale with length of s
    // SC: O(n), n scale with length of s, worst case the size of string builder will be the same as s
    public bool IsPrefixString(string s, string[] words)
    {
        var sb = new StringBuilder();
        var idx = 0;
        foreach(var w in words)
        {
            sb.Append(w);
            if (sb.Length > s.Length) return false;
            for(var i=idx; i<idx+w.Length; i++)
            {
                if (s[i] != sb[i]) return false;
                if (i == s.Length - 1) return true;
            }
            idx += w.Length;
        }
        return sb.Length == s.Length;
    }

    public static List<object[]> TestData =>
    [
        ["iloveleetcode", new string[] {"i","love","leetcode","apples"}, true],
        ["iloveleetcode", new string[] {"i","love","orange","apples"}, false],
        ["iloveleetcode", new string[] {"apples","i","love","leetcode"}, false],
        ["a", new string[] {"aa","aaaa","banana"}, false],
        ["ccccccccc", new string[] {"c","cc"}, false],
    ];

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string[] words, bool expected)
    {
        var actual = IsPrefixString(input, words);
        Assert.Equal(expected, actual);
    }
}