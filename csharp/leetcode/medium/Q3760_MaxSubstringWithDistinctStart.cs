public class Q3760_MaxSubstringWithDistinctStart
{
    // TC: O(n), n scale with length of s
    // SC: O(1), space used does not scale with input
    public int MaxDistinct(string s)
    {
        var frequencies = new int[26];
        var max = 0;
        foreach (var c in s)
        {
            var idx = c - 'a';
            if (frequencies[idx] == 0)
            {
                frequencies[idx]++;
                max++;
                if (max == 26) return 26;
            }
        }
        return max;
    }
    public static TheoryData<string, int> TestData => new()
    {
        {"abab", 2},
        {"abcd", 4},
        {"aaaa", 1},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = MaxDistinct(input);
        Assert.Equal(expected, actual);
    }
}
