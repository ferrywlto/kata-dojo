namespace dojo.leetcode;

public class Q748_ShortestCompletingWord
{
     public string ShortestCompletingWord(string licensePlate, string[] words) 
     {
        var lpDict = licensePlate
            .ToLower()
            .Where(c => c != 32 && c > 96 && c < 123)
            .GroupBy(c => c)
            .ToDictionary(g => g.Key, g => g.Count());

        foreach(var key in lpDict.Keys)
        {
            words = words
                .Where(w => w.Contains(key))
                .ToArray();
        }

        var shortestLength = int.MaxValue;
        var shortestWord = string.Empty;
        foreach (var word in words)
        {
            var wordDict = word
                .GroupBy(c => c)
                .Where(g => lpDict.ContainsKey(g.Key))
                .ToDictionary(g => g.Key, g => g.Count());

            bool valid = wordDict.Aggregate(true, (result, pair) => result && wordDict[pair.Key] >= lpDict[pair.Key]);
            if(valid && word.Length < shortestLength)
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