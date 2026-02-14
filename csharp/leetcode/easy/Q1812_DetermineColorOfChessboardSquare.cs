class Q1812_DetermineColorOfChessboardSquare
{
    // 97 - 104
    // readonly char[] d1 = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h'];
    // 49 - 56
    // readonly char[] d2 = ['1', '2', '3', '4', '5', '6', '7', '8'];

    // TC: O(1), computation is fixed
    // SC: O(1), space used is fixed
    public bool SquareIsWhite(string coordinates)
    {
        return (coordinates[0] % 2 == 1 && coordinates[1] % 2 == 0) || (coordinates[0] % 2 == 0 && coordinates[1] % 2 == 1);
    }
}
class Q1812_DetermineColorOfChessboardSquareTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["a1", false],
        ["h3", true],
        ["c7", false],
        ["g7", false],
        ["e6", true],
        ["h1", true],
        ["d8", false],
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
