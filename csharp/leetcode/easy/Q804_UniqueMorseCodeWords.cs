using System.Text;

namespace dojo.leetcode;

public class Q804_UniqueMoreseCodeWords
{
    public readonly string[] MorseCode = [".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.."];
    public string GetMorseCodeFromChar(char c)
    {
        if (c < 65 || c > 122 || (c > 90 && c < 97)) 
            return string.Empty;
        if (c > 64 && c < 91) 
            return MorseCode[c - 65];
        return MorseCode[c - 97];
    }
    public int UniqueMorseRepresentations(string[] words)
    {
        var hashset = new HashSet<string>();
        var sb = new StringBuilder();
        foreach (var word in words)
        {
            sb.Clear();
            foreach (var c in word)
            {
                sb.Append(GetMorseCodeFromChar(c));
            }
            hashset.Add(sb.ToString());
        }
        return hashset.Count;
    }
}

public class Q804_UniqueMoreseCodeWordsTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new string[] {"gin","zen","gig","msg"}, 2],
        [new string[] {"a"}, 1],
    ];
}

public class Q804_UniqueMoreseCodeWordsTests
{
    [Theory]
    [ClassData(typeof(Q804_UniqueMoreseCodeWordsTestData))]
    public void OfficialTestCases(string[] input, int expected)
    {
        var sut = new Q804_UniqueMoreseCodeWords();
        var actual = sut.UniqueMorseRepresentations(input);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData('a', ".-")]
    [InlineData('z', "--..")]
    [InlineData('h', "....")]
    public void GetMoreCodeFromChar_LowerCaseInput_ReturnCorrectMorseCode(char input, string expected)
    {
        var sut = new Q804_UniqueMoreseCodeWords();
        var actual = sut.GetMorseCodeFromChar(input);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData('A', ".-")]
    [InlineData('Z', "--..")]
    [InlineData('H', "....")]
    public void GetMoreCodeFromChar_UpperCaseInput_ReturnCorrectMorseCode(char input, string expected)
    {
        var sut = new Q804_UniqueMoreseCodeWords();
        var actual = sut.GetMorseCodeFromChar(input);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(']')]
    [InlineData('`')]
    [InlineData('{')]
    [InlineData('~')]
    [InlineData(' ')]
    [InlineData('!')]
    [InlineData('@')]
    [InlineData('0')]
    [InlineData('9')]
    public void GetMoreCodeFromChar_InvalidInput_ReturnEmptyString(char input)
    {
        var expected = string.Empty;
        var sut = new Q804_UniqueMoreseCodeWords();
        var actual = sut.GetMorseCodeFromChar(input);
        Assert.Equal(expected, actual);
    }
}