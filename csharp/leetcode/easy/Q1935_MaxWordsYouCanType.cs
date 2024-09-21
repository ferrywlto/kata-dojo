class Q1935_MaxWordsYouCanType
{
    public int CanBeTypedWords(string text, string brokenLetters)
    {
        return 0;
    }
}
class Q1935_MaxWordsYouCanTypeTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["hello world", "ad", 1],
        ["leet code", "lt", 1],
        ["leet code", "e", 0],
    ];
}
public class Q1935_MaxWordsYouCanTypeTests
{
    [Theory]
    [ClassData(typeof(Q1935_MaxWordsYouCanTypeTestData))]
    public void OfficialTestCases(string input, string broken, int expected)
    {
        var sut = new Q1935_MaxWordsYouCanType();
        var actual = sut.CanBeTypedWords(input, broken);
        Assert.Equal(expected, actual);
    }
}