public class Q3803_CountResiduePrefixes
{
    public int ResiduePrefixes(string s)
    {
        return 0;
    }
    public static TheoryData<string, int> TestData => new()
    {
        {"abc", 2},
        {"dd", 1},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = ResiduePrefixes(input);
        Assert.Equal(expected, actual);
    }
}
