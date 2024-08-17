
class Q1668_MaxRepeatingSubstring
{
    public int MaxRepeating(string sequence, string word) 
    {
        return 0;    
    }    
}
class Q1668_MaxRepeatingSubstringTestData : TestData
{
    protected override List<object[]> Data => 
    [
        ["ababc", "ab", 2],
        ["ababc", "ba", 1],
        ["ababc", "ac", 0],

    ];
}
public class Q1668_MaxRepeatingSubstringTests
{
    [Theory]
    [ClassData(typeof(Q1668_MaxRepeatingSubstringTestData))]
    public void OfficialTestCases(string input, string word, int expected)
    {
        var sut = new Q1668_MaxRepeatingSubstring();
        var actual = sut.MaxRepeating(input, word);
        Assert.Equal(expected, actual);
    }
}