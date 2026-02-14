public class Q2185_CountingWordsWithGivenPrefix
{
    // TC: O(n), n scale with length of words
    // SC: O(1), space used does not scale with input
    public int PrefixCount(string[] words, string pref)
    {
        var pfxLen = pref.Length;
        var result = 0;
        foreach (var w in words)
        {
            if (w.Length < pfxLen) continue;
            else if (w[..pfxLen] == pref) result++;
        }
        return result;
    }
    public static List<object[]> TestData =>
    [
        [new string[] { "pay", "attention", "practice", "attend" }, "at", 2],
        [new string[] { "leetcode","win","loops","success" }, "code", 0],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] input, string prefix, int expected)
    {
        var actual = PrefixCount(input, prefix);
        Assert.Equal(expected, actual);
    }
}
