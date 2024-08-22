class Q1704_DetermineIfStringHalvesAreAlike
{
    public bool HalvesAreAlike(string s)
    {
        return false;
    }
}
class Q1704_DetermineIfStringHalvesAreAlikeTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["book", true],
        ["textbook", false],
    ];
}
public class Q1704_DetermineIfStringHalvesAreAlikeTests
{
    [Theory]
    [ClassData(typeof(Q1704_DetermineIfStringHalvesAreAlikeTestData))]
    public void OfficialTestCases(string input, bool expected)
    {
        var sut = new Q1704_DetermineIfStringHalvesAreAlike();
        var actual = sut.HalvesAreAlike(input);
        Assert.Equal(expected, actual);
    }
}