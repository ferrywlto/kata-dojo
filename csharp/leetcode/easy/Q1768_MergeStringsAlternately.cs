using System.Text;

class Q1768_MergeStringsAlternately
{
    // TC: O(n), where n is word1.Length + word2.Length for Append();
    // SC: O(n), where n is word1.Length + word2.Length for string builder
    public string MergeAlternately(string word1, string word2)
    {
        var idx = 0;
        var sb = new StringBuilder(word1.Length + word2.Length);
        while (idx < word1.Length || idx < word2.Length)
        {
            if (idx < word1.Length) sb.Append(word1[idx]);
            if (idx < word2.Length) sb.Append(word2[idx]);
            idx++;
        }
        return sb.ToString();
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
