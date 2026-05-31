public class Q3713_LongestBalancedSubstringI
{
    public int LongestBalanced(string s)
    {
        return 0;
    }

    public static TheoryData<string, int> TestData => new()
    {
        { "abbac", 4 },
        { "zzabccy", 4 },
        { "aba", 2 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = LongestBalanced(input);
        Assert.Equal(expected, actual);
    }
}
