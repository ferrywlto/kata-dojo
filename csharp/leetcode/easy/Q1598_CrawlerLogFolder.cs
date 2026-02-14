class Q1598_CrawlerLogFolder
{
    // TC: O(n), where n is the size of logs, it have to iterate once to know the result
    // SC: O(1), space used is fixed
    public int MinOperations(string[] logs)
    {
        var level = 0;
        foreach (var log in logs)
        {
            if (log == "../")
            {
                if (level > 0) level--;
            }
            else if (log != "./") level++;
        }
        return level;
    }
}
class Q1598_CrawlerLogFolderTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new string[] {"d1/","d2/","../","d21/","./"}, 2],
        [new string[] {"d1/","d2/","./","d3/","../","d31/"}, 3],
        [new string[] {"d1/","../","../","../"}, 0],
        [new string[] {"./","../","./"}, 0],
    ];
}
public class Q1598_CrawlerLogFolderTests
{
    [Theory]
    [ClassData(typeof(Q1598_CrawlerLogFolderTestData))]
    public void OfficialTestCases(string[] input, int expected)
    {
        var sut = new Q1598_CrawlerLogFolder();
        var actual = sut.MinOperations(input);
        Assert.Equal(expected, actual);
    }
}
