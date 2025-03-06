public class Q3442_MaxDiffBetweenEvenAndOddFrequencyI
{
    public int MaxDifference(string s)
    {
        return 0;
    }
    public static TheoryData<string, int> TestData => new()
    {
        {"aaaaabbc", 3},
        {"abcabcab", 1},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = MaxDifference(input);
        Assert.Equal(expected, actual);
    }
}