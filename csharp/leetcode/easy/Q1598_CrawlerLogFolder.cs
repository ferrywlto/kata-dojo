
class Q1598_CrawlerLogFolder
{
    public int MinOperations(string[] logs) 
    {
        return 0;    
    }
}
class Q1598_CrawlerLogFolderTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new string[] {"d1/","d2/","../","d21/","./"}, 2],
        [new string[] {"d1/","d2/","./","d3/","../","d31/"}, 3],
        [new string[] {"d1/","../","../","../"}, 0],
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