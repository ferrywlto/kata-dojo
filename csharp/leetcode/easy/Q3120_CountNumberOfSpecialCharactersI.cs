public class Q3120_CountNumberOfSpecialCharactersI
{
    public int NumberOfSpecialChars(string word)
    {
        return 0;
    }
    public static TheoryData<string, int> TestData => new()
    {
        {"aaAbcBC", 3},
        {"abc", 0},
        {"abBCab", 1},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = NumberOfSpecialChars(input);
        Assert.Equal(expected, actual);
    }
}