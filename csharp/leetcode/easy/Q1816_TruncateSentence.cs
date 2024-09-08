class Q1816_TruncateSentence
{
    public string TruncateSentence(string s, int k) 
    {
        return string.Empty;    
    }    
}
class Q1816_TruncateSentenceTestData : TestData
{
    protected override List<object[]> Data => 
    [
        ["Hello how are you Contestant", 4, "Hello how are you"],
        ["What is the solution to this problem", 4, "What is the solution"],
        ["chopper is not a tanuki", 5, "chopper is not a tanuki"],
    ];
}
public class Q1816_TruncateSentenceTests
{
    [Theory]
    [ClassData(typeof(Q1816_TruncateSentenceTestData))]
    public void OfficialTestCases(string input, int k, string expected)
    {
        var sut = new Q1816_TruncateSentence();
        var actual = sut.TruncateSentence(input, k);
        Assert.Equal(expected, actual);
    }
}