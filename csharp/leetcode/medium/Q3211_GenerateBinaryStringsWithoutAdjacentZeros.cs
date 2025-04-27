public class Q3211_GenerateBinaryStringsWithoutAdjacentZeros
{
    public IList<string> ValidStrings(int n)
    {
        return [];
    }
    public static TheoryData<int, string[]> TestData => new()
    {
        {3, ["010","011","101","110","111"]},
        {1, ["0","1"]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, string[] expected)
    {
        var actual = ValidStrings(input);
        Assert.Equal(expected, actual);
    }
}