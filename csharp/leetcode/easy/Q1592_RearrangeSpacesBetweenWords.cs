class Q1592_RearrangeSpacesBetweenWords
{
    public string ReorderSpaces(string text) 
    {
        return string.Empty;    
    }    
}
class Q1592_RearrangeSpacesBetweenWordsTestData : TestData
{
    protected override List<object[]> Data => 
    [
        ["  this   is  a sentence ", "this   is   a   sentence"],
        [" practice   makes   perfect", "practice   makes   perfect "],
    ];
}
public class Q1592_RearrangeSpacesBetweenWordsTests
{
    [Theory]
    [ClassData(typeof(Q1592_RearrangeSpacesBetweenWordsTestData))]
    public void OfficialTestCases(string input, string expected)
    {
        var sut = new Q1592_RearrangeSpacesBetweenWords();
        var actual = sut.ReorderSpaces(input);
        Assert.Equal(expected, actual);
    }
}