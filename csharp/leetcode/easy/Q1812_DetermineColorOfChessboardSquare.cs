class Q1812_DetermineColorOfChessboardSquare
{
    public bool SquareIsWhite(string coordinates) 
    {
        return false;    
    }    
}
class Q1812_DetermineColorOfChessboardSquareTestData : TestData
{
    protected override List<object[]> Data => 
    [
        ["a1", false],
        ["h3", true],
        ["c7", false],
    ];
}
public class Q1812_DetermineColorOfChessboardSquareTests
{
    [Theory]
    [ClassData(typeof(Q1812_DetermineColorOfChessboardSquareTestData))]
    public void OfficialTestCases(string input, bool expected)
    {
        var sut = new Q1812_DetermineColorOfChessboardSquare();
        var actual = sut.SquareIsWhite(input);
        Assert.Equal(expected, actual);
    }
}