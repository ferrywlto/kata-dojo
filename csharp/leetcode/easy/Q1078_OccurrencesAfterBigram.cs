class Q1078_OccurancesAfterBigram
{
    // TC: O(n), n is words in text
    // SC: O(n), n is words in text from split 
    public string[] FindOcurrences(string text, string first, string second)
    {
        var words = text.Split(" ");
        if (words.Length < 3) return [];
        var result = new List<string>();
        for (var i = 0; i < words.Length - 2; i++)
        {
            if (words[i] == first && words[i + 1] == second)
            {
                result.Add(words[i + 2]);
            }
        }
        return result.ToArray();
    }
}
class Q1078_OccurancesAfterBigramTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["alice is a good girl she is a good student", "a", "good", new string[] {"girl", "student"}],
        ["we will we will rock you", "we", "will", new string[] {"we", "rock"}],
    ];
}
public class Q1078_OccurancesAfterBigramTests
{
    [Theory]
    [ClassData(typeof(Q1078_OccurancesAfterBigramTestData))]
    public void OfficialTestCases(string input, string first, string second, string[] expected)
    {
        var sut = new Q1078_OccurancesAfterBigram();
        var actual = sut.FindOcurrences(input, first, second);
        Assert.Equal(expected, actual);
    }
}
