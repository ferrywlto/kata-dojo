using System.Text;

class Q1880_CheckIfWordEqualsSummationOfTwoWords
{
    // TC: O(n log n), n scale with length of firstWord, secondWord and targetWord due to Array.IndexOf()
    // SC: O(n), n scale with length of firstWord, secondWord, targetWord due to StringBuilder
    readonly char[] chars = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j'];
    public bool IsSumEqual(string firstWord, string secondWord, string targetWord)
    {
        var sb = new StringBuilder(firstWord.Length + secondWord.Length);
        foreach (var c in firstWord) sb.Append(Array.IndexOf(chars, c));
        var firstValue = int.Parse(sb.ToString());
        sb.Clear();

        foreach (var c in secondWord) sb.Append(Array.IndexOf(chars, c));
        var secondValue = int.Parse(sb.ToString());
        sb.Clear();

        foreach (var c in targetWord) sb.Append(Array.IndexOf(chars, c));
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