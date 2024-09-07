class Q1805_NumDiffIntegersInString
{
    public int NumDifferentIntegers(string word)
    {
        return 0;
    }
}
class Q1805_NumDiffIntegersInStringTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["a123bc34d8ef34", 3],
        ["leet1234code234", 2],
        ["a1b01c001", 1],
        ["abc", 0],
    ];
}
public class Q1805_NumDiffIntegersInStringTests
{
    [Theory]
    [ClassData(typeof(Q1805_NumDiffIntegersInStringTestData))]
    public void OfficialTestCases(string input, int expected)
    {
        var sut = new Q1805_NumDiffIntegersInString();
        var actual = sut.NumDifferentIntegers(input);
        Assert.Equal(expected, actual);
    }
}