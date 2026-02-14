class Q999_AvailableCapturesForRook
{
    // TC: O(n), n is the total cells in board
    // SC: O(1), no extra data structure used
    public int NumRookCaptures(char[][] board)
    {
        // first of all find the 'R'
        (var rRow, var rCol) = FindR(board);
        var capture = 0;
        if (CanCapturePawnEast(rRow, rCol, board)) capture++;
        if (CanCapturePawnWest(rRow, rCol, board)) capture++;
        if (CanCapturePawnNorth(rRow, rCol, board)) capture++;
        if (CanCapturePawnSouth(rRow, rCol, board)) capture++;
        return capture;
    }
    public bool CanCapturePawnEast(int row, int col, char[][] board)
    {
        ++col;
        while (col < board.Length)
        {
            if (board[row][col] == 'p') return true;
            else if (board[row][col] == 'B') return false;
            col++;
        }
        return false;
    }
    public bool CanCapturePawnWest(int row, int col, char[][] board)
    {
        --col;
        while (col >= 0)
        {
            if (board[row][col] == 'p') return true;
            else if (board[row][col] == 'B') return false;
            col--;
        }
        return false;
    }
    public bool CanCapturePawnNorth(int row, int col, char[][] board)
    {
        ++row;
        while (row < board.Length)
        {
            if (board[row][col] == 'p') return true;
            else if (board[row][col] == 'B') return false;
            row++;
        }
        return false;
    }
    public bool CanCapturePawnSouth(int row, int col, char[][] board)
    {
        --row;
        while (row >= 0)
        {
            if (board[row][col] == 'p') return true;
            else if (board[row][col] == 'B') return false;
            row--;
        }
        return false;
    }
    public (int row, int col) FindR(char[][] board)
    {
        for (var i = 0; i < board.Length; i++)
        {
            // always 8x8
            for (var j = 0; j < board.Length; j++)
            {
                if (board[i][j] == 'R')
                {
                    return (i, j);
                }
            }
        }
        return (-1, -1);
    }
}

class Q999_AvailableCapturesForRookTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            new char[][]
            {
                ['.','.','.','.','.','.','.','.'],
                ['.','.','.','p','.','.','.','.'],
                ['.','.','.','R','.','.','.','p'],
                ['.','.','.','.','.','.','.','.'],
                ['.','.','.','.','.','.','.','.'],
                ['.','.','.','p','.','.','.','.'],
                ['.','.','.','.','.','.','.','.'],
                ['.','.','.','.','.','.','.','.']
            }, 3
        ],
        [
            new char[][]
            {
                ['.','.','.','.','.','.','.','.'],
                ['.','p','p','p','p','p','.','.'],
                ['.','p','p','B','p','p','.','.'],
                ['.','p','B','R','B','p','.','.'],
                ['.','p','p','B','p','p','.','.'],
                ['.','p','p','p','p','p','.','.'],
                ['.','.','.','.','.','.','.','.'],
                ['.','.','.','.','.','.','.','.']
            }, 0
        ],
        [
            new char[][]
            {
                ['.','.','.','.','.','.','.','.'],
                ['.','.','.','p','.','.','.','.'],
                ['.','.','.','p','.','.','.','.'],
                ['p','p','.','R','.','p','B','.'],
                ['.','.','.','.','.','.','.','.'],
                ['.','.','.','B','.','.','.','.'],
                ['.','.','.','p','.','.','.','.'],
                ['.','.','.','.','.','.','.','.']
            }, 3
        ],
    ];
}

public class Q999_AvailableCapturesForRookTests
{
    [Theory]
    [ClassData(typeof(Q999_AvailableCapturesForRookTestData))]
    public void OfficialTestCases(char[][] input, int expected)
    {
        var sut = new Q999_AvailableCapturesForRook();
        var actual = sut.NumRookCaptures(input);
        Assert.Equal(expected, actual);
    }
}
