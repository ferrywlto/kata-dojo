public class Q3760_MaxSubstringWithDistinctStart
{
    public int MaxDistinct(string s)
    {
        return 0;
    }
    public static TheoryData<string, int> TestData => new TheoryData<string, int>
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
