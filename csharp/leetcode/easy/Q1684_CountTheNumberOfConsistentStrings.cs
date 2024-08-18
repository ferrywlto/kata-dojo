class Q1684_CountTheNumberOfConsistentString
{
    public int CountConsistentStrings(string allowed, string[] words) 
    {
        return 0;    
    }    
}
class Q1684_CountTheNumberOfConsistentStringTestData : TestData
{
    protected override List<object[]> Data => 
    [
        ["ab", new string[] {"ad","bd","aaab","baa","badab"}],
        ["abc", new string[] {"a","b","c","ab","ac","bc","abc"}],
        ["cad", new string[] {"cc","acd","b","ba","bac","bad","ac","d"}],
    ];
}
public class Q1684_CountTheNumberOfConsistentStringTests
{
    [Theory]
    [ClassData(typeof(Q1684_CountTheNumberOfConsistentStringTestData))]
    public void OfficialTestCases(string allowed, string[] words, int expected)
    {
        var sut = new Q1684_CountTheNumberOfConsistentString();
        var actual = sut.CountConsistentStrings(allowed, words);
        Assert.Equal(expected, actual);
    }
}