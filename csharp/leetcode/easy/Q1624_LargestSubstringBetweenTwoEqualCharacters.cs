
class Q1624_LargestSubstringBetweenTwoEqualCharacters
{
    public int MaxLengthBetweenEqualCharacters(string s)
    {
        return 0;
    }
}
class Q1624_LargestSubstringBetweenTwoEqualCharactersTestData : TestData
{
    protected override List<object[]> Data => 
    [
        ["aa", 0],
        ["abca", 2],
        ["cbzxy", -1],
    ];
}
public class Q1624_LargestSubstringBetweenTwoEqualCharactersTests
{
    [Theory]
    [ClassData(typeof(Q1624_LargestSubstringBetweenTwoEqualCharactersTestData))]
    public void OfficialTestCases(string input, int expected)
    {
        var sut = new Q1624_LargestSubstringBetweenTwoEqualCharacters();
        var actual = sut.MaxLengthBetweenEqualCharacters(input);
        Assert.Equal(expected, actual);
    }
}