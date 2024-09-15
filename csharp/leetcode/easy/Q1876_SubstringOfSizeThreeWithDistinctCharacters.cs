class Q1876_SubstringOfSizeThreeWithDistinctCharacters
{
    public int CountGoodSubstrings(string s)
    {
        return 0;
    }
}
class Q1876_SubstringOfSizeThreeWithDistinctCharactersTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["xyzzaz", 1],
        ["aababcabc", 4],
    ];
}
public class Q1876_SubstringOfSizeThreeWithDistinctCharactersTests
{
    [Theory]
    [ClassData(typeof(Q1876_SubstringOfSizeThreeWithDistinctCharactersTestData))]
    public void OfficialTestCases(string input, int expected)
    {
        var sut = new Q1876_SubstringOfSizeThreeWithDistinctCharacters();
        var actual = sut.CountGoodSubstrings(input);
        Assert.Equal(expected, actual);
    }
}