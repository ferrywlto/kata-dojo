class Q1832_CheckSentenceIsPangram
{
    // TC: O(n), where n is the length of sentence
    // SC: O(1), it is always cap at 26 characters to store 
    public bool CheckIfPangram(string sentence)
    {
        var set = new HashSet<char>();
        foreach (var c in sentence)
        {
            set.Add(c);
            if (set.Count >= 26) return true;
        }
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