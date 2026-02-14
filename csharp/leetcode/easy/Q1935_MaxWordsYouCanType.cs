class Q1935_MaxWordsYouCanType
{
    // TC: O(n), where n is length of text
    // SC: O(m), where m is length of brokenLetters
    public int CanBeTypedWords(string text, string brokenLetters)
    {
        var brokenChars = brokenLetters.ToHashSet<char>();
        var broke = false;
        var result = 0;
        for (var i = 0; i < text.Length; i++)
        {
            if (brokenChars.Contains(text[i]))
            {
                broke = true;
                continue;
            }
            else if (text[i] == ' ')
            {
                if (!broke) result++;
                broke = false;
            }
        }
        if (!broke) result++;
        return result;
    }
}
class Q1935_MaxWordsYouCanTypeTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["hello world", "ad", 1],
        ["leet code", "lt", 1],
        ["leet code", "e", 0],
        ["e", "e", 0],
        ["c", "e", 1],
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
