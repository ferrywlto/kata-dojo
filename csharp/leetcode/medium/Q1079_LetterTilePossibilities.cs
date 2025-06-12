public class Q1079_LetterTilePossibilities
{
    public int NumTilePossibilities(string tiles)
    {
        return 0;
    }
    public static TheoryData<string, int> TestData => new()
    {
        {"AAB", 8},
        {"AAABBC", 188},
        {"V", 1},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = NumTilePossibilities(input);
        Assert.Equal(expected, actual);
    }
}