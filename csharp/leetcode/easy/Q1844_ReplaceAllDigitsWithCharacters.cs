class Q1844_ReplaceAllDigitsWithCharacters
{
    public string ReplaceDigits(string s)
    {
        return string.Empty;
    }
}
class Q1844_ReplaceAllDigitsWithCharactersTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["a1c1e1", "abcdef"],
        ["a1b2c3d4e", "abbdcfdhe"],
    ];
}
public class Q1844_ReplaceAllDigitsWithCharactersTests
{
    [Theory]
    [ClassData(typeof(Q1844_ReplaceAllDigitsWithCharactersTestData))]
    public void OfficialTestCases(string input, string expected)
    {
        var sut = new Q1844_ReplaceAllDigitsWithCharacters();
        var actual = sut.ReplaceDigits(input);
        Assert.Equal(expected, actual);
    }
}