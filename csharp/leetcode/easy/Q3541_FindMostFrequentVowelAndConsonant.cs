public class Q3541_FindMostFrequentVowelAndConsonant
{
    public int MaxFreqSum(string s)
    {
        return 0;
    }
    public static TheoryData<string, int> TestData => new()
    {
        {"successes", 6},
        {"aeiaeia", 3},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = MaxFreqSum(input);
        Assert.Equal(expected, actual);
    }
}