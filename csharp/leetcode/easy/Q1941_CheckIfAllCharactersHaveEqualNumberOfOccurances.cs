class Q1941_CheckIfAllCharactersHaveEqualNumberOfOccurances
{
    public bool AreOccurrencesEqual(string s)
    {
        return false;
    }
}
class Q1941_CheckIfAllCharactersHaveEqualNumberOfOccurancesTestData : TestData
{
    protected override List<object[]> Data => 
    [
        ["abacbc", true],
        ["aaabb", false],
    ];
}
public class Q1941_CheckIfAllCharactersHaveEqualNumberOfOccurancesTests
{
    [Theory]
    [ClassData(typeof(Q1941_CheckIfAllCharactersHaveEqualNumberOfOccurancesTestData))]
    public void OfficialTestCases(string input, bool expected)
    {
        var sut = new Q1941_CheckIfAllCharactersHaveEqualNumberOfOccurances();
        var actual = sut.AreOccurrencesEqual(input);
        Assert.Equal(expected, actual);
    }
}