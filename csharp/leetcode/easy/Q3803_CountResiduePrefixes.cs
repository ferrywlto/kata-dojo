public class Q3803_CountResiduePrefixes
{
    // TC: O(n), n scale with length of s
    // SC: O(1)
    public int ResiduePrefixes(string s)
    {
        Span<bool> seen = stackalloc bool[255];
        var distinctCount = 0;

        var set = new HashSet<char>();
        var result = 0;
        for (var i = 0; i < s.Length; i++)
        {
            if (!seen[s[i]])
            {
                distinctCount++;
                seen[s[i]] = true;
            }

            if (distinctCount > 3)
                return result;
            else if (distinctCount == (i + 1) % 3)
                result++;
        }
        return result;
    }
    public static TheoryData<string, int> TestData => new()
    {
        {"abc", 2},
        {"dd", 1},
        {"bob", 2},
        {"bbbb", 2},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = ResiduePrefixes(input);
        Assert.Equal(expected, actual);
    }
}
