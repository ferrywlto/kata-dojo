public class Q3014_MinNumberOfPushesToTypeWordI
{
    public int MinimumPushes(string word)
    {
        return 0;
    }
    public static TheoryData<string, int> TestData => new()
    {
        {"abcde", 5},
        {"xycdefghij", 12},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = MinimumPushes(input);
        Assert.Equal(expected, actual);
    }
}