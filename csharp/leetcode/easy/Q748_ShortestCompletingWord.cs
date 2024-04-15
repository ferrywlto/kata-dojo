public class Q748_ShortestCompletingWord
{
    // TC: O(n*m)
    // SC: less than O(n)
    public string ShortestCompletingWord(string licensePlate, string[] words)
    {
        var lpDict = licensePlate
            .ToLower()
            .Where(c => c != 32 && c > 96 && c < 123)
            .GroupBy(c => c)
            .ToDictionary(g => g.Key, g => g.Count());

        var lpKeyCount = lpDict.Keys.Count;
        IEnumerable<string> filter = words;
        foreach (var key in lpDict.Keys)
        {
            filter = filter.Where(w => w.Contains(key));
        }

        var shortestLength = int.MaxValue;
        var shortestWord = string.Empty;
        foreach (var word in filter)
        {
            var valid = word
                .GroupBy(c => c)
                .Where(g => lpDict.ContainsKey(g.Key))
                .Where(g => g.Count() >= lpDict[g.Key])
                .Count() == lpKeyCount;

            if (valid && word.Length < shortestLength)
            {
                shortestLength = word.Length;
                shortestWord = word;
            }
        }
        return shortestWord;
    }
}

public class Q748_ShortestCompletingWordTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["1s3 PSt", new string[]{"step","steps","stripe","stepple"}, "steps"],
        ["1s3 456", new string[]{"looks","pest","stew","show"}, "pest"],
    ];
}

public class Q748_ShortestCompletingWordTests
{
    [Theory]
    [ClassData(typeof(Q748_ShortestCompletingWordTestData))]
    public void OfficialTestCases(string input, string[] words, string expected)
    {
        var sut = new Q748_ShortestCompletingWord();
        var actual = sut.ShortestCompletingWord(input, words);
        Assert.Equal(expected, actual);
    }
}