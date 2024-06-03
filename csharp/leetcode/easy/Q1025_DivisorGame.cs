
class Q1025_DivisorGame
{
    public bool DivisorGame(int n) 
    {
        return false;
    }
}
class Q1025_DivisorGameTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [2, true],
        [3, false],
    ];
}
public class Q1025_DivisorGameTests
{
    [Theory]
    [ClassData(typeof(Q1025_DivisorGameTestData))]
    public void OfficialTestCases(int input, bool expected)
    {
        var sut = new Q1025_DivisorGame();
        var actual = sut.DivisorGame(input);
        Assert.Equal(expected, actual);
    }
}