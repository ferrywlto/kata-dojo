class Q1880_CheckIfWordEqualsSummationOfTwoWords
{
    public bool IsSumEqual(string firstWord, string secondWord, string targetWord)
    {
        return false;
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