public class Q3746_MinStringLengthAfterBalancedRemovals
{
    // TC: O(n), n scale with length of s
    // SC: O(n), worst case stack will hold all characters
    public int MinLengthAfterRemovals(string s)
    {
        var len = 1;
        var lastChar = s[0];
        for (var i = 1; i < s.Length; i++)
        {
            if (len > 0 && lastChar != s[i])
            {
                len--;
            }
            else
            {
                lastChar = s[i];
                len++;
            }
        }

        return len;
    }
    public static TheoryData<string, int> TestData => new()
    {
        {"aabbab", 0},
        {"aaaa", 4},
        {"aaabb", 1},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = MinLengthAfterRemovals(input);
        Assert.Equal(expected, actual);
    }
}
