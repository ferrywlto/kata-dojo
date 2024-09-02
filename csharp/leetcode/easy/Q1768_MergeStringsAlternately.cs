
class Q1768_MergeStringsAlternately
{
    public string MergeAlternately(string word1, string word2) 
    {
        return string.Empty;    
    }
}
class Q1768_MergeStringsAlternatelyTestData : TestData
{
    protected override List<object[]> Data => 
    [
        ["abc", "pqr", "apbqcr"],
        ["ab", "pqrs", "apbqrs"],
        ["abcd", "pq", "apbqcd"],
    ];
}
public class Q1768_MergeStringsAlternatelyTests
{
    [Theory]
    [ClassData(typeof(Q1768_MergeStringsAlternatelyTestData))]
    public void OfficialTestCases(string word1, string word2, string expected)
    {
        var sut = new Q1768_MergeStringsAlternately();
        var actual = sut.MergeAlternately(word1, word2);
        Assert.Equal(expected, actual);
    }
}