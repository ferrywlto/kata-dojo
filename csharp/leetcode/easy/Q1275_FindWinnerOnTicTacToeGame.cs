
class Q1275_FindWinnerOnTicTacToeGame
{
    public string Tictactoe(int[][] moves)
    {
        return "";
    }
}
class Q1275_FindWinnerOnTicTacToeGameTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int[][] {[0,0],[2,0],[1,1],[2,1],[2,2]}, "A"],
        [new int[][] {[0,0],[1,1],[0,1],[0,2],[1,0],[2,0]}, "B"],
        [new int[][] {[0,0],[1,1],[2,0],[1,0],[1,2],[2,1],[0,1],[0,2],[2,2]}, "Draw"],
    ];
}
public class Q1275_FindWinnerOnTicTacToeGameTests
{
    [Theory]
    [ClassData(typeof(Q1275_FindWinnerOnTicTacToeGameTestData))]
    public void OfficialTestCases(int[][] input, string expected)
    {
        var sut = new Q1275_FindWinnerOnTicTacToeGame();
        var actual = sut.Tictactoe(input);
        Assert.Equal(expected, actual);
    }
}