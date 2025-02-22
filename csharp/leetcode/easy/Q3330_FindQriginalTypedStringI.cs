public class Q3330_FindQriginalTypedStringI
{
    public int PossibleStringCount(string word)
    {
        return 0;
    }
    public static TheoryData<string, int> TestData => new()
    {
        {"abbcccc", 5},
        {"abcd", 1},
        {"aaaa", 4},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = PossibleStringCount(input);
        Assert.Equal(expected, actual);
    }
}