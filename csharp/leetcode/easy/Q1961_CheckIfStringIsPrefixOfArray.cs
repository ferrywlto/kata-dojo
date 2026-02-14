using System.Text;
public class Q1961_CheckIfStringIsPrefixOfArray
{
    // TC: O(n), n scale with length of s
    // SC: O(1), space used does not scale with s
    public bool IsPrefixString(string s, string[] words)
    {
        var idx = 0;
        foreach (var w in words)
        {
            foreach (var c in w)
            {
                if (idx >= s.Length || s[idx] != c) return false;
                idx++;
            }
            if (idx == s.Length) return true;
        }
        return idx == s.Length;
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
