
class Q1496_PathCrossing
{
    public bool IsPathCrossing(string path)
    {
        return false;    
    }    
}
class Q1496_PathCrossingTestData : TestData
{
    protected override List<object[]> Data => 
    [
        ["NES", false],
        ["NESWW", true],
    ];
}
public class Q1496_PathCrossingTests
{
    [Theory]
    [ClassData(typeof(Q1496_PathCrossingTestData))]
    public void OfficialTestCases(string input, bool expected)
    {
        var sut = new Q1496_PathCrossing();
        var actual = sut.IsPathCrossing(input);
        Assert.Equal(expected, actual);
    }
}