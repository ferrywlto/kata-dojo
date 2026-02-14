class Q1859_SortingTheSentences
{
    // TC: O(n), where n is length of s
    // SC: O(1), the question constraints there are maximum 9 words
    public string SortSentence(string s)
    {
        var words = new string[9];
        var startIdx = 0;
        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] == ' ')
            {
                var position = int.Parse(s[i - 1].ToString());
                var word = s[startIdx..(i - 1)];
                words[position] = word;
                startIdx = i + 1;
            }
        }
        words[int.Parse(s[^1].ToString())] = s[startIdx..^1];
        return string.Join(' ', words.Where(p => p is not null));
    }
}
class Q1859_SortingTheSentencesTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["is2 sentence4 This1 a3", "This is a sentence"],
        ["Myself2 Me1 I4 and3", "Me Myself and I"],
    ];
}
public class Q1859_SortingTheSentencesTests
{
    [Theory]
    [ClassData(typeof(Q1859_SortingTheSentencesTestData))]
    public void OfficialTestCases(string input, string expected)
    {
        var sut = new Q1859_SortingTheSentences();
        var actual = sut.SortSentence(input);
        Assert.Equal(expected, actual);
    }
}
