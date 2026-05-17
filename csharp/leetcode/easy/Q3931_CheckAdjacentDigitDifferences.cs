public class Q3931_CheckAdjacentDigitDifferences
{
    public bool IsAdjacentDiffAtMostTwo(string s)
    {
        return false;
    }

    public static TheoryData<string, bool> TestData => new() { { "132", true }, { "129", false } };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, bool expected)
    {
        var actual = IsAdjacentDiffAtMostTwo(input);
        Assert.Equal(expected, actual);
    }
}
