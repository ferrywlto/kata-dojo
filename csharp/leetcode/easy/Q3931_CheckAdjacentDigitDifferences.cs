public class Q3931_CheckAdjacentDigitDifferences
{
    // TC: O(n), n scale with length of s
    // SC: O(1), space used does not scale with input
    public bool IsAdjacentDiffAtMostTwo(string s)
    {
        for (var i = 0; i < s.Length - 1; i++)
        {
            if (Math.Abs(s[i] - s[i + 1]) > 2) return false;
        }
        return true;
    }

    public static TheoryData<string, bool> TestData => new() { { "132", true }, { "129", false } };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, bool expected)
    {
        var actual = IsAdjacentDiffAtMostTwo(input);
        Assert.Equal(expected, actual);
    }
}
