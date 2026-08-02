public class Q4006_CountValidPrefixes
{
    // TC: O(n)
    // SC: O(1)
    public int CountValidPrefixes(string s)
    {
        var result = 0;
        // 0 has char code 48
        // 1 has char code 49
        Span<int> counts = stackalloc int[50];

        foreach (var c in s)
        {
            counts[c]++;

            if (Math.Abs(counts[49] - counts[48]) <= 1) result++;
        }
        return result;
    }

    public static TheoryData<string, int> TestData => new()
    {
        { "00101", 3 },
        { "101", 3 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = CountValidPrefixes(input);
        Assert.Equal(expected, actual);
    }
}
