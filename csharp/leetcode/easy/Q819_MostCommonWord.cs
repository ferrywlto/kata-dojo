class Q819_MostCommonWord
{
    // TC: O(n), n is length of paragraph
    // SC: O(n), n is number of distinct words found 
    const string symbols = "!?',;. ";
    public string MostCommonWord(string paragraph, string[] banned)
    {
        var tokens = paragraph.ToLower().Split(symbols.ToCharArray());
        var bannedSet = banned.ToHashSet();
        var dict = new Dictionary<string, int>();
        var mostFrequent = 0;
        var mostFrequentWord = string.Empty;
        foreach (var token in tokens)
        {
            if (token == string.Empty || bannedSet.Contains(token)) continue;

            if (!dict.TryGetValue(token, out var value))
            {
                dict.Add(token, 1);
                if (mostFrequent == 0)
                {
                    mostFrequent = 1;
                    mostFrequentWord = token;
                }
            }
            else
            {
                dict[token] = ++value;
                if (value > mostFrequent)
                {
                    mostFrequent = value;
                    mostFrequentWord = token;
                }
            }
        }
        return mostFrequentWord;
    }
}

class Q819_MostCommonWordTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["Bob hit a ball, the hit BALL flew far after it was hit.", new string[] {"hit"}, "ball"],
        ["a, a, a, a, b,b,b,c, c", new string[] {"a"}, "b"],
        ["a.", Array.Empty<string>(), "a"],
        ["a", Array.Empty<string>(), "a"],
    ];
}

public class Q819_MostCommonWordTests
{
    [Theory]
    [ClassData(typeof(Q819_MostCommonWordTestData))]
    public void OfficialTestCases(string input, string[] banned, string expected)
    {
        var sut = new Q819_MostCommonWord();
        var actual = sut.MostCommonWord(input, banned);
        Assert.Equal(expected, actual);
    }
}