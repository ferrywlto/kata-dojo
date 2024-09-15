using System.Text;

class Q1880_CheckIfWordEqualsSummationOfTwoWords
{
    // TC: O(n), n scale with length of firstWord, secondWord and targetWord to iterate all characters
    // SC: O(n), n scale with length of firstWord, secondWord, targetWord due to StringBuilder
    public bool IsSumEqual(string firstWord, string secondWord, string targetWord)
    {
        var sb = new StringBuilder();

        foreach (var c in firstWord) sb.Append(c - 'a');
        var firstValue = int.Parse(sb.ToString());
        sb.Clear();

        foreach (var c in secondWord) sb.Append(c - 'a');
        var secondValue = int.Parse(sb.ToString());
        sb.Clear();

        foreach (var c in targetWord) sb.Append(c - 'a');
        var targetValue = int.Parse(sb.ToString());
        return (firstValue + secondValue) == targetValue;
    }
}
class Q1880_CheckIfWordEqualsSummationOfTwoWordsTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["acb", "cba", "cdb", true],
        ["aaa", "a", "aab", false],
        ["aaa", "a", "aaaa", true],
    ];
}
public class Q1880_CheckIfWordEqualsSummationOfTwoWordsTests
{
    [Theory]
    [ClassData(typeof(Q1880_CheckIfWordEqualsSummationOfTwoWordsTestData))]
    public void OfficialTestCases(string first, string second, string target, bool expected)
    {
        var sut = new Q1880_CheckIfWordEqualsSummationOfTwoWords();
        var actual = sut.IsSumEqual(first, second, target);
        Assert.Equal(expected, actual);
    }
}