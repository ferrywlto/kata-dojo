
class Q884_UncommonWordsInTwoSentences
{
    // TC: O(n), n is total length of s1 + s2
    // SC: O(n), n is total words from both string
    public string[] UncommonFromSentences(string s1, string s2)
    {
        var dict = new Dictionary<string, int>();
        var words1 = s1.Split(' ');
        var words2 = s2.Split(' ');

        GroupWords(words1);
        GroupWords(words2);

        void GroupWords(string[] words)
        {
            for (var i = 0; i < words.Length; i++)
            {
                if (!dict.TryGetValue(words[i], out var value)) 
                    dict.Add(words[i], 1);
                else 
                    dict[words[i]] = ++value;
            }
        }

        return dict
            .Where(p => p.Value == 1)
            .Select(p => p.Key)
            .ToArray();
    }
}

class Q884_UncommonWordsInTwoSentencesTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["this apple is sweet", "this apple is sour", new string[] {"sweet","sour"}],
        ["apple apple", "banana", new string[] {"banana"}],
    ];
}

public class Q884_UncommonWordsInTwoSentencesTests
{
    [Theory]
    [ClassData(typeof(Q884_UncommonWordsInTwoSentencesTestData))]
    public void OfficialTestCases(string input1, string input2, string[] expected)
    {
        var sut = new Q884_UncommonWordsInTwoSentences();
        var actual = sut.UncommonFromSentences(input1, input2);
        Assert.Equal(expected, actual);
    }
}