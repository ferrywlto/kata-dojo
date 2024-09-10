class Q1832_CheckSentenceIsPangram
{
    public bool CheckIfPangram(string sentence)
    {
        return false;
    }
}
class Q1832_CheckSentenceIsPangramTestData : TestData
{
    protected override List<object[]> Data => 
    [
        ["thequickbrownfoxjumpsoverthelazydog", true],
        ["leetcode", false],
    ];
}
public class Q1832_CheckSentenceIsPangramTests
{
    [Theory]
    [ClassData(typeof(Q1832_CheckSentenceIsPangramTestData))]
    public void OfficialTestCases(string input, bool expected)
    {
        var sut = new Q1832_CheckSentenceIsPangram();
        var actual = sut.CheckIfPangram(input);
        Assert.Equal(expected, actual);
    }
}