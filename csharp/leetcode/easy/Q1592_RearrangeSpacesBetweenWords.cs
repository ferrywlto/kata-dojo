using System.Text;

class Q1592_RearrangeSpacesBetweenWords
{
    // TC: O(n + m + k), where n is length of text + number of words m + number of spaces + k
    // SC: O(n), where n is the length of text for string builder to hold the result
    public string ReorderSpaces(string text)
    {
        var spaceCount = 0;
        var wordStart = -1;

        var words = new List<string>();
        for (var i = 0; i < text.Length; i++)
        {
            if (text[i] == ' ')
            {
                spaceCount++;
                if (wordStart != -1)
                {
                    words.Add(text.Substring(wordStart, i - wordStart));
                    wordStart = -1;
                }
            }
            else if (wordStart == -1)
            {
                wordStart = i;
            }
        }
        if (wordStart != -1)
            words.Add(text.Substring(wordStart, text.Length - wordStart));

        var sb = new StringBuilder(text.Length);
        if (words.Count == 1)
        {
            return words[0] + new string(' ', spaceCount);
        }

        var remainingSpaces = spaceCount % (words.Count - 1);
        var spaceBetweenWords = spaceCount / (words.Count - 1);
        for (var i = 0; i < words.Count; i++)
        {
            if (i > 0) sb.Append(' ', spaceBetweenWords);
            sb.Append(words[i]);
        }
        sb.Append(' ', remainingSpaces);
        return sb.ToString();
    }
}
class Q1592_RearrangeSpacesBetweenWordsTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["  this   is  a sentence ", "this   is   a   sentence"],
        [" practice   makes   perfect", "practice   makes   perfect "],
        ["practice", "practice"],
        ["  practice", "practice  "],
    ];
}
public class Q1592_RearrangeSpacesBetweenWordsTests
{
    [Theory]
    [ClassData(typeof(Q1592_RearrangeSpacesBetweenWordsTestData))]
    public void OfficialTestCases(string input, string expected)
    {
        var sut = new Q1592_RearrangeSpacesBetweenWords();
        var actual = sut.ReorderSpaces(input);
        Assert.Equal(expected, actual);
    }
}
