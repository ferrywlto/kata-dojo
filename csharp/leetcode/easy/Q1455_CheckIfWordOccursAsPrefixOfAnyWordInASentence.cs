
class Q1455_CheckIFWordOccursAsPrefixOfAnyWordInASentence
{
    public int IsPrefixOfWord(string sentence, string searchWord) 
    {
        return 0;    
    }    
}
class Q1455_CheckIFWordOccursAsPrefixOfAnyWordInASentenceTestData : TestData
{
    protected override List<object[]> Data => 
    [
        ["i love eating burger", "burg", 4],
        ["this problem is an easy problem", "pro", 2],
        ["i am tired", "you", -1],
    ];
}
public class Q1455_CheckIFWordOccursAsPrefixOfAnyWordInASentenceTests
{
    [Theory]
    [ClassData(typeof(Q1455_CheckIFWordOccursAsPrefixOfAnyWordInASentenceTestData))]
    public void OfficialTestCases(string input, string target, int expected)
    {
        var sut = new Q1455_CheckIFWordOccursAsPrefixOfAnyWordInASentence();
        var actual = sut.IsPrefixOfWord(input, target);
        Assert.Equal(expected, actual);
    }
}