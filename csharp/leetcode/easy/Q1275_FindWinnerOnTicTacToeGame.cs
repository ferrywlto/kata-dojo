class Q1275_FindWinnerOnTicTacToeGame
{
    // TC: O(n), n is the number of moves
    // SC: O(1), as the board size is fixed
    public string Tictactoe(int[][] moves)
    {
        var board = new char[3, 3];
        for (var i = 0; i < moves.Length; i++)
        {
            (int row, int col) = (moves[i][0], moves[i][1]);
            board[row, col] = i % 2 == 0 ? 'A' : 'B';
            if
            (
                RowWin(board, row) ||
                ColWin(board, col) ||
                (row == 1 && col == 1 && (ForwardDiagonalWin(board) || BackwardDiagonalWin(board))) ||
                (row == col && ForwardDiagonalWin(board)) ||
                (((row == 0 && col == 2) || (row == 2 && col == 0)) && BackwardDiagonalWin(board))
            ) return board[row, col].ToString();
        }

        // if no win-condition and its the 9th move, return "Draw"
        return moves.Length == 9 ? "Draw" : "Pending";
    }
    bool RowWin(char[,] board, int row) => board[row, 0] == board[row, 1] && board[row, 1] == board[row, 2];
    bool ColWin(char[,] board, int col) => board[0, col] == board[1, col] && board[1, col] == board[2, col];
    bool ForwardDiagonalWin(char[,] board) => board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2];
    bool BackwardDiagonalWin(char[,] board) => board[2, 0] == board[1, 1] && board[1, 1] == board[0, 2];

}
class Q1275_FindWinnerOnTicTacToeGameTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[][] {[0,0],[1,1]}, "Pending"],
        [new int[][] {[0,0],[0,1],[2,1]}, "Pending"],
        [new int[][] {[0,2],[1,0],[2,2],[1,2],[2,0],[0,0],[0,1],[2,1],[1,1]}, "A"],
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